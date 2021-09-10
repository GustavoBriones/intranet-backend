using Core.Entities;

namespace Core.Specifications
{
    public class ComunidadSpec : BaseSpecification<Comunidad>
    {
        public ComunidadSpec()
        {
            AddInclude(c => c.Asociacion);
        }

        public ComunidadSpec(int id) : base(c => c.Id == id)
        {
            AddInclude(c => c.Asociacion);
        }
    }
}