using System;
using System.ComponentModel.DataAnnotations;

namespace MapuaCanteen.Models
{
    public class StudentAccounts
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Student number")]
        public int StudentNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastTransaction { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
