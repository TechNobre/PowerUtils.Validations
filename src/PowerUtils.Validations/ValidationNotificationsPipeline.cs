using System.Collections.Generic;
using System.Linq;
using System.Net;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations
{
    public class ValidationNotificationsPipeline : IValidationNotificationsPipeline
    { // MISSING: unit tests
        #region PUBLIC PROPERTIES
        public HttpStatusCode StatusCode { get; private set; }

        public bool Valid => _isValid();
        public bool Invalid => !_isValid();

        public IReadOnlyCollection<ValidationNotification> Notifications => _notifications.Values;
        #endregion


        #region PRIVATE PROPERTIES
        private readonly Dictionary<string, ValidationNotification> _notifications;
        #endregion


        #region CONSTRUCTOR
        public ValidationNotificationsPipeline()
        {
            _notifications = new Dictionary<string, ValidationNotification>();
            StatusCode = HttpStatusCode.OK;
        }
        public ValidationNotificationsPipeline(HttpStatusCode defaultStatusCode)
        {
            _notifications = new Dictionary<string, ValidationNotification>();
            StatusCode = defaultStatusCode;
        }
        #endregion


        #region GENERAL
        public IValidationNotificationsPipeline AddNotification(string property, string errorCode)
        {
            if(_notifications.ContainsKey(property))
            {
                return this;
            }

            _notifications.Add(
                property,
                new ValidationNotification(property, errorCode)
            );

            return this;
        }
        #endregion


        #region PUBLIC METHODS - BAD NOTIFICATIONS
        public IValidationNotificationsPipeline AddBadNotification(string property, string errorCode)
        {
            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
            }

            AddNotification(property, errorCode);

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotification(ValidationNotification notification)
        {
            if(_notifications.ContainsKey(notification.Property))
            {
                return this;
            }

            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
            }

            _notifications.Add(
                notification.Property,
                notification
            );

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotifications(IReadOnlyCollection<ValidationNotification> notifications)
        {
            if(notifications.Count == 0)
            {
                return this;
            }

            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
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

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotifications(IList<ValidationNotification> notifications)
        {
            if(notifications.Count == 0)
            {
                return this;
            }

            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
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

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotifications(ICollection<ValidationNotification> notifications)
        {
            if(notifications.Count == 0)
            {
                return this;
            }

            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
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

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotifications(IEnumerable<ValidationNotification> notifications)
        {
            if(!notifications.Any())
            {
                return this;
            }

            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
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

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotifications(IValidationsContract validations)
        {
            if(validations == null)
            {
                return this;
            }

            if(validations.Valid)
            {
                return this;
            }

            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
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

            return this;
        }
        #endregion


        #region PUBLIC METHODS - STATUS 403 FORBIDDEN
        public void SetForbiddenStatus(string property)
        {
            StatusCode = HttpStatusCode.Forbidden;
            AddNotification(property, ErrorCodes.FORBIDDEN);
        }
        #endregion


        #region PUBLIC METHODS - STATUS 404 NOT FOUND
        public void SetNotFoundStatus(string property)
        {
            StatusCode = HttpStatusCode.NotFound;
            AddNotification(property, ErrorCodes.NOT_FOUND);
        }
        #endregion


        #region PUBLIC METHODS - STATUS 409 CONFLICT
        public void SetConflictStatus(string property)
        {
            StatusCode = HttpStatusCode.Conflict;
            AddNotification(property, ErrorCodes.DUPLICATED);
        }
        #endregion


        #region PUBLIC METHODS - GENERAL STATUS
        public void SetNotificationStatus(HttpStatusCode statusCode, string property, string errorCode)
        {
            StatusCode = statusCode;
            AddNotification(property, errorCode);
        }
        #endregion


        #region PUBLIC METHODS - OTHERS
        public void Clear()
        {
            if(_isBadRequest())
            {
                StatusCode = HttpStatusCode.OK;
            }
            _notifications.Clear();
        }
        #endregion


        #region PRIVATE METHODS
        private bool _isValid()
        {
            if((int)StatusCode >= 400 && (int)StatusCode <= 599)
            {
                return false;
            }

            if(_notifications.Any())
            {
                StatusCode = HttpStatusCode.BadRequest;
                return false;
            }

            return _isSuccess();
        }

        private bool _isSuccess()
        {
            if((int)StatusCode >= 200 && (int)StatusCode <= 299)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _isBadRequest()
        {
            if(StatusCode == HttpStatusCode.BadRequest)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
