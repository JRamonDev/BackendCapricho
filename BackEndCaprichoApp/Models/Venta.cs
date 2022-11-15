using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndCaprichoApp.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha_registro { get; set; }
        public string Municipio { get; set; }
        public decimal MTotal { get; set; }
        public string Error { get; set; }
    }
}
