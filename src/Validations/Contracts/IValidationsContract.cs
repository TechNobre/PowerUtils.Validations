using System.Collections.Generic;

namespace PowerUtils.Validations.Contracts
{
    public interface IValidationsContract
    {
        #region PROPERTIES
        bool Valid { get; }
        bool Invalid { get; }

        IReadOnlyCollection<ValidationNotification> Notifications { get; }
        #endregion
    }
}
