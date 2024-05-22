using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    public partial class Materium
    {
        public Materium()
        {
            Grupos = new HashSet<Grupo>();
        }

        [Key]
        public int IdMateria { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdMateriaNavigation")]
        public virtual ICollection<Grupo> Grupos { get; set; }
    }
}
