using ReExamHelp._4IndexedLinkedList;
using ReExamHelp._5CountryArray;
using ReExamHelp._6HashTableChaning;

Spg6HashTable hashTable = new Spg6HashTable(5);

hashTable.insertNumber(2);
hashTable.insertNumber(5);
hashTable.insertNumber(1);
hashTable.insertNumber(3);
hashTable.insertNumber(22);
hashTable.insertNumber(261);
hashTable.insertNumber(23);
hashTable.insertNumber(23);
hashTable.insertNumber(1);
hashTable.insertNumber(2);
hashTable.insertNumber(275);
hashTable.insertNumber(2);

hashTable.printHashTable();

Console.WriteLine(hashTable.contains(2));