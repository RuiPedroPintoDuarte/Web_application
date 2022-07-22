using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Bilhete
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public float Preco { get; set; }

        [ForeignKey("Filme")]
        [Display(Name = "Filme")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Lugar { get; set; }

        [ForeignKey("Horario")]
        [Display(Name = "Horário")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int HorarioId { get; set; }
        public Horario Horario { get; set; }
    }
}
