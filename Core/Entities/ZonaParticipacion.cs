namespace Core.Entities
{
    public class ZonaParticipacion : Base
    {
        public int ZonaGrupoParticipacionId { get; set; }
        public ZonaGrupoParticipacion ZonaGrupoParticipacion { get; set; }
        public string Nombre { get; set; }
        public decimal PorcVenta { get; set; }
        public decimal PorcGtoExplotacion { get; set; }
        public decimal PorcUnico { get; set; }
    }
}