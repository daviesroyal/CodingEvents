using CodingEvents.Models;
using CodingEvents.ViewModels;
using CodingEventsDemo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<EventCategory> eventCategories = context.Categories.ToList();

            return View(eventCategories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        //[Route("Create/Form")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory eventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name
                };
                context.Categories.Add(eventCategory);
                context.SaveChanges();
                return Redirect("/eventcategory");
            }
            return View(addEventCategoryViewModel);
        }
    }
}
