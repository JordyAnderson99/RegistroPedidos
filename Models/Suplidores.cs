using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidos.Models
{
    public class Suplidores
    {
        [Key]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [MinLength(4, ErrorMessage = "Este campo no puede tener menos de 4 caracteres.")]
        [MaxLength(50, ErrorMessage = "Ha alcanzado el maximo de caracteres.")]
        public string Nombres { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Nombres = string.Empty;
        }
    }
}
