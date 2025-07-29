using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReExamHelp._7MailboxTest
{
    public class MailboxTest
    {
        public List<Mail> mails = new();

        public void receiveMail(string sender, string message) {
            int id = mails.Count > 0 ? mails[mails.Count - 1].id + 1 : 0;
            Mail m = new Mail(id, sender, message);
            mails.Add(m);
        }

        public string readEmail(int id){
            string result = string.Empty;
            Mail? mail = mails.FirstOrDefault(m => m.id == id);
            if (mail == null)
            {
                result = "message not found";
            } 
            else {
                result = $"sender: {mail.sender}, message: {mail.message}";
                mail.read = true;
            }
            return result;
        
        }

        public bool deleteEmail(int id) {
            int mailsBefore = mails.Count;
            mails.RemoveAll(x => x.id == id);
            if (mails.Count < mailsBefore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> unreadEmails() {
            return mails.Where(x => !x.read).Select(x => x.id).ToList();
        }

        public void markAllAsRead() {
            mails.Where(x => !x.read).Select(x => x.read = true);
        }

        //IKKE EN DEL AF OPGAVEN
        public int price(int person) {
            int price = 0;
            if (person < 5)
            {
                price = person * 20;
            }
            else {
                price = 80 + 15 * (person - 4);
            }
            return price;
        }
    }
}
