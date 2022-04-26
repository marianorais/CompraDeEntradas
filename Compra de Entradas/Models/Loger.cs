using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Compra_de_Entradas.Models
{
    public class Loger
    {
        [Required(ErrorMessage = "The username is Required")]
        [StringLength(30)]
        public string Username { get; set; }
        [Required(ErrorMessage = "The password is Required")]
        [StringLength(15)]
        public string Password { get; set; }
    }
}
