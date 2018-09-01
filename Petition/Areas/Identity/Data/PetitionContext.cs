using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Petition.Data;

namespace Petition.Models
{
    public class PetitionContext : IdentityDbContext<Petitioner>
    {
        public PetitionContext(DbContextOptions<PetitionContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Petition.Data.PetitionModel> PetitionModel { get; set; }
        public DbSet<Petition.Data.Support> Support { get; set; }
        public DbSet<Petition.Data.Signature> Signature { get; set; }
    }
}
