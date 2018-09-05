using System;
using System.Runtime.Serialization;

namespace AbpCore
{
    [Serializable]
    public class AbpException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public AbpException()
        {
        }

        public AbpException(string message) : base(message)
        {
        }

        public AbpException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AbpException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}