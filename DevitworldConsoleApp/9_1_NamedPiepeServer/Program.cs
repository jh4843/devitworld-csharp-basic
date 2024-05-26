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
                // Create Named Pipe Server Stream with the name "devitworld_pipe"
                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("devitworld_pipe", PipeDirection.In))
                {
                    Console.WriteLine("Named pipe server started.");
                    pipeServer.WaitForConnection(); // Wait for client connection
                    Console.WriteLine("Client connected.");
                    byte[] buffer = new byte[256];
                    int bytesRead = pipeServer.Read(buffer, 0, buffer.Length);  // Read message from client
                    message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received from client: " + message);
                }
            }
        }
    }
}