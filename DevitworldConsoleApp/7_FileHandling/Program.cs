using System;
using System.IO;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. File Stream Example
            Console.WriteLine("## 1. FileStream Example ##");
            string filePath = "1_FileStream.txt";

            // Create and write to a file
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, FileStream!");
                fileStream.Write(data, 0, data.Length);
            }

            // Read from the file
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(buffer));
            }

            // 2. StreamReader & StreamWriter Example
            Console.WriteLine("\r\n## 2. StreamReader & StreamWriter Example ##");
            filePath = "2_StreamReader_StreamWriter.txt";

            // Write to a file using StreamWriter
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Hello, StreamWriter!");
            }

            // Read from a file using StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }

            // 3. Directory & DirectoryInfo Example
            Console.WriteLine("\r\n## 3. Directory & DirectoryInfo Example ##");

            string directoryPath = "exampleDir";

            // Create a directory
            Directory.CreateDirectory(directoryPath);

            // Get and display all files in the directory
            foreach (var file in Directory.GetFiles(directoryPath))
            {
                Console.WriteLine(file);
            }

            // 4. File & FileInfo Example
            Console.WriteLine("\r\n## 4. File & FileInfo Example ##");

            string sourcePath = "source.txt";
            string destinationPath = "destination.txt";

            // Create a file and write content
            File.WriteAllText(sourcePath, "This is a test file.");

            // Copy the file
            File.Copy(sourcePath, destinationPath, true);

            // Move the file
            File.Move(destinationPath, "newDestination.txt");

            // 5. Path Example
            Console.WriteLine("\r\n## 5. Path Example ##");

            filePath = "5_Path.txt";

            // Get directory name
            Console.WriteLine("Directory Name: " + Path.GetDirectoryName(filePath));

            // Get file extension
            Console.WriteLine("File Extension: " + Path.GetExtension(filePath));

            // Get file name
            Console.WriteLine("File Name: " + Path.GetFileName(filePath));

            // Get file name without extension
            Console.WriteLine("File Name without Extension: " + Path.GetFileNameWithoutExtension(filePath));
        }
    }
}