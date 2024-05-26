using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            // Set the IP address and port
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8080;
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket
            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Try to connect to the server
                sender.Connect(remoteEP);
                Console.WriteLine("Successfully connected to {0}", sender.RemoteEndPoint);

                // Send message to the server
                string message = "Hello Server!";
                byte[] msg = Encoding.ASCII.GetBytes(message);
                int bytesSent = sender.Send(msg);

                // Receive response from the server
                byte[] bytes = new byte[1024];
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine("Res receive: {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

                // Wait
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Close the client.");
        }
    }
}