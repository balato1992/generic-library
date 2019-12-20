using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GenericModel.Other
{
    public class MessageException : Exception
    {
        public MessageException() { }

        public MessageException(string message) : base(message) { }

        public MessageException(string message, Exception inner) : base(message, inner) { }

        // This constructor is needed for serialization.
        protected MessageException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.                
        }
    }
}
