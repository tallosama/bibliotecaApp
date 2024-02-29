using System;
using System.ComponentModel.DataAnnotations;

namespace bibliotecaApi.Modelo
{
    public class NuevoLibro
    {
        public string titulo { get; set; }
        public int categoriaId { get; set; }

    }

}
