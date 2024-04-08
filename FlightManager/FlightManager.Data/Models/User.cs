using FlightManager.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The PIN field is required")]
        public long? PIN { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public int PhoneNum { get; set; }

    }
}
