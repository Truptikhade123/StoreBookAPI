using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHub.Infrastructure.Exceptions
{
    public class CustomExceptions :Exception
    {
        public CustomExceptionCodes ExceptionCode { get; set; }
        public SqlExceptionCodes SqlExceptionCode { get; set; }
        public string Description { get; set; } = ""
        public CustomExceptions(CustomExceptionCodes exceptionCode, string description) : base("ExceptionCode: " + exceptionCode + " ExceptionDescription: " + description)
        {
            ExceptionCode = exceptionCode;
            Description = description;
        }
        public CustomExceptions(int exceptionCode, string description) : base("ExceptionCode: " + exceptionCode + " ExceptionDescription: " + description)
        {
            SqlExceptionCode = (SqlExceptionCodes)exceptionCode;
            Description = description;
        }

        protected CustomExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("ExceptionCode", ExceptionCode);
            info.AddValue("Description", Description);
            base.GetObjectData(info, context);
        }
    }

    public enum CustomExceptionCodes
    {
        UnableToCreate = 2
    }
    public enum SqlExceptionCodes
    {
        UnableToCreate = 2
    }

    public static class CustomExceptionMessage
    {
        public readonly static string UnableToCreateMessage = "There was an error";
       
    }
}
