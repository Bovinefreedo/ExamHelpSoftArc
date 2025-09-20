using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookEF.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string Description { get; set; } = "no description";

        public Recipe() { }
    }
}
