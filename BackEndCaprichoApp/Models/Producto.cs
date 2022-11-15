using System;

namespace BackEndCaprichoApp.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public DateTime Fecha_registro { get; set; }
        public string PhotoFileName { get; set; }
        public string Error { get; set; }
    }
}
