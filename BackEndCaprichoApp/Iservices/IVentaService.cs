using BackEndCaprichoApp.Models;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Iservices
{
    public interface IVentaService
    {
        Venta Add(Venta oVenta);
        List<Venta> Gets();
        Venta Get(int IdVenta);
        string Delete(int IdVenta);
        Venta Update(Venta oVenta);
    }
}
