namespace Core.Entities
{
    public class Provincia : Base
    {
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}