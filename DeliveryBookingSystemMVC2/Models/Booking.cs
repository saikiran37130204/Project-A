using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBookingSystemMVC2.Models
{
    public class Booking
    {
        [Key]
        public int orderID { get; set; }
        [Display(Name ="User id")]
        public int customerID { get; set; }
        [Display(Name = "Executive id")]
        [Required(ErrorMessage ="Executive id can not be empty")]
        public int executiveID { get; set; }
        [Required(ErrorMessage = "Date and time can not be empty")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Weight can not be empty")]
        [Display(Name ="Weight of package")]
        public float weight { get; set; }
        [Required(ErrorMessage = "Price can not be empty")]
        public float price { get; set; }
        [Required(ErrorMessage = "Address can not be empty")]
        public string address { get; set; }
        [Required(ErrorMessage = "city can not be empty")]
        public string city { get; set; }
        [Required(ErrorMessage = "pincode cannot be empty")]
        [RegularExpression("^[0-9]*$",ErrorMessage="Invalid pincode")]
       // [MaxLength(6)]
        public int pincode { get; set; }
        [Required(ErrorMessage = "phone number cannot be empty")]
        [MaxLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "enter only numbers")]
        public string phone { get; set; }
        public string status { get; set; }
    }
}
