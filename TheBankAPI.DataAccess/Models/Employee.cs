using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBankAPI.Services.Utilities;

namespace TheBankAPI.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Image { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }
        public Department Department { get; set; }
    }
}
