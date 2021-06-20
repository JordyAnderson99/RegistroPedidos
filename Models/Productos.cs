using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidos.Models
{
    public class Productos
    {
        [Key]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Este campo no pude estar vacio.")]
        [MinLength(4, ErrorMessage = "Este campo no puede tener menos de 4 caracteres.")]
        [MaxLength(200, ErrorMessage = "Ha alcanzado el maximo de caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Inventario { get; set; }


        public Productos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Inventario = 0;

        }
    }
}
