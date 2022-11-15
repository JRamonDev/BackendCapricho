using BackEndCaprichoApp.Models;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Iservices
{
    public interface ICategoriaService
    {
        Categoria Add(Categoria oCategoria);
        List<Categoria> Gets();
        Categoria Get(int IdCategoria);
        string Delete(int IdCategoria);
        Categoria Update(Categoria oCategoria);
    }
}
