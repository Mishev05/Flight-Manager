using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data.Models
{
    public class User :IdentityUser
    {
        public User()
        {
            EmailConfirmed = true;
        }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string NationalId { get; set; }

        public string Address { get; set; }
        public string UCN { get; set; }
        public string? MainRole { get; set; }



        //safafsaf
        //    asf
        //    asf
        //    as
        //    CallConvFastcallff
        //    sf
        //    fas
        //    ffas
        //    fas
        //    fa
        //    sfa
        //    sfa
        //    sf
        //    asf
        //    af3
        //    r1
        //    af
        //    asczxvzxvfas

    }
}
