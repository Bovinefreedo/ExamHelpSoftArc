using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp.LinkedList
{
    public class PersonNode
    {
        public PersonNode? Next { get; set; } = null;
        public int Age { get; set; }
        public string Name { get; set; } = string.Empty;

        public PersonNode(int age, string name) {
            this.Age = age;
            this.Name = name;
        }
    }
}
