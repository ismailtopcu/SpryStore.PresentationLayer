using Microsoft.AspNetCore.Mvc;
using SpryStore.BusinessLayer.Abstract;
using SpryStore.EntityLayer.Concrete;
using System;

namespace SpryStore.PresentationLayer.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage (Contact contact)
        {
            contact.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.TInsert(contact);
            return RedirectToAction("Product","Index");
        }
    }
}
