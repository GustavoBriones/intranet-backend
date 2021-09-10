using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}