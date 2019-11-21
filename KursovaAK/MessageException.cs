using System;

namespace Assembler
{
    public class MessageException : Exception
    {
        public MessageException( string message ) : base(message)
        {
        }
    }
}
