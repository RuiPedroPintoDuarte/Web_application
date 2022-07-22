using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        [ForeignKey("Categoria")]
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Realizador { get; set; }

        [Display(Name ="Duração")]
        [DataType(DataType.Duration)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Duracao { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Foto { get; set; }

        public virtual ICollection<Horario> Horarios { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
        public virtual ICollection<Bilhete> Bilhetes { get; set; }
    }
}
