using ShortestPath.Core;
using NUnit.Framework;
using ShortestPath.Core.Exceptions;

namespace ShortestPath.UnitTests
{
    public class PathFinderTests
    {
        [TestCaseSource(nameof(ValidTestCases))]
        public void PathFinder_ValidInput_FindsShortestPath(bool[,] matrix, Point source, Point destination, int expectedPathLength)
        {
            var path = PathFinder.FindShortestPath(matrix, source, destination);

            Assert.AreEqual(expectedPathLength, path);
        }

        [TestCaseSource(nameof(InValidTestCases))]
        public void PathFinder_InvalidInput_ThrowsExceptions(bool[,] matrix, Point source, Point destination, string exceptionMessage)
        {
            Assert.Throws<InputValidationException>(() => PathFinder.FindShortestPath(matrix, source, destination),
                exceptionMessage);
        }

        private static object[] InValidTestCases =
        {
            new object[]
            {
                new bool[,] { },
                new Point(1, 0),
                new Point(3, 6),
                "Empty matrix"
            },

            new object[]
            {
                new[,]
                {
                    { false, false, false },
                    { true, true, false },
                    { false, true, false },
                },
                new Point(0, 12),
                new Point(0, 2),
                "Source point is not withing the matrix"
            },

            new object[]
            {
                new[,]
                {
                    { false, false, false },
                    { true, true, false },
                    { false, true, false },
                },
                new Point(0, 0),
                new Point(0, 7),
                "Destination point is not withing the matrix"
            },

            new object[]
            {
                new[,]
                {
                    { false, false, false },
                    { true, true, false },
                    { false, true, false },
                },
                new Point(1, 0),
                new Point(0, 2),
                "Source point is not in valid state (is true)"
            },

            new object[]
            {
                new[,]
                {
                    { false, false, false },
                    { true, true, false },
                    { false, true, false },
                },
                new Point(0, 0),
                new Point(2, 1),
                "Destination point is not in valid state (is true)"
            },

            new object[]
            {
                null,
                new Point(1, 0),
                new Point(3, 6),
                "Matrix cannot be null"
            }
        };

        private static object[] ValidTestCases =
        {
            new object[]
            {
                new[,]
                {
                    { true, true, false, false, false, false, false, false, false, false },
                    { false, false, false, true, true, true, false, true, true, false },
                    { false, true, false, true, true, true, false, true, true, true },
                    { false, true, false, false, false, false, false, true, true, false },
                    { false, true, false, true, true, false, true, true, true, false },
                    { false, true, false, true, true, false, true, true, true, true },
                    { false, true, false, true, true, false, true, true, true, true },
                    { false, true, true, true, false, false, true, true, true, true },
                    { false, false, false, false, false, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true, true, true },
                },
                new Point(1, 0),
                new Point(3, 6),
                9
            },


            new object[]
            {
                new[,]
                {
                    { false, true, false, false, false, false, true, false, false, true },
                    { false, true, false, true, false, false, false, true, false, true },
                    { false, false, false, true, false, false, true, false, true, true },
                    { true, true, true, true, false, true, true, true, true, true },
                    { false, false, false, true, false, false, false, true, false, false },
                    { false, true, false, false, false, false, true, false, true, false },
                    { false, true, true, true, true, true, true, true, true, true },
                    { false, true, false, false, false, false, true, false, false, true },
                    { false, false, true, true, true, true, false, true, true, true }
                },
                new Point(0, 0),
                new Point(3, 4),
                12
            },

            new object[]
            {
                new[,]
                {
                    { false, false, true, false },
                    { false, false, true, false },
                    { false, false, true, false },
                    { false, false, true, false }
                },
                new Point(1, 1),
                new Point(0, 3),
                -1
            },

            new object[]
            {
                new[,]
                {
                    { true, true, true, true, true, true, true },
                    { true, true, false, false, false, true, true },
                    { true, true, false, true, false, true, true },
                    { false, false, false, true, false, false, false },
                    { true, true, false, true, true, true, false },
                    { true, true, false, false, false, false, false },
                    { true, true, true, true, true, true, true }
                },
                new Point(3, 0),
                new Point(3, 5),
                10
            },

            new object[]
            {
                new[,]
                {
                    { true, true, true, true, true, true, true },
                    { true, true, true, false, false, false, false },
                    { true, true, true, true, false, true, false },
                    { false, false, false, true, false, false, false },
                    { true, true, false, true, true, true, false },
                    { true, true, false, false, false, false, false },
                    { true, true, true, true, true, true, true }
                },
                new Point(3, 0),
                new Point(2, 4),
                14
            },

            new object[]
            {
                new[,]
                {
                    { false, false, false },
                    { true, true, false },
                    { false, true, false },
                },
                new Point(0, 0),
                new Point(2, 2),
                5
            },

            new object[]
            {
                new[,]
                {
                    { false, false, false },
                    { true, true, false },
                    { false, true, false },
                },
                new Point(0, 2),
                new Point(0, 2),
                0
            }
        };
    }
}