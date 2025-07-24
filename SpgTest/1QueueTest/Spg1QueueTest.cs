using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReExamHelp.Model;
using ReExamHelp._1Queue;
using System.Collections;

namespace SpgTest._1QueueTest
{
    [TestClass]
    public class Spg1QueueTest
    {
        [TestMethod]
        public void EnqueueTest() {
            Spg1Queue queue = new();
            queue.Enqueue("Grøn");
            Assert.AreEqual("Grøn",queue.Head!.Color);
            queue.Enqueue("Gul");
            Assert.AreEqual("Gul", queue.Head.Next!.Color);
        }

        [TestMethod]
        public void DequeueTest() {
            Spg1Queue queue = new();
            queue.Enqueue("Grøn");
            queue.Enqueue("Gul");
            queue.Enqueue("Blå");
            ColorNode dequedNode = queue.Dequeue()!;
            Assert.AreEqual("Grøn", dequedNode.Color);
            dequedNode = queue.Dequeue()!;
            Assert.AreEqual("Gul", dequedNode.Color);
        }

        [TestMethod]
        public void peekTest() {
            Spg1Queue queue = new();
            queue.Enqueue("Grøn");
            Assert.AreEqual("Grøn", queue.Head!.Color);
            queue.Enqueue("Gul");
            Assert.AreEqual("Grøn", queue.Head!.Color);
            ColorNode dequedNode = queue.Dequeue()!;
            Assert.AreEqual("Gul", queue.Head!.Color);
        }

        [TestMethod]
        public void countTest() {
            Spg1Queue queue = new();
            queue.Enqueue("Grøn");
            Assert.AreEqual(1, queue.Count());
            queue.Enqueue("Gul");
            Assert.AreEqual(2, queue.Count());
            queue.Enqueue("Blå");
            Assert.AreEqual(3, queue.Count());
            queue.Dequeue();
            Assert.AreEqual(2, queue.Count());
        }
    }
}
