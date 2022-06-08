namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context
                .Projects
                .Where(p => p.Tasks.Count() >= 1)
                .ToArray()
                .Select(p => new ExportProjectOutputModel
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count(),
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks
                        .Select(t => new ExportTaskOutputModel
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Tasks.Count())
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var result = XmlConverter.Serialize(projects, "Projects");

            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                            .Where(et => et.Task.OpenDate >= date)
                            .Select(et => et.Task)
                            .OrderByDescending(t => t.DueDate)
                            .ThenBy(t => t.Name)
                            .Select(t => new
                            {
                                TaskName = t.Name,
                                OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                DueDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                LabelType = t.LabelType.ToString(),
                                ExecutionType = t.ExecutionType.ToString()
                            })
                            .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            string result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;
        }
    }
}