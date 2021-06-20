using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidos.Models
{
    public class OrdenesDetalle
    {
        [Key]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(1, 1000000, ErrorMessage = "Este campo no puede ser menor a 1.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(1, 1000000, ErrorMessage = "Este campo no puede ser menor a 1.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Costo { get; set; }

        public OrdenesDetalle()
        {
            Id = 0;
            OrdenId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Costo = 0;
        }

        public OrdenesDetalle(int ordenId, int productoId, int cantidad, decimal costo)
        {
            Id = 0;
            OrdenId = ordenId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Costo = costo;
        }
    }
}
