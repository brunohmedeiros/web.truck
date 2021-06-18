using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Truck.Domain.Interfaces.Utils;

namespace Web.Truck.API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly INotificationContext _notificationContext;

        public BaseController(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected IActionResult ResponseOk(object res = null)
        {
            if (!_notificationContext.HasNotificarion())
            {
                return Ok(new { sucess = true, data = res });
            }

            var notif = _notificationContext.GetNotifications();
            return BadRequest(new { sucess = false, errors = notif.ToList().Select(x => x.Message) });
        }
    }
}
