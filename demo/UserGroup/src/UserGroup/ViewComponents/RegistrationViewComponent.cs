using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using UserGroup.Models;

namespace UserGroup.ViewComponents
{
    public class RegistrationViewComponent : ViewComponent
    {
        private readonly IRepository<Registration> _repository;

        public RegistrationViewComponent(IRepository<Registration> repository)
        {
            _repository = repository;
        }
		
        public IViewComponentResult Invoke(int meetingId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = ((ClaimsPrincipal) User).GetUserId();
                var registration = _repository.All().SingleOrDefault(x => x.UserId == userId && x.MeetingId == meetingId);
                if (registration != null)
                {
                    return View("Registered", registration);
                }
                else
                {
                    return View(meetingId);
                }
            }
            else
            {
                if (Request.Cookies.ContainsKey("registered" + meetingId))
                    return View("GuestRegistered");
                return View("Guest", new Registration {MeetingId = meetingId});
            }
        }
    }
}