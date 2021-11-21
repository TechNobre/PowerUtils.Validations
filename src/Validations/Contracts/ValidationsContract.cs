using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PowerUtils.Validations.Contracts
{
    public class ValidationsContract<TSource> : IValidationsContract<TSource>
    {
        #region PROPERTIES
        public TSource Source { get; init; }

        public bool Valid => this.Notifications.Count == 0;
        public bool Invalid => !this.Valid;

        private readonly Dictionary<string, ValidationNotification> _notifications;
        public IReadOnlyCollection<ValidationNotification> Notifications => this._notifications.Values;

        private readonly HashSet<string> _ignoreProperties;
        public IReadOnlyCollection<string> IgnoreProperties => this._ignoreProperties;
        #endregion


        #region CONSTRUCTORS
        public ValidationsContract(TSource source)
        {
            this._ignoreProperties = new HashSet<string>();
            this._notifications = new Dictionary<string, ValidationNotification>();

            this.Source = source;
        }

        public ValidationsContract(TSource source, params string[] ignoreProperties)
            : this(source)
        {
            this.AddPropertyToIgnore(ignoreProperties);
        }
        #endregion


        #region METHODS - RULES
        public IPropertyRule<TSource, TSource> RuleFor(string propertyName)
        {
            if(this.Source == null)
            {
                return new PropertyRule<TSource, TSource>(
                    this,
                    propertyName
                );
            }
            else
            {
                var type = this.Source.GetType();
                var sourceValue = (TSource)Convert.ChangeType(this.Source, type);

                return new PropertyRule<TSource, TSource>(
                    this,
                    propertyName,
                    sourceValue
                );
            }
        }

        public IPropertyRule<TSource, TProperty> RuleFor<TProperty>(Expression<Func<TSource, TProperty>> property, string propertyName = null)
        {
            MemberExpression body = property.Body as MemberExpression;
            if(body == null)
            { // TODO: to improvement
                if(property.Body.NodeType == ExpressionType.Parameter)
                {
                    if(this.Source == null)
                    {
                        return new PropertyRule<TSource, TProperty>(
                            this,
                            propertyName
                        );
                    }
                    else
                    {
                        var type = this.Source.GetType();
                        var sourceValue = (TProperty)Convert.ChangeType(this.Source, type);

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

            PropertyInfo propertyInfo = (PropertyInfo)body.Member;

            // https://stackoverflow.com/questions/10224119/get-property-type-by-memberexpression/10224197
            if(string.IsNullOrWhiteSpace(propertyName))
            {
                propertyName = propertyInfo.Name;
            }

            Type propertyType = propertyInfo.ReflectedType;
            object propertyValue;
            if(this.Source == null)
            {
                propertyValue = null;
            }
            else
            {
                propertyValue = propertyType?.GetProperty(propertyInfo.Name)?.GetValue(this.Source, null);
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
            if(this._ignoreProperties.Contains(property))
            {
                return;
            }

            if(this._notifications.ContainsKey(property))
            {
                return;
            }

            this._notifications.Add(
                property,
                new ValidationNotification(property, errorCode)
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
                if(this._ignoreProperties.Contains(notification.Property))
                {
                    continue;
                }

                if(this._notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                this._notifications.Add(
                    notification.Property,
                    notification
                );
            }
        }

        public void AddNotifications(IEnumerable<ValidationNotification> validations)
        {
            if(validations == null)
            {
                return;
            }

            if(validations.Count() == 0)
            {
                return;
            }

            foreach(var notification in validations)
            {
                if(this._ignoreProperties.Contains(notification.Property))
                {
                    continue;
                }

                if(this._notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                this._notifications.Add(
                    notification.Property,
                    notification
                );
            }
        }
        #endregion


        #region GENERIC METHODS
        public void AddPropertyToIgnore(params string[] ignoreProperties)
        {
            if(ignoreProperties == null)
            {
                return;
            }

            foreach(var property in ignoreProperties)
            {
                this._ignoreProperties.Add(property);
            }
        }
        #endregion
    }
}