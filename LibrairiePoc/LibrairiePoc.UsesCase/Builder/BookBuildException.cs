using System.Runtime.Serialization;

namespace LibrairiePoc.UsesCase.Builder;

[Serializable]
public class BookBuildException : Exception
{
    public BookBuildException()
    {
    }

    public BookBuildException(string? message) : base(message)
    {
    }

    public BookBuildException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected BookBuildException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}