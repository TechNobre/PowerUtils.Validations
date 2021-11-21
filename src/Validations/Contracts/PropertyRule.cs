using System.Collections.Generic;

namespace PowerUtils.Validations.Contracts
{
    public class PropertyRule<TSource, TProperty> : IPropertyRule<TSource, TProperty>
    {
        #region PROPERTIES
        public bool PropertyNull { get; init; }
        public string PropertyName { get; init; }
        public TProperty PropertyValue { get; init; }


        public bool Valid => this.Notifications.Count == 0;
        public bool Invalid => !this.Valid;

        public IReadOnlyCollection<ValidationNotification> Notifications => this._context.Notifications;


#pragma warning disable IDE1006 // Naming Styles
        private IValidationsContract<TSource> _context { get; }
#pragma warning restore IDE1006 // Naming Styles
        #endregion


        #region CONSTRUCTORS
        public PropertyRule(
            IValidationsContract<TSource> context,
            string propertyName
        )
        {
            this.PropertyNull = true;
            this._context = context;
            this.PropertyName = propertyName;
        }

        public PropertyRule(
            IValidationsContract<TSource> context,
            string propertyName,
            TProperty propertyValue
        )
            : this(context, propertyName)
        {
            this._context = context;
            this.PropertyValue = propertyValue;
            this.PropertyName = propertyName;

            if(this.PropertyValue != null)
            {
                this.PropertyNull = false;
            }
        }
        #endregion


        #region METHODS - NOTIFICATIONS
        public void AddNotification(string errorCode) =>
            this._context.AddNotification(this.PropertyName, errorCode);
        #endregion


        #region GENERIC METHODS
        public override string ToString()
        {
            return $"{this.PropertyName} = '{this.PropertyValue}'";
        }
        #endregion
    }
}