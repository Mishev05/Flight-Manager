using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "First name must be longer than 1 letters.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contain only letters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Middle name must be longer than 2 letters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Middle name must contain only letters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Last name must be longer than 2 letters.", MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        [StringLength(10, ErrorMessage = "PIN must be exactly 10 digits long.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "PIN must contain only digits.")]
        public long PIN { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits long.", MinimumLength = 10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        [MaxLength(50)]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "Ticket Type")]
        [RegularExpression("^(Ordinary|Business)$", ErrorMessage = "Ticket Type must be either Regular or Business.")]
        [StringLength(8, MinimumLength = 7)]
        public string TicketType { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
