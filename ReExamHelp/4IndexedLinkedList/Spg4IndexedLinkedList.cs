using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReExamHelp.Model;

namespace ReExamHelp._4IndexedLinkedList
{
    public class Spg4IndexedLinkedList
    {
        public NumberNode? Head;
        int Count = 0;
        public bool InsertOnIndex(int number, int index) {
            NumberNode newNode = new NumberNode(number);
            if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                Count++;
                return true;
            }
            if (Head == null) {
                return false;
            }
            NumberNode current = Head;
            int i = 0;
            while (i < index-1 && current.Next != null) {
                current = current.Next;
                i++;
            }
            if (i == index-1) {
                newNode.Next = current.Next;
                current.Next = newNode;
                Count++;
                return true;
            }
            return false;
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

        public int contains(int value) {
            NumberNode? current = Head;
            int i = 0;
            while (current != null) {
                if (current.Number == value) {
                    return i;
                }
                i++;
                current = current.Next;
            }
            return -1;
        }

        public Spg4IndexedLinkedList SubList(int startIndex, int endIndex) {
            Spg4IndexedLinkedList newList = new();
            NumberNode current = Head;
            for (int i = 0; i < startIndex; i++) {
                current = current.Next;
            }
            for(int i = 0; i < endIndex-startIndex; i++)
            {
                newList.InsertOnIndex(current.Number, i);
                current = current.Next;
            }
            return newList;
        }

        public string printList() {
            string result = "[";
            NumberNode? current = Head;
            while (current != null) {
                result += $"{current.Number}, ";
                current = current.Next;
            }
            result += "]";
            return result;
        }

//        Spg4IndexedLinkedList spg4 = new();
//        spg4.InsertOnIndex(1, 0);
//spg4.InsertOnIndex(2, 1);
//spg4.InsertOnIndex(4, 2);
//spg4.InsertOnIndex(32, 0);
//spg4.InsertOnIndex(8, 4);
//Console.WriteLine(spg4.printList());
//Console.WriteLine($"Listen indeholder 4 på index : {spg4.contains(4)}");
//Console.WriteLine($"Listen indeholder 1 på index : {spg4.contains(1)}");
//Console.WriteLine($"Listen indeholder 52 på index : {spg4.contains(52)}");
//spg4.RemoveNode(4);
//Console.WriteLine(spg4.printList());
//Console.WriteLine($"Listen indeholder 4 på index : {spg4.contains(4)}");
//spg4.InsertOnIndex(5, 4);
//spg4.InsertOnIndex(55, 4);
//spg4.InsertOnIndex(555, 4);
//spg4.InsertOnIndex(111, 4);
//spg4.InsertOnIndex(11, 4);
//spg4.InsertOnIndex(1, 4);
//spg4.InsertOnIndex(444, 4);
//spg4.InsertOnIndex(4, 4);
//spg4.InsertOnIndex(44, 4);
//spg4.InsertOnIndex(8444, 4);
//Console.WriteLine(spg4.printList());
//Spg4IndexedLinkedList sublist = spg4.SubList(3, 8);
//        Console.WriteLine(sublist.printList());
    }
}
