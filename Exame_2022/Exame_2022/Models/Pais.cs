using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exame_2022.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Nome { get; set; }

        [Required]

        public string Abreviatura { get; set; }

        public ICollection<Empresa> Empresas { get; set; }
    }

}
