using System;

namespace BackEndCaprichoApp.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string Error { get; set; }

    }
}
