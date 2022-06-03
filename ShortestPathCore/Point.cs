namespace ShortestPath.Core;

public readonly struct Point : IEqualityComparer<Point>
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int Y { get; }

    public int X { get; }

    public bool Equals(Point x, Point y)
    {
        return x.Y == y.Y && x.X == y.X;
    }

    public int GetHashCode(Point obj)
    {
        return HashCode.Combine(obj.Y, obj.X);
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }
}