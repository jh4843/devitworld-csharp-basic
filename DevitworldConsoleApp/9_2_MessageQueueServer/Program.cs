using System;
using System.Messaging;

// https://endev.tistory.com/70

class MessageQueueReceiver
{
    static void Main(string[] args)
    {
        MessageQueue mq = new MessageQueue(@".\Private$\TestQueue");
        mq.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });

        while (true)
        {
            var message = mq.Receive();
            string messageBody = message.Body.ToString();
            Console.WriteLine("Received from queue: " + messageBody);
        }
    }
}