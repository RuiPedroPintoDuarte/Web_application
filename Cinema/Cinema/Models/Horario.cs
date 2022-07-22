using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Horario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Filme")]
        [Display(Name = "Filme")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Dia { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Hora { get; set; }

        [ForeignKey("Sala")]
        [Display(Name = "Sala")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        public virtual ICollection<Bilhete> Bilhetes { get; set; }
    }
}
