using System;
namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            /*  1. Age Restriction */

            // string input = Console.ReadLine();
            // Console.WriteLine(GetBooksByAgeRestriction(db, input));

            /* 2. Golden Books */

            // Console.WriteLine(GetGoldenBooks(db));

            /* 3. Books by Price */

            // Console.WriteLine(GetBooksByPrice(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction age = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(x => x.AgeRestriction == age)
                .Select(x => new
                {
                    Title = x.Title
                })
                .OrderBy(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType editionType = Enum.Parse<EditionType>("Gold", true);

            var books = context.Books
                               .Where(x => x.Copies < 5000 && x.EditionType == editionType)
                               .Select(x => new
                               {
                                   Title = x.Title,
                                   BookId = x.BookId
                               })
                               .OrderBy(x => x.BookId)
                               .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                               .Where(x => x.Price > 40)
                               .Select(x => new
                               {
                                   x.Title,
                                   x.Price
                               })
                               .OrderByDescending(x => x.Price);

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
