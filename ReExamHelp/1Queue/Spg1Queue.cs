using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReExamHelp.Model;

namespace ReExamHelp._1Queue
{
    public class Spg1Queue
    {
        public ColorNode? Head { get; set; } = null;

        public void Enqueue(string color)
        {
            ColorNode newNode = new ColorNode(color);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                ColorNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public ColorNode? Dequeue()
        {
            if (Head == null)
            {
                return null;
            }
            ColorNode dequeuedNode = Head;
            Head = Head.Next;
            dequeuedNode.Next = null;
            return dequeuedNode;
        }

        public ColorNode? Peek()
        {
            return Head;
        }

        public int Count()
        {
            int count = 0;
            ColorNode? current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
