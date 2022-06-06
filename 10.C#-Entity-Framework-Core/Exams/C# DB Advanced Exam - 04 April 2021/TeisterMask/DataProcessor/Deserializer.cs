namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var projects = XmlConverter.Deserializer<ImportProjectInputModel>(xmlString, "Projects");
            var sb = new StringBuilder();

            foreach (var item in projects)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isParsedOpenDate = DateTime.TryParseExact(item.OpenDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime openDate);

                if (!isParsedOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;
                if (!String.IsNullOrWhiteSpace(item.DueDate))
                {
                    var isParsedDueDate = DateTime.TryParseExact(item.DueDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dueDateValue);

                    if (!isParsedDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                var project = new Project
                {
                    Name = item.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (var task in item.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isOpenDateValid = DateTime.TryParseExact(task.OpenDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime outDate);

                    if (!isOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isDueDateValid = DateTime.TryParseExact(task.DueDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dueDateValue);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (outDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue && dueDateValue > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = openDate,
                        DueDate = dueDateValue,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };

                    project.Tasks.Add(newTask);
                }

                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}