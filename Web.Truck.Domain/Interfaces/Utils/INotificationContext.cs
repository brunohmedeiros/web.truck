using FluentValidation.Results;
using System.Collections.Generic;
using Web.Truck.Domain.Utils.Notification;

namespace Web.Truck.Domain.Interfaces.Utils
{
    public interface INotificationContext
    {
        void AddNotification(string message);
        void AddNotifications(ValidationResult validationResult);
		IEnumerable<Notification> GetNotifications();
        bool HasNotificarion();
    }
}
