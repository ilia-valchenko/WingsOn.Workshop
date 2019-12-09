using System;

namespace WingsOn.Core.Exceptions
{
    /// <summary>
    /// The exception that indicates that a resource already exists.
    /// </summary>
    public sealed class ResourceAlreadyExistException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAlreadyExistException"/> class.
        /// </summary>
        public ResourceAlreadyExistException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ResourceAlreadyExistException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ResourceAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}