using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBankAPI.Services.Utilities;

namespace TheBankAPI.DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Other names is required")]
        public string OtherNames { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string MobileNUmber { get; set; }
        [Required(ErrorMessage ="Please fill in your date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Please choose an account type out of the three available:" +
            "Savings, Current and Fixed")]
        public AccountType AccountType { get; set; }
        [Required(ErrorMessage ="Please agree to the terms and condition")]
        public bool TermsOfCondition { get; set; }
    }
}
