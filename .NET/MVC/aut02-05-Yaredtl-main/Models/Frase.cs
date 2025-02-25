using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace AUT02_05.Models
{
    public class Frase
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Frase en español")]
        [StringLength(100, ErrorMessage = "No puede superar los 100 caracteres")]
        [MinLength(5,ErrorMessage = "No puede ser inferior a 5 caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string fraesp { get; set; }

        [DisplayName("Frase en ingles")]
        [StringLength(100, ErrorMessage = "No puede superar los 100 caracteres")]
        [MinLength(5, ErrorMessage = "No puede ser inferior a 5 caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string fraing { get; set; }

        public int EspengID {get; set; }
        public Espeng? Espeng { get; set; }

        public string? IdUser { get; set; }
        public IdentityUser? User { get; set; } 
    }
}
