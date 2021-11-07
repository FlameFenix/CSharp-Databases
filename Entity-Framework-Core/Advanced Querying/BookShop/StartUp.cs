using System;
namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
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
            // string input = Console.ReadLine();
            // Console.WriteLine(GetBooksByCategory(db, input));

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

            /* 10. Count Books */
            // int input = int.Parse(Console.ReadLine());
            // Console.WriteLine(CountBooks(db, input));

            /* 11. Total Book Copies */
            // Console.WriteLine(CountCopiesByAuthor(db));

            /* 12. Profit by Category */
            // Console.WriteLine(GetTotalProfitByCategory(db));

            /* 13. Most Recent Books */
            // Console.WriteLine(GetMostRecentBooks(db));

            /* 14. Increase Prices*/
            //IncreasePrices(db);

            /*15. Remove Books */

            // Console.WriteLine(RemoveBooks(db));
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

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(x => x.ToLower())
                                       .ToList();

            var books = context.Books
                .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
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

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                               .Where(x => x.Title.Length > lengthCheck)
                               .ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorName} - {author.Copies}");
            }

            return sb.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(x => (x.Book.Copies * x.Book.Price))
                })
                .OrderByDescending(x => x.Profit)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            }

            return sb.ToString();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {

            var categories = context.Categories
                .Include(x => x.CategoryBooks)
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(x => new
                    {
                        x.Book.Title,
                        ReleaseDate = x.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                int index = 0;
                foreach (var book in category.Books)
                {
                    if (index == 3)
                    {
                        break;
                    }
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.ToString("yyyy")})");
                    index++;
                }
            }
            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Copies < 4200).ToList();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return books.Count;
        }
    }
}
