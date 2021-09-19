using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            int startingIndexOtTheFileName = path.LastIndexOf('\\');
            int endingIndexOtTheFileName = path.LastIndexOf('.');

            string fileName = path.Substring(startingIndexOtTheFileName + 1, endingIndexOtTheFileName -
                startingIndexOtTheFileName - 1);
            string extension = path.Substring(endingIndexOtTheFileName + 1);

            Console.WriteLine(text.Length);
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}