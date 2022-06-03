using ShortestPath.Core.Exceptions;

namespace ShortestPath.Core;

public sealed class PathFinder
{
    private static readonly int[,] allowedMovesMatrix = {
        { -1, 0 },
        { 1, 0 },
        { 0, -1 },
        { 0, 1 }
    };

    public static int FindShortestPath(bool[,] matrix, Point source, Point destination)
    {
        if (matrix == null)
            throw new InputValidationException("Matrix cannot be null");

        if (matrix.Length == default)
            throw new InputValidationException("Empty matrix");

        var width = matrix.GetLength(0);
        var height = matrix.GetLength(1);

        if (source.X >= width || source.Y >= height)
            throw new InputValidationException("Source point is not withing the matrix");

        if (destination.X >= width || destination.Y >= height)
            throw new InputValidationException("Destination point is not withing the matrix");

        if (matrix[source.X, source.Y])
            throw new InputValidationException("Source point is not in valid state (is true)");

        if (matrix[destination.X, destination.Y])
            throw new InputValidationException("Destination point is not in valid state (is true)");

        if (source.Equals(destination))
            return 0;

        var stepValidator = new StepValidator(matrix);

        var visitedPoints = new bool[width, height];

        visitedPoints[source.X, source.Y] = true;

        var routeQueue = new Queue<RouteInfo>();

        var sourceRouteInfo = new RouteInfo(source, 1);
        routeQueue.Enqueue(sourceRouteInfo); 

        while (routeQueue.Count != 0)
        {
            var currentRouteInfo = routeQueue.Peek();
            var currentPoint = currentRouteInfo.Point;

            if (currentPoint.Equals(destination))
            {
                return currentRouteInfo.Distance;
            }

            routeQueue.Dequeue();

            var availableNextPoints = GetAvailableNextMovePoints(currentRouteInfo.Point, stepValidator, visitedPoints);

            foreach (var adjacentPoint in availableNextPoints)
            {
                visitedPoints[adjacentPoint.X, adjacentPoint.Y] = true;
                
                var adjacentRouteInfo = new RouteInfo(adjacentPoint, currentRouteInfo.Distance + 1);
                routeQueue.Enqueue(adjacentRouteInfo);
            }
        }

        return Consts.NO_PATH_EXISTS;
    }

    private static IEnumerable<Point> GetAvailableNextMovePoints(Point point, StepValidator stepValidator,
        bool[,] alreadyVisitedPoints)
    {
        for (var allowedMove = 0; allowedMove < allowedMovesMatrix.GetLength(0); allowedMove++)
        {
            var newPoint = new Point(point.X + allowedMovesMatrix[allowedMove, 0],
                point.Y + allowedMovesMatrix[allowedMove, 1]);

            if (stepValidator.IsStepValid(newPoint) 
                && !alreadyVisitedPoints[newPoint.X, newPoint.Y])
            {
                yield return newPoint;
            }
        }
    }
}