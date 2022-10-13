using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTaskTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxTaskDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public Board Board { get; init; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        public User Owner { get; init; } = null!;
    }
}