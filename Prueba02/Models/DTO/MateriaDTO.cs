using System.ComponentModel.DataAnnotations;

namespace Prueba02.Models.DTO
{
    public class MateriaDTO
    {
        [Required]
        public int IdMateria { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;
    }
}
