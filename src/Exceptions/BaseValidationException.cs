using PowerUtils.Net.Constants;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace PowerUtils.Validations.Exceptions
{
    /// <summary>
    /// Represents a base class for HTTP errors that occur during application execution.
    /// </summary>
    [Serializable]
    public abstract class BaseValidationException : Exception
    {
        /// <summary>
        /// HTTP status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets or sets a link to the help file associated with this exception.
        /// For HttpExeptions a link to status code information https://tools.ietf.org/html/rfc7231.
        /// </summary>
        /// <returns>The Uniform Resource Name (URN) or Uniform Resource Locator (URL).</returns>
        public new string HelpLink { get; private set; }

        /// <summary>
        /// Gets the list of validations in exception
        /// </summary>
        public IReadOnlyCollection<ValidationNotification> Notifications => this.ValidationNotificationsPipeline.Notifications;
        protected IValidationNotificationsPipeline ValidationNotificationsPipeline { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationException"></see> class with status code InternalServerError.
        /// </summary>
        protected BaseValidationException(HttpStatusCode statusCode, string helpLink)
            : base()
        {
            this.StatusCode = statusCode;
            this.HelpLink = helpLink;
            this.ValidationNotificationsPipeline = new ValidationNotificationsPipeline(this.StatusCode);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationException"></see> class with status code InternalServerError and a specified error message.
        /// </summary>
        /// <param name="statusCode">Status code for exception.</param>
        /// <param name="helpLink">Link for documentations about the status code.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        protected BaseValidationException(HttpStatusCode statusCode, string helpLink, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
            this.HelpLink = helpLink;
            this.ValidationNotificationsPipeline = new ValidationNotificationsPipeline(this.StatusCode);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidationException"></see> class with status code InternalServerError, a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="statusCode">Status code for exception.</param>
        /// <param name="helpLink">Link for documentations about the status code.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
        /// if no inner exception is specified.</param>
        protected BaseValidationException(HttpStatusCode statusCode, string helpLink, string message, Exception innerException)
            : base(message, innerException)
        {
            this.StatusCode = statusCode;
            this.HelpLink = helpLink;
            this.ValidationNotificationsPipeline = new ValidationNotificationsPipeline(this.StatusCode);
        }

        /// <summary>
        /// Initializes a new instance of the exception class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
        protected BaseValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            var statusCode = info.GetValue(nameof(StatusCode), typeof(HttpStatusCode));
            this.StatusCode = statusCode == null ? HttpStatusCode.BadRequest : (HttpStatusCode)statusCode;

            this.HelpLink = StatusCodeLink.GetStatusCodeLink((int)this.StatusCode);
            this.ValidationNotificationsPipeline = new ValidationNotificationsPipeline(this.StatusCode);
        }

        /// <summary>
        /// Initializes a new instance of the exception class with serialized data.
        /// </summary>
        /// <param name="statusCode">Status code for exception.</param>
        /// <param name="helpLink">Link for documentations about the status code.</param>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
        protected BaseValidationException(HttpStatusCode statusCode, string helpLink, SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.StatusCode = statusCode;
            this.HelpLink = helpLink;
            this.ValidationNotificationsPipeline = new ValidationNotificationsPipeline(this.StatusCode);
        }

        /// <summary>
        /// Sets the <see cref="SerializationInfo"></see> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is a null reference (Nothing in Visual Basic).</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(StatusCode), StatusCode);
            base.GetObjectData(info, context);
        }
    }
}