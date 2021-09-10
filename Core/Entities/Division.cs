using System;

namespace Core.Entities
{
    public class Division : Base
    {
        public string Division_Id { get; set; }
        public int ComunidadId { get; set; }
        public Comunidad Comunidad { get; set; }
        public string Nombre { get; set; }
        public string Nombre_BI { get; set; }
        public int ZonaPArticipacionId { get; set; }
        public ZonaParticipacion ZonaParticipacion { get; set; }
        public int DivisionCategoriaId { get; set; }
        public DivisionCategoria DivisionCategoria { get; set; }
        public int DivisionTipoAsociadoId { get; set; }
        public DivisionTipoAsociado DivisionTipoAsociado { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int ComunaId { get; set; }
        public Comuna Comuna { get; set; }
        public int EncargadoId { get; set; }
        public Encargado Encargado { get; set; }
        public string Direccion { get; set; }
    }
}