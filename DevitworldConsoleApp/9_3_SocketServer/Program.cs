using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    class Program
    {
        static void Main()
        {
            // Set the IP address and port
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8080;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Bind the socket to the local endpoint and listen for incoming connections
                listener.Bind(localEndPoint);
                listener.Listen(10); // 10 is the maximum length of the pending connections queue

                Console.WriteLine("Start Server. Waiting for a connection...");

                // Accept the connection
                Socket handler = listener.Accept();
                string data = null;
                byte[] bytes = new byte[1024]; // Data buffer

                // Receive the data
                int bytesRec = handler.Receive(bytes); // The number of bytes received
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec); // Convert bytes to string
                Console.WriteLine("Receive Data: {0}", data);

                // Send response to the client
                byte[] msg = Encoding.ASCII.GetBytes("Received your message.");
                handler.Send(msg);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Close the server.");
        }
    }
}