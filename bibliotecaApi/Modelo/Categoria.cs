using System;
using System.ComponentModel.DataAnnotations;

namespace bibliotecaApi.Modelo
{
    public class Categoria
    {
        [Key]
        [Required]
        public int idCategoria { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public DateTime tiempoRegistro { get; set; }
        public DateTime? tiempoModificacion { get; set; }
        [Required]
        public bool  activo { get; set; }

    }
}
