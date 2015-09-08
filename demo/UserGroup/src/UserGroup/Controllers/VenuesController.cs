using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using UserGroup.Models;

namespace UserGroup.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VenuesController : Controller
    {
        private readonly IRepository<Venue> _repository;

        public VenuesController(IRepository<Venue> repository)
        {
            _repository = repository;
        }

        // Index (List)
        public ActionResult Index(int? page)
        {
            var venues = new PagedListViewModel<Venue>(_repository.All(), 5, page ?? 0);
            return View(venues);
        }

        // Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            _repository.Add(venue);
            _repository.Save();
            return RedirectToAction("Index");
        }

        // Edit
        public ActionResult Edit(int id)
        {
            return View(_repository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return View(venue);
            }
            _repository.Update(venue);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}