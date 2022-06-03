namespace ShortestPath.Core.Extensions;

public static class IntExtensions
{
    public static bool IsBetween(this int value, int min, int max)
        => value >= min && value <= max;
}