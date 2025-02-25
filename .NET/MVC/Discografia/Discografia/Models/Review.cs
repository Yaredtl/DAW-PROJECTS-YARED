using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Discografia.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(10,ErrorMessage ="Debe tener como máximo 10 carácteres")]
        [MinLength(3, ErrorMessage = "Debe tener como mínimo 3 carácteres")]
        [DisplayName("Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "Debe tener como máximo 30 carácteres")]
        [MinLength(5, ErrorMessage = "Debe tener como mínimo 5 carácteres")]
        [DisplayName("Descripcion")]
        public string Description {  get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1,5, ErrorMessage = "El valor debe estar entre 1 y 5") ]
        [DisplayName("Valoracion")]
        public int Points { get; set; }

        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
