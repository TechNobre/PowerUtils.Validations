using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PowerUtils.Validations.Contracts
{
    public interface IValidationsContract<TSource> : IValidationsContract
    {
        #region PROPERTIES
        TSource Source { get; init; }
        IReadOnlyCollection<string> IgnoreProperties { get; }
        #endregion


        #region METHODS - RULES
        IPropertyRule<TSource, TSource> RuleFor(string propertyName);
        IPropertyRule<TSource, TProperty> RuleFor<TProperty>(Expression<Func<TSource, TProperty>> expression, string propertyName = null);
        #endregion


        #region METHODS - NOTIFICATIONS
        void AddNotification(string property, string errorCode);
        void AddNotifications(IEnumerable<ValidationNotification> validations);
        void AddNotifications(IValidationsContract validations);
        #endregion
    }
}
