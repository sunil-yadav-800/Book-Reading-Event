﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        /*[Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }*/
        public virtual ICollection<Event> Event { get; set; }
    }
}
