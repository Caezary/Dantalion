using System.Runtime.Serialization;

namespace Dantalion.Library;

public class MarkdownGenerationException : Exception
{
    public static void ThrowIfEmpty(string text, string fieldName)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new MarkdownGenerationException($"{fieldName} should not be empty");
        }
    }
 
    public static void ThrowIfLowerBoundExceeded(uint value, uint lowerBound, string fieldName)
    {
        if (value < lowerBound)
        {
            throw new MarkdownGenerationException($"{fieldName} should not be less than {lowerBound}");
        }
    }

    public static void ThrowIfHigherBoundExceeded(uint value, uint higherBound, string fieldName)
    {
        if (value > higherBound)
        {
            throw new MarkdownGenerationException($"{fieldName} should not be more than {higherBound}");
        }
    }

    public MarkdownGenerationException()
    {
    }

    protected MarkdownGenerationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MarkdownGenerationException(string message) : base(message)
    {
    }

    public MarkdownGenerationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}