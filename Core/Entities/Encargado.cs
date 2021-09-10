using System;

namespace Core.Entities
{
    public class Encargado : Base
    {
        public int EncargadoTipoId { get; set; }
        public EncargadoTipo EncargadoTipo { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}