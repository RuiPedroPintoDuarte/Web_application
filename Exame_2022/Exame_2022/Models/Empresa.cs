using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exame_2022.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^.+\.([pP][nN][gG])$", ErrorMessage = "Only png files")]
        public string Logotipo { get; set; }
        public string PaisID { get; set; }
        public Pais Pais { get; set; }
    }
}
