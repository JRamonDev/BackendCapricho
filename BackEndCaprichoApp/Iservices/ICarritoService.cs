using BackEndCaprichoApp.Models;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Iservices
{
    public interface ICarritoService
    {
        Carrito Add(Carrito oCarrito);
        List<Carrito> Gets();
        Carrito Get(int IdCarrito);
        string Delete(int IdCarrito);
        Carrito Update(Carrito oCarrito);
    }
}
