namespace PowerUtils.Validations
{
    public record ValidationNotification
    { // DONE
        public string Property { get; init; }
        public string ErrorCode { get; init; }
        public string Message { get; init; }

        public ValidationNotification() {}

        public ValidationNotification(string property, string errorCode)
            : this(property, errorCode, null) { }

        public ValidationNotification(string property, string errorCode, string message)
        {
            this.Property = property;
            this.ErrorCode = errorCode;
            this.Message = message;
        }
    }
}