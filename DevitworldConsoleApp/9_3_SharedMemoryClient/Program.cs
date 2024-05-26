using System;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace SharedMemoryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open existing shared memory with the name "devitworld_shared_memory"
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("devitworld_shared_memory"))
                {
                    string message = "Hello from client!";

                    while (message != "exit")
                    {
                        Console.Write("Enter message: ");
                        message = Console.ReadLine();
                        byte[] buffer = Encoding.UTF8.GetBytes(message);

                        using (var accessor = mmf.CreateViewAccessor())
                        {
                            accessor.WriteArray(0, buffer, 0, buffer.Length);
                            Console.WriteLine("Message sent to server.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to open shared memory. " + ex.Message);
            }
        }
    }
}
