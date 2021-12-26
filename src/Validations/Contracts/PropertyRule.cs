using System.Collections.Generic;

namespace PowerUtils.Validations.Contracts
{
    public class PropertyRule<TSource, TProperty> : IPropertyRule<TSource, TProperty>
    {
        #region PROPERTIES
        public bool PropertyNull { get; init; }
        public string PropertyName { get; init; }
        public TProperty PropertyValue { get; init; }


        public bool Valid => Notifications.Count == 0;
        public bool Invalid => !Valid;

        public IReadOnlyCollection<ValidationNotification> Notifications => _context.Notifications;


        private IValidationsContract<TSource> _context { get; }
        #endregion


        #region CONSTRUCTORS
        public PropertyRule(
            IValidationsContract<TSource> context,
            string propertyName
        )
        {
            PropertyNull = true;
            _context = context;
            PropertyName = propertyName;
        }

        public PropertyRule(
            IValidationsContract<TSource> context,
            string propertyName,
            TProperty propertyValue
        )
            : this(context, propertyName)
        {
            _context = context;
            PropertyValue = propertyValue;
            PropertyName = propertyName;

            if(PropertyValue != null)
            {
                PropertyNull = false;
            }
        }
        #endregion


        #region METHODS - NOTIFICATIONS
        public void AddNotification(string errorCode) =>
            _context.AddNotification(PropertyName, errorCode);
        #endregion


        #region GENERIC METHODS
        public override string ToString()
            => $"{PropertyName} = '{PropertyValue}'";
        #endregion
    }
}
