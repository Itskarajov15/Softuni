using System;
using System.IO;

namespace StreamsUnderneath
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream("../../../students.txt", FileMode.Open))
            {
                byte[] buffer = new byte[2];
                Console.WriteLine($"Stream position {stream.Position}");

                for (int i = 0; i < stream.Length / buffer.Length; i++)
                {
                    stream.Read(buffer, 0, 2);

                    using (FileStream writerStream = new FileStream($"../../../students - {i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        writerStream.Write(buffer, 0, 2);
                    }
                }

                Console.WriteLine($"Stream position {stream.Position}");
            }
        }
    }
}
