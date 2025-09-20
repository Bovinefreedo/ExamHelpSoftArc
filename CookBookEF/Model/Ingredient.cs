using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookEF.Model
{
    public class Ingredient
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

        Ingredient() { }
    }
}
