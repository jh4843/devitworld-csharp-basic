using System;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;

namespace SharedMemoryServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateNew("devitworld_shared_memory", 1024))
            {
                Console.WriteLine("Shared memory server started.");

                while (true)
                {
                    // Read message from client
                    using (var accessor = mmf.CreateViewAccessor())
                    {
                        byte[] buffer = new byte[1024];
                        accessor.ReadArray(0, buffer, 0, buffer.Length);
                        string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                        Console.WriteLine("Received from client: " + message);

                        if (message == "shutdown")
                        {
                            break;
                        }

                        // make empty the shared memory
                        accessor.WriteArray(0, new byte[1024], 0, 1024);
                    }

                    Thread.Sleep(2000);
                }
            }
        }
    }
}