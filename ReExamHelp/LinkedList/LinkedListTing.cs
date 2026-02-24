using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp.LinkedList
{
    public class LinkedListTing
    {
        public PersonNode? head { get; set; }

        public void insertFirst(string name, int age) {
            PersonNode newNode = new PersonNode(age, name);
            newNode.Next = head;
            head = newNode;
        }

        public bool insertLast(string name, int age) {
            PersonNode newNode = new PersonNode(age, name);
            PersonNode currentNode = head;
            if (currentNode == null) {
                head = newNode;
                return true;
            }
            while (currentNode.Next != null) {
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;
            return true;
        }

        public bool removeLast() {
            if (head == null) {
                return false;
            }
            if (head.Next == null) {
                head = null;
                return true;
            }
            PersonNode current = head.Next;
            PersonNode previous = head;

            while (current.Next != null) {
                previous = current;
                current = current.Next;
            }
            previous.Next = null;
            return true;
        }

        public int averageAge() {
            if (head == null) {
                return -1;
            }
            PersonNode current = head;
            int accAge = head.Age;
            int numberOfPersons = 1;
            while (current.Next != null) {
                current = current.Next;
                accAge += current.Age;
                numberOfPersons++;
            }
            return accAge/numberOfPersons;
        }

        public string oldestPerson() {
            if (head == null) {
                return "Listen er tom der er ikke nogen som er ædldst";
            }
            PersonNode current = head;
            PersonNode oldestSoFar = head;
            while (current.Next != null) {
                current = current.Next;
                if (current.Age > oldestSoFar.Age) {
                    oldestSoFar = current;
                }
            }
            return oldestSoFar.Name;
        }


    }
}
