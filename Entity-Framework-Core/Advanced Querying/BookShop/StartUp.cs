using System;
namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Collections.Generic;
    using System.Globalization;
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

            /* 4. Not Released In */

            // int input = int.Parse(Console.ReadLine());

            // Console.WriteLine(GetBooksNotReleasedIn(db, input));

            /* 5 Books Categories */

            /* 6. Released Before Date */

            // string input = Console.ReadLine();
            // Console.WriteLine(GetBooksReleasedBefore(db, input));

            /* 7. Author Search */

            // string input = Console.ReadLine();
            // Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            /* 8. Book Search */
            // string input = Console.ReadLine();
            // Console.WriteLine(GetBookTitlesContaining(db, input));

            /* 9. Book Search By Author */
            // string input = Console.ReadLine();
            // Console.WriteLine(GetBooksByAuthor(db, input));
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

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context.Books
                               .Where(x => x.ReleaseDate.Value.Year != year)
                               .Select(x => new
                               {
                                   x.BookId,
                                   x.Title
                               }).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();

            StringBuilder sb = new StringBuilder();

            return sb.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime givenDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < givenDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new 
                {
                    x.Title
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

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.Title,
                    x.BookId,
                    AuthorFullName = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .OrderBy(x => x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().Trim();
        }
    }
}
