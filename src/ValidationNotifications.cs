using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public class ValidationNotifications : IValidationNotifications
    {
        #region PUBLIC PROPERTIES
        public HttpStatusCode StatusCode { get; private set; }

        public bool Valid => _isValid();
        public bool Invalid => !_isValid();

        public IReadOnlyCollection<ValidationFailure> Notifications => _notifications.Values;
        #endregion


        #region PRIVATE PROPERTIES
        private readonly Dictionary<string, ValidationFailure> _notifications;
        #endregion


        #region CONSTRUCTOR
        public ValidationNotifications()
        {
            _notifications = new Dictionary<string, ValidationFailure>();
            StatusCode = HttpStatusCode.OK;
        }
        public ValidationNotifications(HttpStatusCode defaultStatusCode)
        {
            _notifications = new Dictionary<string, ValidationFailure>();
            StatusCode = defaultStatusCode;
        }
        #endregion


        #region GENERAL
        public IValidationNotifications AddNotification(string property, string errorCode)
        {
            if(_notifications.ContainsKey(property))
            {
                return this;
            }

            _notifications.Add(
                property,
                new ValidationFailure(property, errorCode)
            );

            return this;
        }
        #endregion


        #region PUBLIC METHODS - BAD NOTIFICATIONS
        public IValidationNotifications AddBadNotification(string property, string errorCode)
        {
            if(_isSuccess())
            {
                StatusCode = HttpStatusCode.BadRequest;
            }

            AddNotification(property, errorCode);

            return this;
        }

        public IValidationNotifications AddBadNotification(ValidationFailure notification)
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

        public IValidationNotifications AddBadNotifications(IReadOnlyCollection<ValidationFailure> notifications)
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

        public IValidationNotifications AddBadNotifications(IList<ValidationFailure> notifications)
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

        public IValidationNotifications AddBadNotifications(ICollection<ValidationFailure> notifications)
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

        public IValidationNotifications AddBadNotifications(IEnumerable<ValidationFailure> notifications)
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

        public IValidationNotifications AddBadNotifications(IValidationsContract validations)
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

            return false;
        }

        private bool _isBadRequest()
        {
            if(StatusCode == HttpStatusCode.BadRequest)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
