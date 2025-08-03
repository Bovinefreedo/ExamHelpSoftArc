using Microsoft.EntityFrameworkCore;

namespace Spg9BibliotekEF.Model
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public string DbPath { get; }

        public BookContext()
        {
            //Find din lokale database hvor den er blevet oprettet og skriv stien!!
            DbPath = "C:\\Users\\hotso\\source\\repos\\ExamHelpSoftArc\\Spg9BibliotekEF\\bin\\Books.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }
}