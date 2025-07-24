using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp.Model
{
    public class ColorNode
    {
        public string Color { get; set; } = "Black";
        public ColorNode? Next { get; set; } = null;

        public ColorNode(string color)
        {
            Color = color;
        }
    }
}
