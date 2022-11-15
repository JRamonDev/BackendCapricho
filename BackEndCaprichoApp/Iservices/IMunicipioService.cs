using BackEndCaprichoApp.Models;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Iservices
{
    public interface IMunicipioService
    {
        Municipio Add(Municipio oMunicipio);
        List<Municipio> Gets();
        Municipio Get(int IdMunicipio);
        string Delete(int IdMunicipio);
        Municipio Update(Municipio oMunicipio);
    }
}
