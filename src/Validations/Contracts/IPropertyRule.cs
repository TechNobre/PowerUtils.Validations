namespace PowerUtils.Validations.Contracts
{
    public interface IPropertyRule<TSource, TProperty> : IValidationsContract
    {
        #region PROPERTIES
        bool PropertyNull { get; init; }
        string PropertyName { get; init; }
        TProperty PropertyValue { get; init; }
        #endregion


        #region METHODS - NOTIFICATIONS
        void AddNotification(string errorCode);
        #endregion
    }
}