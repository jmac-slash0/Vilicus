using AutoMapper;
using System.Net;
using System.Web.Mvc;
using Vilicus.Dal.Interfaces;
using Vilicus.Dal.Models;
using Vilicus.Web.Models;

namespace Vilicus.Web.Controllers
{
    public class TicketsController : Controller
    {
        private ITicketRepository _repository;


        public TicketsController(ITicketRepository repository)
        {
            _repository = repository;
        }

        // GET: Tickets
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket ticket = _repository.Get(id.Value);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map incoming view model to entity
                Ticket entity = Mapper.Map<TicketCreateViewModel, Ticket>(model);

                _repository.Add(entity);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket entity = _repository.Get(id.Value);

            if (entity == null)
            {
                return HttpNotFound();
            }

            TicketEditViewModel model = Mapper.Map<Ticket, TicketEditViewModel>(entity);

            return View(model);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Ticket entity = Mapper.Map<TicketEditViewModel, Ticket>(model);

                _repository.Update(entity, entity.Id);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket ticket = _repository.Get(id.Value);

            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(_repository.Get(id));

            return RedirectToAction("Index");
        }
    }
}
