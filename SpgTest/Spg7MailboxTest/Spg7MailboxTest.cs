using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReExamHelp._7MailboxTest;

namespace SpgTest.Spg7MailboxTest
{
    [TestClass]
    public class Spg7MailboxTest
    {
        [TestMethod]
        public void receiveMailTest() {
            MailboxTest mailbox = new();

            mailbox.receiveMail("Henning", "Skal vi ned på den brune i aften?");
            mailbox.receiveMail("Lotte", "Jeg er Hønen");

            Assert.AreEqual(2, mailbox.mails.Count);

            mailbox.receiveMail("Bjarne", "Du skylder en omgang");

            Assert.AreEqual(3, mailbox.mails.Count);

        }

        [TestMethod]
        public void readMailTest() {
            MailboxTest mailbox = new();

            mailbox.receiveMail("Henning", "Skal vi ned på den brune i aften?");
            mailbox.receiveMail("Lotte", "Jeg er Hønen");
            mailbox.receiveMail("Bjarne", "Du skylder en omgang");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void priceTest() {
            MailboxTest m = new();
            Assert.AreEqual(40, m.price(2));
            Assert.AreEqual(80, m.price(4));
            Assert.AreEqual(95, m.price(5));
            Assert.AreEqual(110, m.price(6));
        }
        
    }
}
