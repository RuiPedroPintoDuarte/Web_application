using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Teste2022Turno1.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256, ErrorMessage ="length cannot exceed {1} characters")]
        public string Titulo { get; set; }
        [Required]
        [DataType(DataType.Duration)]
        public int Duração { get; set; }
        public bool Estado { get; set; } = true;

    }
}
