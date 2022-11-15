using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndCaprichoApp.Models
{
    public class Municipio
    {
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; }
        [ForeignKey("DepartamentoId")]
        public int DepartamentoId { get; set; }
        public string Error { get; set; }
    }
}
