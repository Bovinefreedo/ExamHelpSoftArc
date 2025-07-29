using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp._7MailboxTest
{
    public class Mail
    {
        public int id { get; set; }
        public string sender { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public bool read { get; set; }

        public Mail(int id, string sender, string message) {
            this.id = id;
            this.sender = sender;
            this.message = message;
            read = false;
        }
    }
}
