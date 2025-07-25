using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp.Model
{
    public class NumberLinkedList
    {
        public NumberNode? Head;
        int Count = 0;

        public void addFirst(int number) {
            NumberNode newNumber = new NumberNode(number);
            newNumber.Next = Head;
            Head = newNumber;
            Count++;
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
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public bool contains(int value)
        {
            NumberNode? current = Head;
            while (current != null)
            {
                if (current.Number == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public string printList()
        {
            string result = "[";
            NumberNode? current = Head;
            while (current != null)
            {
                result += $"{current.Number}, ";
                current = current.Next;
            }
            result += "]";
            return result;
        }

    }
}
