using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Models
{
    public class DeliveryExecutive
    {
        [Key]
        public int executiveID { get; set; }
        [Required(ErrorMessage ="name cannot be empty")]
        public string name { get; set; }
        [Required(ErrorMessage = "username cannot be empty")]
        public string username { get; set; }
        [Required(ErrorMessage = "password cannot be empty")]
        public string password { get; set; }
        [Required(ErrorMessage = "age cannot be empty")]
        [RegularExpression("^[0-9]*$", ErrorMessage="numbers only")]
        public int age { get; set; }
        [Required(ErrorMessage = "phone number cannot be empty")]
        [MaxLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "enter only numbers")]
        public string phone { get; set; }
        [Required(ErrorMessage = "address cannot be empty")]
        public string address { get; set; }
        [Required(ErrorMessage = "city cannot be empty")]
        public string city { get; set; }
        [Display(Name ="Verification")]
        public string isVerified { get; set; }
    }
}
