using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Models
{
    public class User
    {
        [Display(Name ="User Type")]
        public string UserType { get; set; }
        [Required(ErrorMessage = "username cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "password cannot be empty")]
        public string Password { get; set; }

    }
}
