using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Data
{
    public class SeguridadDbContextData
    {
        public static async Task SeedUserAsync(UserManager<Usuario> manager, RoleManager<IdentityRole> roleManager)
        {
            if (!manager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Sistemas",
                    Apellidos = "Hipodromo Chile",
                    UserName = "admin",
                    Email = "sistemas@hipodromochile.cl"
                };

                await manager.CreateAsync(usuario, "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918");
            }

            if (!roleManager.Roles.Any())
            {
                var role = new IdentityRole
                {
                    Name = "ADMIN"
                };
                await roleManager.CreateAsync(role);
            }
        }
    }
}