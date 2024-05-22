using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    [Table("Grupo")]
    public partial class Grupo
    {
        public Grupo()
        {
            GrupoEstudiantes = new HashSet<GrupoEstudiante>();
        }

        [Key]
        public int IdGrupo { get; set; }
        public int IdMaestro { get; set; }
        public int IdMateria { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }

        [ForeignKey("HoraFin")]
        [InverseProperty("GrupoHoraFinNavigations")]
        public virtual HoraClase HoraFinNavigation { get; set; } = null!;
        [ForeignKey("HoraInicio")]
        [InverseProperty("GrupoHoraInicioNavigations")]
        public virtual HoraClase HoraInicioNavigation { get; set; } = null!;
        [ForeignKey("IdMaestro")]
        [InverseProperty("Grupos")]
        public virtual ApplicationUser IdMaestroNavigation { get; set; } = null!;
        [ForeignKey("IdMateria")]
        [InverseProperty("Grupos")]
        public virtual Materium IdMateriaNavigation { get; set; } = null!;
        [InverseProperty("IdGrupoNavigation")]
        public virtual ICollection<GrupoEstudiante> GrupoEstudiantes { get; set; }
    }
}
