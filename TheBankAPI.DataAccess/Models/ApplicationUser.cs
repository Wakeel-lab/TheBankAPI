using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBankAPI.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AccountType { get; set; }
        public bool TermsOfCondition { get; set; }

    }
}
