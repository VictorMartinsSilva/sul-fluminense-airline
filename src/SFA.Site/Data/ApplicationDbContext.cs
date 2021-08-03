using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SFA.Site.ViewModels;

namespace SFA.Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SFA.Site.ViewModels.AddressViewModels> AddressViewModels { get; set; }
        public DbSet<SFA.Site.ViewModels.PassengerViewModels> PassengerViewModels { get; set; }
    }
}
