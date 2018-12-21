using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChapter5
{
        public abstract class MessageStrategy
        {
            public abstract void SendMessage(Message message);
        }

        public class EmailMessage : MessageStrategy
        {
            public override void SendMessage(Message message)
            {
                //Send Email
            }
        }

        public class SMSMessage : MessageStrategy
        {
            public override void SendMessage(Message message)
            {
                //Send SMS 
            }
        }

    public class MessageSender
    {
        private MessageStrategy _messageStrategy;
        public void SetMessageStrategy(MessageStrategy messageStrategy)
        {
            _messageStrategy = messageStrategy;
        }
            
        public void SendMessage(Message message)
        {
            _messageStrategy.SendMessage(message);
        }

    }
}
