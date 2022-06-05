using System.Collections;
using System.Collections.Generic;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportGenreOutputModel
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public ICollection<ExportGameOutputModel> Games { get; set; }

        public int TotalPlayers { get; set; }
    }
}