using System;
using System.Runtime.Serialization;

namespace RPXLib
{
    [Serializable]
    public class RPXAuthenticationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public RPXAuthenticationException()
        {
        }

        public RPXAuthenticationException(string message) : base(message)
        {
        }

        public RPXAuthenticationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RPXAuthenticationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}