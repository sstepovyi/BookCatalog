using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebBookCatalog.Models;

namespace WebBookCatalog.Controllers
{
    public class BooksController : ApiController
    {
        private WebBookCatalogContext contextObj = new WebBookCatalogContext();

        [HttpGet]
        public async Task<List<Book>> GetBooks()
        {
            return await contextObj.Books.ToListAsync(); ;
        }
        // Get Books based on Criteria
        [HttpGet]
        [Route("Books/{filter}/{value}")]
        public List<Book> GetBooksByCustName(string filter, string value)
        {
            List<Book> Res = new List<Book>();
            switch (filter)
            {
                case "Author":
                    Res = (from a in contextObj.Books
                           where a.Author.StartsWith(value)
                           select a).ToList();
                    break;
                case "Title":
                    Res = (from t in contextObj.Books
                           where t.Title.StartsWith(value)
                           select t).ToList();
                    break;

                default:
                    Res = (from t in contextObj.Books
                           select t).ToList();
                    break;
            }
            return Res;
        }

        // AddBook
        public Task<List<Book>> AddBook(Book book)
        {
            if (book != null)
            {
                try
                {
                    contextObj.Books.Add(book);
                    contextObj.SaveChanges();
                    return this.GetBooks();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        // DELETE 
        [HttpDelete]
        public string DeleteBook(string Id)
        {
            int _id = Convert.ToInt32(Id);

            Book delbook = contextObj.Books.Find(_id);
            if (contextObj == null)
            {
                return "Context is null";
            }
            contextObj.Books.Remove(delbook);
            try
            {
                contextObj.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ex.ToString();
            }
            return "Ok";

        }
        // Update Book
        public Task<List<Book>> PutBook(Book book)
        {
            try
            {
                var books = contextObj.Books.Single(a => a.Id == book.Id);
                books.Annotation = book.Annotation;
                books.Author = book.Author;
                books.Price = book.Price;
                books.Genre = book.Genre;
                books.Title = book.Title;
                books.Year = book.Year;

                contextObj.SaveChanges();
                return this.GetBooks();

            }
            catch
            {
                return null;
            }
        }
        protected override void Dispose(bool disposing)
        {
            contextObj.Dispose();
            base.Dispose(disposing);
        }


    }
}