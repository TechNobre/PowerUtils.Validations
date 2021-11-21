using PowerUtils.Validations.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PowerUtils.Validations
{
    public class ValidationNotificationsPipeline : IValidationNotificationsPipeline
    { // MISSING: unit tests
        #region PUBLIC PROPERTIES
        public HttpStatusCode StatusCode { get; private set; }

        public bool Valid => this._isValid();
        public bool Invalid => !this._isValid();

        public IReadOnlyCollection<ValidationNotification> Notifications => this._notifications.Values;
        #endregion


        #region PRIVATE PROPERTIES
        private readonly Dictionary<string, ValidationNotification> _notifications;
        #endregion


        #region CONSTRUCTOR
        public ValidationNotificationsPipeline()
        {
            this._notifications = new Dictionary<string, ValidationNotification>();
            this.StatusCode = HttpStatusCode.OK;
        }
        public ValidationNotificationsPipeline(HttpStatusCode defaultStatusCode)
        {
            this._notifications = new Dictionary<string, ValidationNotification>();
            this.StatusCode = defaultStatusCode;
        }
        #endregion


        #region GENERAL
        public IValidationNotificationsPipeline AddNotification(string property, string errorCode)
        {
            if(this._notifications.ContainsKey(property))
            {
                return this;
            }

            this._notifications.Add(
                property,
                new ValidationNotification(property, errorCode)
            );

            return this;
        }
        #endregion


        #region PUBLIC METHODS - BAD NOTIFICATIONS
        public IValidationNotificationsPipeline AddBadNotification(string property, string errorCode)
        {
            if(this._isSuccess())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
            }

            this.AddNotification(property, errorCode);

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotification(ValidationNotification notification)
        {
            if(this._notifications.ContainsKey(notification.Property))
            {
                return this;
            }

            if(this._isSuccess())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
            }

            this._notifications.Add(
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

            if(this._isSuccess())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
            {
                if(this._notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                this._notifications.Add(
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

            if(this._isSuccess())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
            {
                if(this._notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                this._notifications.Add(
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

            if(this._isSuccess())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
            {
                if(this._notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                this._notifications.Add(
                    notification.Property,
                    notification
                );
            }

            return this;
        }

        public IValidationNotificationsPipeline AddBadNotifications(IEnumerable<ValidationNotification> notifications)
        {
            if(notifications.Count() == 0)
            {
                return this;
            }

            if(this._isSuccess())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in notifications)
            {
                if(this._notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                this._notifications.Add(
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

            if(this._isSuccess())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
            }

            foreach(var notification in validations.Notifications)
            {
                if(this._notifications.ContainsKey(notification.Property))
                {
                    continue;
                }

                this._notifications.Add(
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
            this.StatusCode = HttpStatusCode.Forbidden;
            this.AddNotification(property, ErrorCodes.FORBIDDEN);
        }
        #endregion


        #region PUBLIC METHODS - STATUS 404 NOT FOUND
        public void SetNotFoundStatus(string property)
        {
            this.StatusCode = HttpStatusCode.NotFound;
            this.AddNotification(property, ErrorCodes.NOT_FOUND);
        }
        #endregion


        #region PUBLIC METHODS - STATUS 409 CONFLICT
        public void SetConflictStatus(string property)
        {
            this.StatusCode = HttpStatusCode.Conflict;
            this.AddNotification(property, ErrorCodes.ALREADY_EXISTS);
        }
        #endregion


        #region PUBLIC METHODS - GENERAL STATUS
        public void SetNotificationStatus(HttpStatusCode statusCode, string property, string errorCode)
        {
            this.StatusCode = statusCode;
            this.AddNotification(property, errorCode);
        }
        #endregion


        #region PUBLIC METHODS - OTHERS
        public void Clear()
        {
            if(this._isBadRequest())
            {
                this.StatusCode = HttpStatusCode.OK;
            }
            this._notifications.Clear();
        }
        #endregion


        #region PRIVATE METHODS
        private bool _isValid()
        {
            if((int)this.StatusCode >= 400 && (int)this.StatusCode <= 599)
            {
                return false;
            }

            if(this._notifications.Any())
            {
                this.StatusCode = HttpStatusCode.BadRequest;
                return false;
            }

            return this._isSuccess();
        }

        private bool _isSuccess()
        {
            if((int)this.StatusCode >= 200 && (int)this.StatusCode <= 299)
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
            if(this.StatusCode == HttpStatusCode.BadRequest)
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