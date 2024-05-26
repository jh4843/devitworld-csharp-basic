using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace SharedMemoryWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello from client!";

            while (message != "exit")
            {
                // Create Named Pipe Client Stream with the name "devitworld_pipe"
                using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "devitworld_pipe", PipeDirection.Out))
                {
                    try
                    {
                        // Connect to the server
                        Task connectTask = Task.Run(() => pipeClient.Connect());
                        if (connectTask.Wait(TimeSpan.FromSeconds(3)))
                        {
                            Console.WriteLine("Connected to server.");
                            Console.Write("Enter message: ");
                            message = Console.ReadLine();
                            byte[] buffer = Encoding.UTF8.GetBytes(message);
                            pipeClient.Write(buffer, 0, buffer.Length); // Send message to server
                            Console.WriteLine("Message sent to server.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to connect to server. (Timeout)");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to connect to server. " + ex.Message);
                    }
                }
            }
            
        }
    }
}