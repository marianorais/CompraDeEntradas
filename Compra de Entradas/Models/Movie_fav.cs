using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Models
{
    public class Movie_fav
    {
        [Key]
        [Required(ErrorMessage = "Id is Required")]
        public int Id_pelicula { get; set; }
        [Required(ErrorMessage = "Titulo is Required")]
        [StringLength(50, MinimumLength = 3)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Duracion is Required")]
        public int Duracion { get; set; }
        [Required(ErrorMessage = "Anio is Required")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "Id of usuario is Required")]
        public int Id_usuario { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
