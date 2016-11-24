using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebBookCatalog.Models;

namespace WebBookCatalog
{
    interface IBooks
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> Get(string filter, string value);
        Book Add(Book book);
        bool Update(Book book);
        bool Delete(int id);

    }
}
