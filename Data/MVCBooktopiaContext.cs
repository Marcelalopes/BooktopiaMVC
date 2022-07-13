using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCBooktopia.Models;

namespace MVCBooktopia.Data
{
    public class MVCBooktopiaContext : DbContext
    {
        public MVCBooktopiaContext (DbContextOptions<MVCBooktopiaContext> options)
            : base(options)
        {
        }

        public DbSet<MVCBooktopia.Models.ClienteModel>? ClientesModel { get; set; }

        public DbSet<MVCBooktopia.Models.LivroModel>? LivrosModel { get; set; }
    }
}
