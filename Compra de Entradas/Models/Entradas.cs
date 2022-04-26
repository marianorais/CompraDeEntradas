using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Models
{
    public class Entradas
    {
        [Key]
        [Required(ErrorMessage = "Id is Required")]
        public int Id_entrada { get; set; }
        [Required(ErrorMessage = "The amount is Required")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "The location is Required")]
        [StringLength(10)]
        public string Fila { get; set; }
        public int Id_usuario { get; set; }
        public int Id_pelicula { get; set; }
        // [Required(ErrorMessage = "The User is Required")]
        public virtual Usuarios Usuarios { get; set; }
        public virtual Peliculas Peliculas { get; set; }
    }
}
