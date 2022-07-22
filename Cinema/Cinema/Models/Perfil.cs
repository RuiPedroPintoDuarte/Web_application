using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Perfil
    {
        public int Id { get; set; }

        public int Telefone { get; set; }

        public string Username { get; set; }

        public virtual ICollection<Historico> Historicos { get; set; }
    }
}
