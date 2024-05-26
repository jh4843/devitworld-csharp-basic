using System;
using System.Messaging;

namespace MessageQueueReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string queuePath = @".\Private$\devitworld_queue";
            if (!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
            }

            using (MessageQueue messageQueue = new MessageQueue(queuePath))
            {
                while (true)
                {
                    Message message = messageQueue.Receive();
                    message.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                    string msg = message.Body.ToString();
                    Console.WriteLine("Received message: " + msg);

                    if (msg == "shutdown")
                        break;
                }
            }
        }
    }
}