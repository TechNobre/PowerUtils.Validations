using System.Collections.Generic;
using System.Net;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations
{
    public interface IValidationNotifications
    {
        bool Valid { get; }
        bool Invalid { get; }

        IReadOnlyCollection<ValidationFailure> Notifications { get; }

        HttpStatusCode StatusCode { get; }

        // GENERAL
        IValidationNotifications AddNotification(string property, string errorCode);

        // STATUS 400 - BAD REQUEST
        IValidationNotifications AddBadNotification(string property, string errorCode);
        IValidationNotifications AddBadNotification(ValidationFailure notification);
        IValidationNotifications AddBadNotifications(ICollection<ValidationFailure> notifications);
        IValidationNotifications AddBadNotifications(IList<ValidationFailure> notifications);
        IValidationNotifications AddBadNotifications(IReadOnlyCollection<ValidationFailure> notifications);
        IValidationNotifications AddBadNotifications(IValidationsContract validations);

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
