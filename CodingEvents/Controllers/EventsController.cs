using CodingEvents.Models;
using CodingEvents.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, Route("/events/add")]
        public IActionResult NewEvent(string name, string description = "")
        {
            EventData.Add(new Event(name, description));
            return Redirect("/events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [HttpGet, Route("/Events/Edit/{eventId?}")]
        public IActionResult Edit(int eventId)
        {
            // controller code will go here
            Event eventToEdit = EventData.GetById(eventId);
            ViewBag.name = eventToEdit.Name;
            ViewBag.Title = $"Edit Event {ViewBag.name} (id={eventId})";
            return View();
        }

        [HttpPost, Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            // controller code will go here
            Event eventToEdit = EventData.GetById(eventId);
            eventToEdit.Name = name;
            eventToEdit.Description = description;
            return Redirect("/Events");
        }
    }
}
