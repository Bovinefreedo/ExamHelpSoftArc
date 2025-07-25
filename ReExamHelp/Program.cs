using ReExamHelp._1Queue;
using ReExamHelp._4IndexedLinkedList;
using ReExamHelp._5CountryArray;
using ReExamHelp._6HashTableChaning;

Spg1Queue queue = new();

queue.Enqueue("Grøn");
queue.Enqueue("Grøn");
queue.Enqueue("Gul");
queue.Enqueue("Grøn");
queue.Enqueue("Rød");

Console.WriteLine(queue.printList());
Console.WriteLine(queue.Dequeue().Color);
Console.WriteLine(queue.Dequeue().Color);
Console.WriteLine(queue.Dequeue().Color);
Console.WriteLine(queue.printList());
