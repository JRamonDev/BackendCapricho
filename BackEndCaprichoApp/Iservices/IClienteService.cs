using BackEndCaprichoApp.Models;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Iservices
{
    public interface IClienteService
    {
        Cliente Add(Cliente oCliente);
        List<Cliente> Gets();
        Cliente Get(int IdCliente);
        string Delete(int IdCliente);
        Cliente Update(Cliente oCliente);
    }
}
