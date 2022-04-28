using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace FuncHttpDb
{
    public static class GetBooks
    {
        [FunctionName("GetBooks")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var cnstr = System.Environment.GetEnvironmentVariable("DB_CONNECTION");
            var builder = new DbContextOptionsBuilder<BooksContext>();
            builder.UseSqlServer(cnstr);
            builder.EnableServiceProviderCaching(false);
            var context = new BooksContext(builder.Options);
            var books = await context.Books.ToListAsync();
            return new OkObjectResult(books);
        }

        [FunctionName("Book")]
        public static async Task<IActionResult> RunByTitle(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var json = System.Text.Json.JsonSerializer.Deserialize<Book>(req.Body);
            var title = json.Title;
            var cnstr = System.Environment.GetEnvironmentVariable("DB_CONNECTION");
            var builder = new DbContextOptionsBuilder<BooksContext>();
            builder.UseSqlServer(cnstr);
            builder.EnableServiceProviderCaching(false);
            var context = new BooksContext(builder.Options);
            var books = await context.Books
                .Where(t => t.Title.Contains(json.Title))
                .ToListAsync();
            return new OkObjectResult(books);
        }

    }

    class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }

    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Publisher { get; set; }
    }

}
