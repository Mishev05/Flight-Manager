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
        [StringLength(30, ErrorMessage = "First name must be longer than 1 letters.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contain only letters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Last name must be longer than 1 letters.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The PIN field is required")]
        [StringLength(10, ErrorMessage = "PIN must be exactly 10 digits long.")]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "PIN must contain only digits.")]
        [Display(Name = "PIN")]
        public string PIN { get; set; }

        [Required(ErrorMessage = "The Address field is required")]
        [Display(Name = "Address")]
        [MinLength(3)]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Phone number field is required")]
        [Display(Name = "Phone number")]
        [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits long.")]
        [MinLength(10)]
        public int PhoneNum { get; set; }

    }
}
