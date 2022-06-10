namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var books = XmlConverter.Deserializer<ImportBookInputModel>(xmlString, "Books");
            var sb = new StringBuilder();

            foreach (var item in books)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isParsed = DateTime.TryParseExact(
                    item.PublishedOn,
                    "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime publishedOn);

                if (!isParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = item.Name,
                    Genre = (Genre)item.Genre,
                    Price = item.Price,
                    Pages = item.Pages,
                    PublishedOn = publishedOn
                };

                context.Books.Add(book);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price.ToString("F2")));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authors = JsonConvert.DeserializeObject<ImportAuthorInputModel[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var item in authors)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = context.Authors.FirstOrDefault(a => a.Email == item.Email);
                if (author != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newAuthor = new Author
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone,
                    Email = item.Email
                };

                foreach (var book in item.Books)
                {
                    var dbBook = context.Books.FirstOrDefault(b => b.Id == book.Id);

                    if (dbBook == null)
                    {
                        continue;
                    }

                    newAuthor.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = newAuthor,
                        Book = dbBook
                    });
                }

                if (newAuthor.AuthorsBooks.Count() <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Authors.Add(newAuthor);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, $"{newAuthor.FirstName + " " + newAuthor.LastName}",
                    newAuthor.AuthorsBooks.Count()));
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}