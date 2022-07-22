using System.ComponentModel.DataAnnotations;

namespace TestePratico2_T2_2021.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string User { get; set; }
    }
}
