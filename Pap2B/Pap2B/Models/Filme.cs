using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pap2B.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required]
        
        public int Pontuaçao { get; set; }
       
        
    }
}
