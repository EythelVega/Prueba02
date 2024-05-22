using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    public partial class GrupoEstudiante
    {
        [Key]
        public int IdGrupo { get; set; }
        [Key]
        public int IdEstudiantes { get; set; }
        public int? Calificacion { get; set; }

        [ForeignKey("IdEstudiantes")]
        [InverseProperty("GrupoEstudiantes")]
        public virtual ApplicationUser IdEstudiantesNavigation { get; set; } = null!;
        [ForeignKey("IdGrupo")]
        [InverseProperty("GrupoEstudiantes")]
        public virtual Grupo IdGrupoNavigation { get; set; } = null!;
    }
}
