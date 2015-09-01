using Microsoft.AspNet.Mvc;
using UserGroup.Models;

namespace UserGroup.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IRepository<Meeting> _repository;

        public MeetingsController(IRepository<Meeting> repository)
        {
            _repository = repository;
        }

        // Index (List)
        public ActionResult Index(int? page)
        {
            var meetings = new PagedListViewModel<Meeting>(_repository.All(), 5, page ?? 0);
            return View(meetings);
        }

        // Detail
        public ActionResult Detail(int id)
        {
            return View(_repository.Find(id));
        }

        // Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return View(meeting);
            }
            _repository.Add(meeting);
            _repository.Save();
            return RedirectToAction("Index");
        }

        // Edit
        public ActionResult Edit(int id)
        {
            return View(_repository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                return View(meeting);
            }
            _repository.Update(meeting);
            _repository.Save();
            return RedirectToAction("Index");
        }

        // Delete
        public ActionResult Delete(int id)
        {
            return View(_repository.Find(id));
        }

        [HttpPost("delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}