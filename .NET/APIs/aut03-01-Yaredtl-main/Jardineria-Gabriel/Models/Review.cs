using System.ComponentModel.DataAnnotations;

namespace Jardineria_Gabriel.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Debe contener mínimo 3 carácteres")]
        [MaxLength(15, ErrorMessage = "Debe contener máximo 15 carácteres")]
        public string Title { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Debe contener mínimo 5 carácteres")]
        [MaxLength(50, ErrorMessage = "Debe contener máximo 50 carácteres")]
        public string Description { get; set; }

        [Required]
        [Range(1,5,ErrorMessage = "Debe tener un valor entre 1 y 5")]
        public int Stars { get; set; }

        public int ProductId { get; set; }
        public producto? producto { get; set; }

        public string? UserId { get; set; }

    }
}
