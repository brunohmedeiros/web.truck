using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Web.Truck.Domain.Interfaces.Utils;

namespace Web.Truck.Domain.Utils.Notification
{
    public class NotificationContext : INotificationContext
    {
		private readonly List<Notification> _notifications;

		public NotificationContext()
		{
			_notifications = new List<Notification>();
		}

		public void AddNotification(string message)
		{
			_notifications.Add(new Notification(message));
		}

		public void AddNotifications(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				AddNotification(error.ErrorMessage);
			}
		}

        public void ClearNotifications()
        {
			_notifications.Clear();
		}

        public IEnumerable<Notification> GetNotifications()
        {
			return _notifications;
		}

        public bool HasNotificarion()
        {
			return _notifications.Any();
		}
    }
}
