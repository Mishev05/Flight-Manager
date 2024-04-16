using FlightManager.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Data.Models
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DepartureTime >= ArrivalTime)
            {
                yield return new ValidationResult("Arrival time must be after Departure time", new[] { "ArrivalTime" });
            }

            if (DestinationTo == DestinationFrom)
            {
                yield return new ValidationResult("DestinationTo and DestinationFrom cannot be the same", new[] { "DestinationTo", "DestinationFrom" });
            }
        }

        [Required]
        [Key]
        public int PlaneId { get; set; }

        [Required]
        [Display(Name = "Destination From")]
        [StringLength(30, ErrorMessage = "Destination must be longer than 1 letter.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Location must contain only letters.")]
        public string DestinationFrom { get; set; }

        [Required]
        [Display(Name = "Destination To")]
        [StringLength(30, ErrorMessage = "Destination must be longer than 1 letter.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Location must contain only letters.")]
        public string DestinationTo { get; set; }

        [Required]
        [Display(Name = "Arrival Time")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy/ HH-mm}")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [Display(Name = "Departure Time")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy/ HH-mm}")]
        [DataType(DataType.DateTime)]
        public DateTime DepartureTime { get; set; }
        
        [Required]
        [Display(Name = "Plane Type")]
        public string PlaneType { get; set; }

        [Required]
        [MaxLength(5)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Z\d]+$", ErrorMessage = "Plane Code must contain only uppercase letters and digits.")]
        [Display(Name = "Plane Code")]
        public int UniquePlaneNumber { get; set; }

        [Required]
        [Display(Name = "Pilot Name")]
        [StringLength(50, ErrorMessage = "Pilot name must be longer than 1 letters.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Pilot name must contain only letters.")]
        public string PilotName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(300)]
        [Display(Name = "Passengers Capacity")]
        public int PassengersCapacity { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [Display(Name = "Business Capacity")]
        public int BusinessClassCapacity { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
