using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Prueba02.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            GrupoEstudiantes = new HashSet<GrupoEstudiante>();
            Grupos = new HashSet<Grupo>();
            Noticia = new HashSet<Noticia>();
        }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(50)]
        public string Apellido { get; set; } = null!;
        public int Matricula { get; set; }
        
        public virtual ICollection<GrupoEstudiante> GrupoEstudiantes { get; set; }
        [InverseProperty("IdMaestroNavigation")]
        public virtual ICollection<Grupo> Grupos { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
