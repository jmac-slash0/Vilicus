using AutoMapper;
using System.Net;
using System.Web.Mvc;
using Vilicus.Dal.Interfaces;
using Vilicus.Dal.Models;
using Vilicus.Web.Models;

namespace Vilicus.Web.Controllers
{
    public class MessagesController : Controller
    {
        private IMessageRepository _repository;

        public MessagesController(IMessageRepository repository)
        {
            _repository = repository;
        }

        // GET: Messages
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            Message entity = null;
            MessageViewModel messageViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            entity = _repository.Get(id.Value);

            if (entity == null)
            {
                return HttpNotFound();
            }

            messageViewModel = Mapper.Map<Message, MessageViewModel>(entity);

            return View(messageViewModel);
        }

        // GET: Messages/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageEditModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(Mapper.Map<MessageEditModel, Message>(model));
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Message entity = _repository.Get(id.Value);
            
            if (entity == null)
            {
                return HttpNotFound();
            }

            MessageEditModel model = Mapper.Map<Message, MessageEditModel>(entity);

            return View(model);
        }

        // POST: Messages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MessageEditModel model)
        {
            if (ModelState.IsValid)
            {
                Message entity = Mapper.Map<MessageEditModel, Message>(model);
                _repository.Update(entity, entity.Id);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Messages/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            // Same code as Details... might need to rethink this
            Message entity = null;
            MessageViewModel messageViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            entity = _repository.Get(id.Value);

            if (entity == null)
            {
                return HttpNotFound();
            }

            messageViewModel = Mapper.Map<Message, MessageViewModel>(entity);

            return View(messageViewModel);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(_repository.Get(id));

            return RedirectToAction("Index");
        }
    }
}
