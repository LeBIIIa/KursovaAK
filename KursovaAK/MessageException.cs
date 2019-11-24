using System;

namespace Assembler
{
    [Serializable]
    public class MessageException : Exception
    {
        public MessageException( string message ) : base(message)
        {
        }

        public MessageException()
        {
        }

        public MessageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MessageException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
