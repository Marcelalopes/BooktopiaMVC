using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCBooktopia.Models;

namespace MVCBooktopia.Data
{
    public class MVCBooktopiaContext : IdentityDbContext<IdentityUser>
    {
        public MVCBooktopiaContext(DbContextOptions<MVCBooktopiaContext> options)
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

        public DbSet<ClienteModel>? ClientesModel { get; set; }

        public DbSet<LivroModel>? LivrosModel { get; set; }

        public DbSet<AluguelModel>? AlugueisModel { get; set; }
    }
}