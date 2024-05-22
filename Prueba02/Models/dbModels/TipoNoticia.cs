using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    public partial class TipoNoticia
    {
        public TipoNoticia()
        {
            Noticia = new HashSet<Noticia>();
        }

        [Key]
        [Column("TipoNoticia")]
        public int TipoNoticia1 { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("TipoNoticiaNavigation")]
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
