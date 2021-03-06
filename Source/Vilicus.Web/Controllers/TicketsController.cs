﻿using AutoMapper;
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
            Ticket entity = null;
            TicketViewModel model = null;

            // Check if we got an id
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Hit repo
            entity = _repository.Get(id.Value);

            // See if we got a result
            if (entity == null)
            {
                return HttpNotFound();
            }

            // Map entity to view model
            model = AutoMapper.Mapper.Map<Ticket, TicketViewModel>(entity);

            return View(model);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map incoming view model to entity
                Ticket entity = Mapper.Map<TicketViewModel, Ticket>(model);

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

            TicketEditModel model = Mapper.Map<Ticket, TicketEditModel>(entity);

            return View(model);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketEditModel model)
        {
            if (ModelState.IsValid)
            {
                Ticket entity = Mapper.Map<TicketEditModel, Ticket>(model);

                _repository.Update(entity, entity.Id);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Tickets/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Ticket entity = null;
            TicketViewModel model = null;

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            entity = _repository.Get(id.Value);
            model = Mapper.Map<Ticket, TicketViewModel>(entity);

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Tickets/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(_repository.Get(id));

            return RedirectToAction("Index");
        }
    }
}
