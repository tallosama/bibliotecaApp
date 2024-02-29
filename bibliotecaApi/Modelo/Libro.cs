using System;
using System.ComponentModel.DataAnnotations;

namespace bibliotecaApi.Modelo
{
    public class Libro

    {
        [Key]
        [Required]
        public int idLibro { get; set; }
        [Required]
        public string titulo{ get; set; }
        [Required]
        public DateTime tiempoRegistro { get; set; }
        public DateTime? tiempoModificacion { get; set; }
        [Required]
        public bool activo { get; set; }

        [Required]
        public Categoria categoriaId{ get; set; }


    }
}
