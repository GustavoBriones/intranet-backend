namespace Core.Entities
{
    public class Comunidad : Base
    {
        public string Comunidad_Id { get; set; }
        public string Nombre { get; set; }
        public int AsociacionId { get; set; }
        public Asociacion Asociacion { get; set; }
    }
}