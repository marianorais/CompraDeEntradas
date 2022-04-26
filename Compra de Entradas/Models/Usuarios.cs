using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Models
{
    public class Usuarios
    {
        [Key]
        [Required(ErrorMessage = "Id is Required")]
        public int Id_usuario { get; set; }
        [Required(ErrorMessage = "The username is Required")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The email is Required")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password is Required")]
        [StringLength(50)]
        
        public string Password { get; set; }
        public virtual List<Entradas> Entrada { get; set; }
        public List<Movie_fav> MovieFav { get; set; }

    }
}
