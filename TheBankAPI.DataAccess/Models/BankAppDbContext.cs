using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBankAPI.DataAccess.Models
{
    public class BankAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public BankAppDbContext(DbContextOptions<BankAppDbContext> options)
            :base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed();
        }
    }
}
