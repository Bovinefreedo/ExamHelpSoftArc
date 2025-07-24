using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp.Model
{
    public class NumberNode
    {
        public int Number { get; set; } = 0;
        public NumberNode? Next { get; set; } = null;

        public NumberNode(int number)
        {
            Number = number;
        }
    }
}
