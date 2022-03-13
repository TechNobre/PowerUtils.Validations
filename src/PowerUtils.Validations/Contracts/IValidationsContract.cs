using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace PowerUtils.Validations.Contracts
{
    public interface IValidationsContract
    {
        bool Valid { get; }
        bool Invalid { get; }

        IReadOnlyCollection<ValidationFailure> Notifications { get; }
    }

    public interface IValidationsContract<TSource> : IValidationsContract
    {
        TSource Source { get; init; }


        #region METHODS - RULES
        IPropertyRule<TSource, TSource> RuleFor(string propertyName);
        IPropertyRule<TSource, TProperty> RuleFor<TProperty>(Expression<Func<TSource, TProperty>> expression, string propertyName = null);
        #endregion


        #region METHODS - NOTIFICATIONS
        void AddNotification(string property, string errorCode);
        void AddNotifications(IEnumerable<ValidationFailure> validations);
        void AddNotifications(IValidationsContract validations);
        #endregion
    }
}
