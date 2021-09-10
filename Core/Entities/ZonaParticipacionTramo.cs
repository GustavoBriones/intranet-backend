namespace Core.Entities
{
    public class ZonaParticipacionTramo : Base
    {
        public int ZonaParticipacionId { get; set; }
        public ZonaParticipacion ZonaParticipacion { get; set; }
        public int OrdenTramo { get; set; }
        public decimal FinTramo { get; set; }
        public decimal participacion { get; set; }
    }
}