using PowerUtils.Validations.Contracts;
using System.Collections.Generic;
using System.Net;

namespace PowerUtils.Validations
{
    public interface IValidationNotificationsPipeline
    { // DONE
        bool Valid { get; }
        bool Invalid { get; }

        IReadOnlyCollection<ValidationNotification> Notifications { get; }

        HttpStatusCode StatusCode { get; }

        // GENERAL
        IValidationNotificationsPipeline AddNotification(string property, string errorCode);

        // STATUS 400 - BAD REQUEST
        IValidationNotificationsPipeline AddBadNotification(string property, string errorCode);
        IValidationNotificationsPipeline AddBadNotification(ValidationNotification notification);
        IValidationNotificationsPipeline AddBadNotifications(ICollection<ValidationNotification> notifications);
        IValidationNotificationsPipeline AddBadNotifications(IList<ValidationNotification> notifications);
        IValidationNotificationsPipeline AddBadNotifications(IReadOnlyCollection<ValidationNotification> notifications);
        IValidationNotificationsPipeline AddBadNotifications(IValidationsContract validations);

        // STATUS 404 - NOT FOUND
        void SetNotFoundStatus(string property);

        // STATUS 403 - FORBIDDEN
        void SetForbiddenStatus(string property);

        // STATUS 409 - CONFLICT
        void SetConflictStatus(string property);

        // GENERAL STATUS
        void SetNotificationStatus(HttpStatusCode statusCode, string property, string errorCode);

        // OTHERS
        void Clear();
    }
}