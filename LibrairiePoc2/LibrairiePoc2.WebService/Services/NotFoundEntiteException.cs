using System.Runtime.Serialization;

namespace LibrairiePoc2.WebService
{
    [Serializable]
    public class NotFoundEntiteException : Exception
    {
        public NotFoundEntiteException()
        {
        }

        public NotFoundEntiteException(string? message) : base(message)
        {
        }

        public NotFoundEntiteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundEntiteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}