using BackEndCaprichoApp.Models;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Iservices
{
    public interface IProductoService
    {
        Producto Add(Producto oProducto);
        List<Producto> Gets();
        Producto Get(int IdProducto);
        string Delete(int IdProducto);
        Producto Update(Producto oProducto);
    }
}
