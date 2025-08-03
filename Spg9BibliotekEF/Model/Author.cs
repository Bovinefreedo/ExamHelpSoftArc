using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg9BibliotekEF.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string name { get; set; } = "Unknown";
        public int age { get; set; }

        public Author() { }
    }
}
