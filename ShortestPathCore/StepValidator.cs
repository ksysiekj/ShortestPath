using ShortestPath.Core.Extensions;

namespace ShortestPath.Core;

public sealed class StepValidator
{
    private readonly int _xRange;
    private readonly int _yRange;
    private readonly bool[,] _matrix;

    public StepValidator(bool[,] matrix)
    {
        _xRange = matrix.GetLength(0) - 1;
        _yRange = matrix.GetLength(1) - 1;
        _matrix = matrix;
    }

    public bool IsStepValid(Point point)
    {
        return point.X.IsBetween(0, _xRange) && point.Y.IsBetween(0, _yRange)
                                             && !_matrix[point.X, point.Y];
    }
}