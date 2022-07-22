using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Sala
    {
        [Key]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Capacidade { get; set; }

        public virtual ICollection<Horario> Horarios { get; set; }
    }
}
