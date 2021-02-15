using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CodingEvents.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Event> events = context.Events.Include(e => e.Category).ToList();

            return View(events);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel(context.Categories.ToList());
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory category = context.Categories.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = category,
                    Location = addEventViewModel.Location,
                    NumOfAttendees = addEventViewModel.NumOfAttendees,
                };
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/events");
            }
            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }

        public IActionResult Detail(int id)
        {
            Event theEvent = context.Events
               .Include(e => e.Category)
               .Single(e => e.Id == id);
            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();
            EventDetailViewModel viewModel = new EventDetailViewModel(theEvent, eventTags);
            return View(viewModel);
        }
    }
}
