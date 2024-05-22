using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    [Table("ReporteError")]
    public partial class ReporteError
    {
        public ReporteError()
        {
            ImagenesErrors = new HashSet<ImagenesError>();
        }

        [Key]
        public int IdReporteError { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(255)]
        public string CorreoElectronico { get; set; } = null!;
        [StringLength(100)]
        public string Descripcion { get; set; } = null!;
        [StringLength(150)]
        public string? PasosParaReproducirError { get; set; }
        [StringLength(50)]
        public string? UrlPaginaError { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaError { get; set; }

        [InverseProperty("IdErrorNavigation")]
        public virtual ICollection<ImagenesError> ImagenesErrors { get; set; }
    }
}
