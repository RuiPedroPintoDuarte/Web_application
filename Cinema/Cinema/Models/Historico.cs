using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Historico
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Filme")]
        [Display(Name = "Filme")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Utilizador")]
        [Display(Name = "Conta")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
