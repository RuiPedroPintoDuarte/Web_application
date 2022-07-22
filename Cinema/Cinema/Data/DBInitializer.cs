using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class DBInitializer
    {
        public static void Initialize(CinemaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categorias.Any())
                return;

            var categorias = new Categoria[]
            {
                new Categoria {Nome="Comédia"},
                new Categoria {Nome="Romance"},
                new Categoria {Nome="Terror"}
            };

            foreach (Categoria c in categorias)
                context.Categorias.Add(c);

            context.SaveChanges();
        }
    }
}
