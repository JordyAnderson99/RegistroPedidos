using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidos.Models
{
    public class Ordenes
    {
        [Key]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int OrdenId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime Fecha { get; set; }

        [Range(1, 1000000, ErrorMessage = "Este campo no puede ser menor a 1.")]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Este campo no puedo estar vacio.")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public List<OrdenesDetalle> OrdenesDetalle { get; set; }

        public Ordenes()
        {
            OrdenId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            Monto = 0;

            OrdenesDetalle = new List<OrdenesDetalle>();
        }
    }
}
