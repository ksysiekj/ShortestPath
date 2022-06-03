namespace ShortestPath.Core.Exceptions;

[Serializable]
public sealed class InputValidationException : Exception
{
    public InputValidationException(string? message) :
        base(message)
    {

    }
}