using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace FuncHttp
{
    public class GetBooks
    {
        private readonly ILogger<GetBooks> _logger;
        private readonly List<Book> _books;

        public GetBooks(ILogger<GetBooks> log)
        {
            _logger = log;

            _books = new List<Book>()
            {
                new Book { Id = 1, Title = ".NET 6 解説",
                Author = "増田智明", Price = 2000, Publisher = "日経BP"},
                new Book { Id = 2, Title = "Blazor 入門",
                Author = "増田智明", Price = 2000, Publisher = "日経BP"},
                new Book { Id = 3, Title = "ピープルウェア",
                Author = "トム・デマルコ", Price = 2000, Publisher = "日経BP"},
                new Book { Id = 4, Title = "人月の神話",
                Author = "ブルックス", Price = 2000,
                Publisher = "ピアソン・エデュケーション"},
                new Book { Id = 5, Title = "知識創造企業",
                Author = "野中郁次郎", Price = 3000, Publisher = "東洋経済"},
                new Book { Id = 6, Title = "パタン・ランゲージ",
                Author = "C・アレグザンダー", Price = 5000,
                Publisher = "鹿島出版会"},
            };
        }

        [FunctionName("GetBooks")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            return new OkObjectResult(_books);
        }
        [FunctionName("GetBook")]
        public IActionResult RunById(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Book/{id:int}")] HttpRequest req, int id)
        {
            var book = _books.FirstOrDefault(t => t.Id == id);
            return new OkObjectResult(book);
        }
    }
}
