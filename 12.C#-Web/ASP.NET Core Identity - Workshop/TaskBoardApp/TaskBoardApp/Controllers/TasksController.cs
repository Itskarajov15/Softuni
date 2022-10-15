using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Tasks;

namespace TaskBoardApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskBoardAppDbContext data;
        public TasksController(TaskBoardAppDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public IActionResult Create()
        {
            TaskFormViewModel taskModel = new TaskFormViewModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Create(TaskFormViewModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
            }

            string currentUserId = GetUserId();

            var task = new Data.Entities.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            this.data.Tasks.Add(task);
            this.data.SaveChanges();

            var boards = this.data.Boards;

            return RedirectToAction("All", "Boards");
        }

        private IEnumerable<TaskBoardModel> GetBoards()
            => this.data
                   .Boards
                   .Select(b => new TaskBoardModel()
                   {
                       Id = b.Id,
                       Name = b.Name
                   });

        public IActionResult Details(int id)
        {
            var task = this.data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefault();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public IActionResult Edit(int id)
        {
            var task = this.data.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            var taskModel = new TaskFormViewModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, TaskFormViewModel taskModel)
        {
            var task = this.data.Tasks.Find(id);

            if (task == null)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                this.ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            this.data.SaveChanges();
            return RedirectToAction("All", "Boards");
        }

        private string GetUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}