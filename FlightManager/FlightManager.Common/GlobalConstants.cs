using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Common
{
    public class GlobalConstants
    {

        //Reservation
        public const int ClientPinMinLength = 5;

        //TicketType
        public const string TicketTypeRegular = "Regular";
        public const string TicketTypeBusinessClass = "Business Class";

        //User
        public const int UsernameMinLength = 3;
        public const int PasswordMinLength = 3;
        public const int UserPinMinLength = 5;

        //UserRole
        public const string AdminRole = "Admin";
        public const string UserRole = "User";
        public const string DefaultImage = "-";
    }
}
