using Microsoft.EntityFrameworkCore;

namespace CookBookEF.Model
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public string DbPath { get; }

        public RecipeContext()
        {
            //Find din lokale database hvor den er blevet oprettet og skriv stien!!
            DbPath = "C:\\Users\\hotso\\source\\repos\\ExamHelpSoftArc\\Recipes\\bin\\Recipes.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }
}
