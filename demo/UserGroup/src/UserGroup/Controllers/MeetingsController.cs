using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using UserGroup.Models;

namespace UserGroup.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IRepository<Meeting> _meetingRepository;
        private readonly IRepository<Registration> _registrationRepository;
        private readonly AppUserManager _userManager;

        public MeetingsController(IRepository<Meeting> meetingRepository, IRepository<Registration> registrationRepository, AppUserManager userManager)
        {
            _meetingRepository = meetingRepository;
            _registrationRepository = registrationRepository;
            _userManager = userManager;
        }

        // Index (List)
        public ActionResult Index(int? page)
        {
            var meetings = new PagedListViewModel<Meeting>(_meetingRepository.All(), 5, page ?? 0);
            return View(meetings);
        }

        // Detail
        public ActionResult Detail(int id)
        {
            return View(_meetingRepository.Find(id));
        }

        [Authorize]
        public async Task<ActionResult> Register(int meetingId)
        {
            var user = await _userManager.FindByIdAsync(User.GetUserId());
            var registration = new Registration
            {
                MeetingId = meetingId,
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email
            };
            _registrationRepository.Add(registration);
            _registrationRepository.Save();
            return RedirectToAction("Detail", new {id = meetingId});
        }

        public ActionResult RegisterGuest(Registration registration)
        {
            if (ModelState.IsValid)
            {
                _registrationRepository.Add(registration);
                _registrationRepository.Save();
                Response.Cookies.Append("registered"+registration.MeetingId, "true");
            }
            return RedirectToAction("Detail", registration.MeetingId);
        }

        // Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return View(meeting);
            }
            _meetingRepository.Add(meeting);
            _meetingRepository.Save();
            return RedirectToAction("Index");
        }

        // Edit
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(_meetingRepository.Find(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return View(meeting);
            }
            _meetingRepository.Update(meeting);
            _meetingRepository.Save();
            return RedirectToAction("Index");
        }

        // Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(_meetingRepository.Find(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ConfirmDelete(int id)
        {
            _meetingRepository.Delete(id);
            _meetingRepository.Save();
            return RedirectToAction("Index");
        }
    }
}