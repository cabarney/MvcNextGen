using Microsoft.AspNet.Mvc;
using UserGroup.Models;

namespace UserGroup.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IRepository<Meeting> _meetingsRepository;

        public MeetingsController(IRepository<Meeting> meetingsRepository)
        {
            _meetingsRepository = meetingsRepository;
        }

        public ActionResult Index(int? page)
        {
            var meetings = new PagedListViewModel<Meeting>(_meetingsRepository.All(), 5, page ?? 0);
            return View(meetings);
        }

        
    }
}