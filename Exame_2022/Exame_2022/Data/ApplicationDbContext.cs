using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Exame_2022.Models;

namespace Exame_2022.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
    }
        public DbSet<Exame_2022.Models.Pais> Paises { get; set; }
        public DbSet<Exame_2022.Models.Empresa> Empresas { get; set; }
    }
}
