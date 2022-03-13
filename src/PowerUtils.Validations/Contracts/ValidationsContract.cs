using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PowerUtils.Validations.Contracts
{
    public class ValidationsContract<TSource> : IValidationsContract<TSource>
    {
        public TSource Source { get; init; }

        public bool Valid => Notifications.Count == 0;
        public bool Invalid => !Valid;

        private readonly Dictionary<string, ValidationFailure> _notifications;
        public IReadOnlyCollection<ValidationFailure> Notifications => _notifications.Values;


        public ValidationsContract(TSource source)
        {
            _notifications = new Dictionary<string, ValidationFailure>();

            Source = source;
        }


        #region METHODS - RULES
        public IPropertyRule<TSource, TSource> RuleFor(string propertyName)
        {
            if(Source == null)
            {
                return new PropertyRule<TSource, TSource>(
                    this,
                    propertyName
                );
            }
            else
            {
                var type = Source.GetType();
                var sourceValue = (TSource)Convert.ChangeType(Source, type);

                return new PropertyRule<TSource, TSource>(
                    this,
                    propertyName,
                    sourceValue
                );
            }
        }

        public IPropertyRule<TSource, TProperty> RuleFor<TProperty>(Expression<Func<TSource, TProperty>> property, string propertyName = null)
        {
            if(property.Body is not MemberExpression body)
            {
                if(property.Body.NodeType == ExpressionType.Parameter)
                {
                    if(Source == null)
                    {
                        return new PropertyRule<TSource, TProperty>(
                            this,
                            propertyName
                        );
                    }
                    else
                    {
                        var type = Source.GetType();
                        var sourceValue = (TProperty)Convert.ChangeType(Source, type);

                        return new PropertyRule<TSource, TProperty>(
                            this,
                            propertyName,
                            sourceValue
                        );
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid 'property'. The 'property' should be a member expression");
                }
            }

            var propertyInfo = (PropertyInfo)body.Member;

            // https://stackoverflow.com/questions/10224119/get-property-type-by-memberexpression/10224197
            if(string.IsNullOrWhiteSpace(propertyName))
            {
                propertyName = propertyInfo.Name;
            }

            var propertyType = propertyInfo.ReflectedType;
            object propertyValue;
            if(Source == null)
            {
                propertyValue = null;
            }
            else
            {
                propertyValue = propertyType?.GetProperty(propertyInfo.Name)?.GetValue(Source, null);
            }

            if(propertyValue == null)
            {
                return new PropertyRule<TSource, TProperty>(
                    this,
                    propertyName
                );
            }
            else
            {
                return new PropertyRule<TSource, TProperty>(
                    this,
                    propertyName,
                    (TProperty)propertyValue
                );
            }
        }
        #endregion


        #region NOTIFICATIONS METHODS
        public void AddNotification(string property, string errorCode)
        {
            if(_notifications.ContainsKey(property))
            {
                return;
            }

            _notifications.Add(
                property,
                new ValidationFailure(property, errorCode)
            );
        }

        public void AddNotifications(IValidationsContract validations)
        {
            if(validations == null)
            {
                return;
            }

            if(validations.Notifications.Count == 0)
            {
                return;
            }

            foreach(var notification in validations.Notifications)
            {
                if(_notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                _notifications.Add(
                    notification.Property,
                    notification
                );
            }
        }

        public void AddNotifications(IEnumerable<ValidationFailure> validations)
        {
            if(validations == null)
            {
                return;
            }

            if(!validations.Any())
            {
                return;
            }

            foreach(var notification in validations)
            {
                if(_notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                _notifications.Add(
                    notification.Property,
                    notification
                );
            }
        }
        #endregion
    }
}
