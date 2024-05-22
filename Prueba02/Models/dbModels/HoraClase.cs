using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    [Table("HoraClase")]
    public partial class HoraClase
    {
        public HoraClase()
        {
            GrupoHoraFinNavigations = new HashSet<Grupo>();
            GrupoHoraInicioNavigations = new HashSet<Grupo>();
        }

        [StringLength(50)]
        public string Descripcion { get; set; } = null!;
        public TimeSpan Hora { get; set; }
        [Key]
        public int IdHoraClase { get; set; }

        [InverseProperty("HoraFinNavigation")]
        public virtual ICollection<Grupo> GrupoHoraFinNavigations { get; set; }
        [InverseProperty("HoraInicioNavigation")]
        public virtual ICollection<Grupo> GrupoHoraInicioNavigations { get; set; }
    }
}
