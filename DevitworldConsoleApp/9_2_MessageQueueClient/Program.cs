using System;
using System.Messaging;

class MessageQueueSender
{
    static void Main(string[] args)
    {
        if (!MessageQueue.Exists(@".\Private$\TestQueue"))
        {
            MessageQueue.Create(@".\Private$\TestQueue");
        }

        MessageQueue mq = new MessageQueue(@".\Private$\TestQueue");
        mq.Send("Hello from client!");
        Console.WriteLine("Message sent to queue.");
    }
}
