using System;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
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
