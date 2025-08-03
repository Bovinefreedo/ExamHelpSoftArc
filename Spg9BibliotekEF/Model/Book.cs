using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg9BibliotekEF.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = "no title";
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int Year { get; set; } = -1;

        public Book() { }
    }
}
