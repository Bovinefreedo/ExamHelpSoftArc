using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReExamHelp.Model;

namespace ReExamHelp._2Stack
{
    public class Spg2Stack
    {
        ColorNode? First { get; set; } = null;
        public int Length;

        public void Push(string color)
        {
            ColorNode newNode = new ColorNode(color);
            if (First == null)
            {
                First = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
            }
            Length++;
        }

        public ColorNode? Pop()
        {
            if (First == null)
            {
                return null;
            }
            ColorNode poppedNode = First;
            First = First.Next;
            poppedNode.Next = null;
            Length--;
            return poppedNode;
        }

        public ColorNode? Peek()
        {
            return First;
        }

        public int Depth()
        {
            int count = 0;
            ColorNode? current = First;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void nextColor(string color)
        {
            while (First != null && First.Color != color)
            {
                Pop();
            }
        }

        public void printList() { 
        
        
        }
    }
}
