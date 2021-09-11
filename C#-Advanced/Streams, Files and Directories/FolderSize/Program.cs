using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = Console.ReadLine();

            var files = Directory.GetFiles(folderPath);

            long fileSizes = 0;

            foreach (var filePath in files)
            {
                FileInfo file = new FileInfo(filePath);

                fileSizes += file.Length;
            }

            Console.WriteLine(fileSizes / 1024.0);
        }
    }
}
