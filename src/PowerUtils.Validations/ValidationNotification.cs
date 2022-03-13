namespace PowerUtils.Validations
{
    public record ValidationNotification
    {
        public string Property { get; init; }
        public string ErrorCode { get; init; }

        public ValidationNotification() {}

        public ValidationNotification(string property, string errorCode)
        {
            Property = property;
            ErrorCode = errorCode;
        }
    }
}
