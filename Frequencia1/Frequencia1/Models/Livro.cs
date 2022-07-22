using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frequencia1.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Field Required")]

        public string Autores { get; set; }
        [Required(ErrorMessage = "Field Required")]

        public string Editora { get; set; }
        [Required(ErrorMessage = "Field Required")]

        public string ISBN { get; set; }
        
        [Required(ErrorMessage = "Field Required")]
        [DataType(DataType.ImageUrl)]
        public string Capa { get; set; }


        
        [Required(ErrorMessage = "Field Required")]
        [DataType(DataType.ImageUrl)]
       
        public string Contracapa { get; set; }
       
    }
}
