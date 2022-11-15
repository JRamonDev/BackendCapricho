using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndCaprichoApp.Models
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        [ForeignKey("VentaId")]
        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public decimal ProductoPrecio { get; set; }
        public int Cantidad { get; set; }
        public string Error { get; set; }
    }
}
