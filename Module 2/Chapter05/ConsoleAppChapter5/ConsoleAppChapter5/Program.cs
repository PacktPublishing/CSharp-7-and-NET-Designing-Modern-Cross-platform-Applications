using System;

namespace ConsoleAppChapter5
{
    class Program
    {
            static void Main(string[] args)
            {
            
                MessageSender sender = new MessageSender();
                sender.SetMessageStrategy(new EmailMessage());
                sender.SendMessage(new Message { MessageID = 1, MessageTo = "ovaismehboob@hotmail.com", MessageFrom = "ovaismehboob@hotmail.com", MessageBody = "Hello readers", MessageSubject = "Chapter 5" });
            }
    }


    public class MessageDispatcher
    {
        public const string SmtpAddress = "smpt.office365.com";
        public void SendEmail(string fromAddress, string toAddress, string subject, string body)
        {

        }


        public static int GetUserId(string userName)
        {
            //Get user ID from database by passing the username
            return -1;
        }

        public static void GetUserDocuments(int userID)
        {
            //Get list of documents by calling some API
         
        }

    }
}
