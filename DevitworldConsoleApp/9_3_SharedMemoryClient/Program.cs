using System;
using System.IO.MemoryMappedFiles;
using System.Text;

class SharedMemoryWriter
{
    static void Main(string[] args)
    {
        using (var mmf = MemoryMappedFile.CreateNew("testmap", 1024))
        {
            using (var accessor = mmf.CreateViewAccessor())
            {
                string message = "Hello from client!";
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                accessor.WriteArray(0, buffer, 0, buffer.Length);
                Console.WriteLine("Message written to shared memory.");
            }
        }
    }
}