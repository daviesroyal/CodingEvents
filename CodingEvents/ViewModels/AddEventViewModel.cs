﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for the event.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than five hundred characters.")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Please provide a location for the event.")]
        public string Location { get; set; }

        [Range(0, 100, ErrorMessage = "Cannot have more than 100 attendees.")]
        public int NumOfAttendees { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

        public AddEventViewModel()
        {
        }
    }
}
