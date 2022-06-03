namespace ShortestPath.Core;

readonly struct RouteInfo
{
    public RouteInfo(Point point, int distance)
    {
        Point = point;
        Distance = distance;
    }

    public Point Point { get; }

    public int Distance { get; }
}