using FluentValidation.Results;
using Web.Truck.Domain.Interfaces.Utils;

namespace Web.Truck.Domain.Services
{
    public class BaseService
    {
        private readonly INotificationContext _notificationContext;

        public BaseService(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected void AddNotify(string message)
        {
            _notificationContext.AddNotification(message);
        }

        protected void AddNotify(ValidationResult Validation)
        {
            _notificationContext.AddNotifications(Validation);
        }
    }
}
