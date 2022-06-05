using System.Collections.Generic;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportGameOutputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Tags { get; set; }

        public int Players { get; set; }
    }
}