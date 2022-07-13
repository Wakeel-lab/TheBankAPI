using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBankAPI.Services.Utilities;

namespace TheBankAPI.DataAccess.Models
{
    public static class ModelBuilderSeedDataExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "Akin",
                MiddleName = "Oye",
                LastName = "Balogun",
                MobileNumber = "07065877428",
                Image = "akinoye.jpg",
                Email = "akinoye@gmail.com",
                Department = Department.IT
            },
            new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                MiddleName = "Elochie",
                LastName = "Agbakogba",
                MobileNumber = "08118864144",
                Image = "sarahelo.jpg",
                Email = "sarahelochie@gmail.com",
                Department = Department.HR
            },
            new Employee
            {
                Id = 3,
                FirstName = "Azeez",
                MiddleName = "Akanbi",
                LastName = "Olatunde",
                MobileNumber = "08088990059",
                Image = "azeez.jpg",
                Email = "azeeztunde@gmail.com",
                Department = Department.Marketing
            }
            );
        }
    }
}
