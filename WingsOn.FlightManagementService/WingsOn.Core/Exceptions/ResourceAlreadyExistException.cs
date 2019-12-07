using System;

namespace WingsOn.Core.Exceptions
{
    public sealed class ResourceAlreadyExistException : Exception
    {
        public ResourceAlreadyExistException() : base() { }

        public ResourceAlreadyExistException(string message) : base(message) { }

        public ResourceAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}