using System.Web.Mvc;
using WebBookCatalog.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebBookCatalog.Controllers
{
    public class HomeController : Controller
    {
        private WebBookCatalogContext contextObj = new WebBookCatalogContext();
        public async Task<ActionResult> Index()
        {
            IEnumerable<Book> books = await contextObj.Books.ToListAsync();
            ViewBag.Title = "Books";
            ViewBag.Books = books;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            contextObj.Dispose();
            base.Dispose(disposing);
        }

    }
    
}
