using System;

namespace WingsOn.Core.Exceptions
{
    /// <summary>
    /// The exception that indicates that a resource already exists.
    /// </summary>
    public sealed class ResourceNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        public ResourceNotFoundException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ResourceNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ResourceNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}