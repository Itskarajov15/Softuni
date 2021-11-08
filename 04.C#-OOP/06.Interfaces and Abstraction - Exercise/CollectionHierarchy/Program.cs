using CollectionHierarchy.Implementations;
using CollectionHierarchy.Interfaces;
using System;
using System.Text;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var lineOfStrings = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var amountOfRemoveOperations = int.Parse(Console.ReadLine());

            Console.WriteLine(OutputFromAddOperation(addCollection, lineOfStrings));
            Console.WriteLine(OutputFromAddOperation(addRemoveCollection, lineOfStrings));
            Console.WriteLine(OutputFromAddOperation(myList, lineOfStrings));

            Console.WriteLine(OutputFromRemoveOperation(addRemoveCollection, amountOfRemoveOperations));
            Console.WriteLine(OutputFromRemoveOperation(myList, amountOfRemoveOperations));
        }

        private static string OutputFromRemoveOperation(IRemovableCollection collection, int amountOfRemoveOperations)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < amountOfRemoveOperations; i++)
            {
                sb.Append($"{collection.Remove()} ");
            }

            return sb.ToString().TrimEnd();
        }

        public static string OutputFromAddOperation(IAddableCollection collection, string[] lineOfStrings)
        {
            var sb = new StringBuilder();

            foreach (var element in lineOfStrings)
            {
                sb.Append($"{collection.Add(element)} ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
