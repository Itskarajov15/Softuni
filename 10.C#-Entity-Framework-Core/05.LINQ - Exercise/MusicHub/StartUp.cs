namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer.Name)
                    .Select(s => new
                    {
                        s.Name,
                        s.Price,
                        SongWriter = s.Writer.Name
                    })
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.SongWriter)
                    .ToList(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 1;

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");

                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performer = s.SongPerformers
                                    .Select(x => x.Performer.FirstName + " " + x.Performer.LastName)
                                    .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.Performer)
                .ToList();

            var sb = new StringBuilder();

            int counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
