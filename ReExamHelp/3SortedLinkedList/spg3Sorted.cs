using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReExamHelp.Model;

namespace ReExamHelp._3SortedLinkedList
{
    public class spg3Sorted
    {
        public NumberNode? Head { get; set; } = null;

        public void InsertSorted(int number)
        {
            NumberNode newNode = new NumberNode(number);
            if (Head == null || Head.Number >= number)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                NumberNode current = Head;
                while (current.Next != null && current.Next.Number < number)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        public bool RemoveNode(int value)
        {
            if (Head == null)
            {
                return false;
            }
            NumberNode? current = Head;
            while (current.Next != null)
            {
                if (current.Next.Number == value)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int Length()
        {
            int count = 0;
            NumberNode? current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public bool contains(int value)
        {
            NumberNode? current = Head;
            while (current != null && current.Number> value)
            {
                if (current.Number == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}
