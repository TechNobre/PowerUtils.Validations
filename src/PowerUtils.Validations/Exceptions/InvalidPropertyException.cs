using System;
using System.Runtime.Serialization;

namespace PowerUtils.Validations.Exceptions
{
    /// <summary>
    /// Represents HTTP BadRequest (400) errors that occur during application execution.
    /// </summary>
    [Serializable]
    public class InvalidPropertyException : BadRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPropertyException"></see> class with status code BadRequest.
        /// </summary>
        public InvalidPropertyException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPropertyException"></see> class with status code BadRequest and a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidPropertyException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPropertyException"></see> class with status code BadRequest, a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// if no inner exception is specified.</param>
        public InvalidPropertyException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the exception class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
        protected InvalidPropertyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Initializes a new instance of the exception class with invalid property and error code.
        /// </summary>
        /// <param name="property">Invalid property</param>
        /// <param name="errorCode">Error code for invalid property</param>
        public InvalidPropertyException(string property, string errorCode)
            : base(property, errorCode)
        { }

        /// <summary>
        /// Initializes a new instance of the exception class with invalid property, error code and a error message.
        /// </summary>
        /// <param name="property">Invalid property</param>
        /// <param name="errorCode">Error code for invalid property</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidPropertyException(string property, string errorCode, string message)
            : base(property, errorCode, message)
        { }
    }
}
