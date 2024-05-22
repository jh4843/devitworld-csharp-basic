using System;
using System.IO.MemoryMappedFiles;
using System.Text;

class SharedMemoryReader
{
    static void Main(string[] args)
    {
        using (var mmf = MemoryMappedFile.OpenExisting("testmap"))
        {
            using (var accessor = mmf.CreateViewAccessor())
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    accessor.ReadArray(0, buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine("Received from shared memory: " + message);
                        // 메모리 초기화
                        byte[] clearBuffer = new byte[1024];
                        accessor.WriteArray(0, clearBuffer, 0, clearBuffer.Length);
                    }
                    System.Threading.Thread.Sleep(1000); // 1초 대기
                }
            }
        }
    }
}
