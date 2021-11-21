using PowerUtils.Net.Constants;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace PowerUtils.Validations.Exceptions
{
    /// <summary>
    /// Represents HTTP NotFound (404) errors that occur during application execution.
    /// </summary>
    [Serializable]
    public class NotFoundException : BaseValidationException
    {
        public static HttpStatusCode STATUS_CODE = HttpStatusCode.NotFound;
        public static string HELP_LINK = StatusCodeLink.NOT_FOUND;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound.
        /// </summary>
        public NotFoundException()
            : base(STATUS_CODE, HELP_LINK)
        { }


        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound and a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public NotFoundException(string message)
            : base(STATUS_CODE, HELP_LINK, message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"></see> class with status code NotFound, a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// if no inner exception is specified.</param>
        public NotFoundException(string message, Exception innerException)
            : base(STATUS_CODE, HELP_LINK, message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the exception class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(STATUS_CODE, HELP_LINK, info, context)
        { }

        /// <summary>
        /// Initializes a new instance of the exception class with invalid property and a error message.
        /// </summary>
        /// <param name="property">Invalid property</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public NotFoundException(string property, string message)
            : base(STATUS_CODE, HELP_LINK, message)
        {
            this.ValidationNotificationsPipeline.SetNotFoundStatus(property);
        }
    }
}