using System;
using System.Runtime.Serialization;

namespace CourseWork.Shared.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException()
        {
        }

        protected AuthorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        
#nullable enable
        public AuthorNotFoundException(string? message) : base(message)
        {
        }

        public AuthorNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
#nullable disable
    }
}