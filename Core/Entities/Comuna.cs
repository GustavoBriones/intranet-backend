namespace Core.Entities
{
    public class Comuna: Base
    {
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}