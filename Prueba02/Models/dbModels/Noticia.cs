using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prueba02.Models.dbModels
{
    public partial class Noticia
    {
        [Key]
        public int IdNoticias { get; set; }
        public int IdUsuario { get; set; }
        [StringLength(250)]
        public string Descripcion { get; set; } = null!;
        public int TipoNoticia { get; set; }
        public string? Imagen { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("Noticia")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
        [ForeignKey("TipoNoticia")]
        [InverseProperty("Noticia")]
        public virtual TipoNoticia TipoNoticiaNavigation { get; set; } = null!;
    }
}
