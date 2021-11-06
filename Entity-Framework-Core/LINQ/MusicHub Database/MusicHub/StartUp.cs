namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

           // Console.WriteLine(ExportAlbumsInfo(context, 4));

            Console.WriteLine(ExportSongsAboveDuration(context, 480));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(x => x.ProducerId == producerId)
                .ToArray()
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("F2"),
                        WriterName = s.Writer.Name
                    })
                    .ToArray()
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.WriterName),

                    AlbumPrice = x.Price

                })
                .ToArray()
                .OrderByDescending(x => x.AlbumPrice);

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");
                int index = 1;
                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{index++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .Include(x => x.SongPerformers)
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    SongName = x.Name,
                    PerformerName = x.SongPerformers
                    .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                    .FirstOrDefault(),

                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    SongDuration = x.Duration

                })
                .ToList()
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            int index = 1;
            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{index++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.SongDuration.ToString("c")}");
            }

            return sb.ToString().Trim();
        }
    }
}
