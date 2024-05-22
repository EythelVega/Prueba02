using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    [Keyless]
    [Table("HoraClases")]
    public partial class HoraClase1
    {
        [StringLength(50)]
        public string? Descripcion { get; set; }
        public int? IdHora { get; set; }
        public int? IdHoraClase { get; set; }

        [ForeignKey("IdHora")]
        public virtual Grupo? IdHoraNavigation { get; set; }
    }
}
