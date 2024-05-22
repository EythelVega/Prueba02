using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    [Table("ImagenesError")]
    public partial class ImagenesError
    {
        [Key]
        public int IdImagen { get; set; }
        public int IdError { get; set; }
        public string Imagen { get; set; } = null!;

        [ForeignKey("IdError")]
        [InverseProperty("ImagenesErrors")]
        public virtual ReporteError IdErrorNavigation { get; set; } = null!;
    }
}
