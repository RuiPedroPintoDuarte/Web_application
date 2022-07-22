using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Exame2021.Models
{
    public class Download
    {
        [Key]
        public int Id { get; set; }
        public string Utilizador { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int DocumentoID { get; set; }
        public Documento Documento { get; set; }

    }
}
