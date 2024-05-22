using System;
using System.IO.Pipes;
using System.Text;

namespace SharedMemoryReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "";

            while (message != "shutdown")
            {
                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("devitworld_pipe", PipeDirection.In))
                {
                    Console.WriteLine("Named pipe server started.");
                    pipeServer.WaitForConnection();
                    Console.WriteLine("Client connected.");
                    byte[] buffer = new byte[256];
                    int bytesRead = pipeServer.Read(buffer, 0, buffer.Length);
                    message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received from client: " + message);
                }
            }
        }
    }
}