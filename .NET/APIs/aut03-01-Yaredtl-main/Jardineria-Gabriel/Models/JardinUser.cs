using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Jardineria_Gabriel.Models
{
    public class JardinUser : IdentityUser
    {
        [Required]
        [MinLength(10,ErrorMessage = "Minímo 10 carácteres")]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Range(00001,99999, ErrorMessage = "El formato del codigo postal es 38XXX")]
        public int PostalCode { get; set; }

        [Required]
        [Range(100000000,999999999, ErrorMessage = "El formato debe ser XXXXXXXXX")]
        public int Phone { get; set; }
    }
}
