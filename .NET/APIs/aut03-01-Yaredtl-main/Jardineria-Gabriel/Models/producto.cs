#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jardineria_Gabriel.Models;

[Table("producto")]
public partial class producto
{
    [Key]
    public int codigo_producto { get; set; }

    [Required]
    [MaxLength(70, ErrorMessage = "El máximo de carácteres es de 70")]
    [MinLength(10, ErrorMessage = "El mínimo de carácteres es de 10")]
    [Unicode(false)]
    public string nombre { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "El máximo de carácteres es de 50")]
    [MinLength(10, ErrorMessage = "El mínimo de carácteres es de 10")]
    [Unicode(false)]
    public string gama { get; set; }

    [Required]
    [MaxLength(25, ErrorMessage = "El máximo de carácteres es de 25")]
    [MinLength(10, ErrorMessage = "El mínimo de carácteres es de 10")]
    [Unicode(false)]
    public string dimensiones { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "El máximo de carácteres es de 50")]
    [MinLength(10, ErrorMessage = "El mínimo de carácteres es de 10")]
    [Unicode(false)]
    public string proveedor { get; set; }

    [Unicode(false)]
    public string descripcion { get; set; }

    public short cantidad_en_stock { get; set; }

    [Column(TypeName = "numeric(15, 2)")]
    public decimal precio_venta { get; set; }

    [Column(TypeName = "numeric(15, 2)")]
    public decimal? precio_proveedor { get; set; }

    [ForeignKey("gama")]
    [InverseProperty("productos")]
    public virtual gama_producto gamaNavigation { get; set; }

    public List<Review>? Reviews { get; set; }
}