﻿namespace PowerUtils.Validations
{
    public record ValidationNotification
    {
        public string Property { get; init; }
        public string ErrorCode { get; init; }
        public string Message { get; init; }

        public ValidationNotification() {}

        public ValidationNotification(string property, string errorCode)
            : this(property, errorCode, null) { }

        public ValidationNotification(string property, string errorCode, string message)
        {
            Property = property;
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
