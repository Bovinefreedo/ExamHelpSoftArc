using ReExamHelp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp._6HashTableChaning
{
    public class Spg6HashTable
    {
        NumberLinkedList[] hashTable;
        int size;
        public Spg6HashTable(int size) {
            this.size = size;
            hashTable = new NumberLinkedList[size];
            for (int i = 0; i < size; i++) {
                hashTable[i] = new NumberLinkedList();
            }
        }

        public void insertNumber(int number) {
            hashTable[number % size].addFirst(number);
        }

        public bool contains(int number) {
            return hashTable[number % size].contains(number);
        }

        public bool delete(int number)
        {
            return hashTable[number % size].RemoveNode(number);
        }

        public void printHashTable() {
            foreach (var h in hashTable) {
                Console.WriteLine(h.printList());
            }
        }
    }
}
