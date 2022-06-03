using ShortestPath.Core;

namespace ShortestPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new[,]
            {
                { true, true, true, true, true, true, true },
                { true, true, true, false, false, false, false },
                { true, true, true, true, false, true, false },
                { false, false, false, true, false, false, false },
                { true, true, false, true, true, true, false },
                { true, true, false, false, false, false, false },
                { true, true, true, true, true, true, true }
            };
            var source = new Point(3, 0);
            var destination = new Point(2, 4);

            var shortestPath = PathFinder.FindShortestPath(matrix, source, destination);

            Console.WriteLine($"1) Shortest path length: {shortestPath}");

            Console.ReadLine();
        }
    }
}