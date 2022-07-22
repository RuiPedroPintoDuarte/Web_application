using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteXD.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Likes { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime Data { get; set; }



    }
}
