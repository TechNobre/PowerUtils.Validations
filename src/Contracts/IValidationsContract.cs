using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public interface IValidationsContract
    {
        bool Valid { get; }
        bool Invalid { get; }

        IReadOnlyCollection<ValidationFailure> Notifications { get; }
    }

    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public interface IValidationsContract<TSource> : IValidationsContract
    {
        TSource Source { get; init; }


        #region METHODS - RULES
        IPropertyRule<TSource, TSource> RuleFor(string propertyName);
        IPropertyRule<TSource, TProperty> RuleFor<TProperty>(Expression<Func<TSource, TProperty>> property, string propertyName = null);
        #endregion


        #region METHODS - NOTIFICATIONS
        void AddNotification(string property, string errorCode);
        void AddNotifications(IEnumerable<ValidationFailure> validations);
        void AddNotifications(IValidationsContract validations);
        #endregion
    }
}
