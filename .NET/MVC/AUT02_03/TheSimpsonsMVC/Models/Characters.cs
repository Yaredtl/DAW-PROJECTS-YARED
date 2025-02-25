using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheSimpsonsMVC.Models
{
    public class Character
    {

        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Minimo debe contener 3 carácteres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No puede contener numeros")]
        public string name { get; set; }

        [DisplayName("Edad")]
        [Required(ErrorMessage = "Este campo es obligatorio")] 
        [Range(0, 100, ErrorMessage = "Minímo: 0 | Máximo: 100")]
        public int? age { get; set; }

        [DisplayName("Trabajo")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Minimo debe contener 5 carácteres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No puede contener numeros")]
		public string job { get; set; }
    }

}
