using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Usuario usuario, IList<string> roles);
    }
}