using BackEndCaprichoApp.Models;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Iservices
{
    public interface IDepartamentoService
    {
        Departamento Add(Departamento oDepartamento);
        List<Departamento> Gets();
        Departamento Get(int IdDepartamento);
        string Delete(int IdDepartamento);
        Departamento Update(Departamento oDepartamento);
    }
}
