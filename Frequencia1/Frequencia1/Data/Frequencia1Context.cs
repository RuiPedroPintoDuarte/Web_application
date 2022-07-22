using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Frequencia1.Models;

namespace Frequencia1.Data
{
    public class Frequencia1Context : DbContext
    {
        public Frequencia1Context (DbContextOptions<Frequencia1Context> options)
            : base(options)
        {
        }

        public DbSet<Frequencia1.Models.Livro> Livro { get; set; }
    }
}
