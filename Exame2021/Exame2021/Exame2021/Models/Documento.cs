using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Exame2021.Models
{
    public class Documento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Required")]
        public string Titulo { get; set; }

        [Required]
        [RegularExpression(@"^.+\.([pP][dD][fF])$", ErrorMessage ="Only pdf files")]
        public string Nome { get; set; }

        public ICollection<Download> Downloads { get; set; }
    }
}
