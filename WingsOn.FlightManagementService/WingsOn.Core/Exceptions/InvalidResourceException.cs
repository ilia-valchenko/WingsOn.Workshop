﻿using System;

namespace WingsOn.Core.Exceptions
{
    public sealed class InvalidResourceException : Exception
    {
        public InvalidResourceException() : base() { }

        public InvalidResourceException(string message) : base(message) { }

        public InvalidResourceException(string message, Exception innerException) : base(message, innerException) { }
    }
}