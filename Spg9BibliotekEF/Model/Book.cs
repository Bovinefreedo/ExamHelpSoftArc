using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg9BibliotekEF.Model
{
    public class Book
    {
        public long BookId { get; set; }
        public string title { get; set; } = "no title";
        public long AuthorId { get; set; }
        public Author author { get; set; }
        public int year { get; set; } = -1;
        public List<Book> books { get; set; }

        public Book(string title, Author author, int year) {
            this.title = title;
            this.author = author;
            this.year = year;
        }
    }
}
