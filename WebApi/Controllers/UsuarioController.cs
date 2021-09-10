using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<Usuario> _manager;
        private readonly SignInManager<Usuario> _signManager;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<Usuario> _hasher;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioController(
            UserManager<Usuario> manager,
            SignInManager<Usuario> signManager,
            ITokenService tokenService,
            IPasswordHasher<Usuario> hasher,
            RoleManager<IdentityRole> roleManager)
        {
            _manager = manager;
            _signManager = signManager;
            _tokenService = tokenService;
            _hasher = hasher;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
        {
            var usuario = await _manager.FindByEmailAsync(loginDto.Email);

            if (usuario == null)
            {
                return Unauthorized(new CodeErrorResponse(401, "El usuario no existe"));
            }

            var resultado = await _signManager.CheckPasswordSignInAsync(usuario, loginDto.Password, false);

            if (!resultado.Succeeded)
            {
                return Unauthorized(new CodeErrorResponse(401, "Contraseña invalida"));
            }

            var roles = await _manager.GetRolesAsync(usuario);

            return new UsuarioDto
            {
                Email = usuario.Email,
                Username = usuario.UserName,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Token = _tokenService.CreateToken(usuario, roles),
                Admin = roles.Contains("ADMIN")
            };

        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDto>> Registrar(RegistroDto registroDto)
        {
            var usuario = new Usuario
            {
                Email = registroDto.Email,
                UserName = registroDto.Username,
                Nombre = registroDto.Nombre,
                Apellidos = registroDto.Apellidos
            };
            var resultado = await _manager.CreateAsync(usuario, registroDto.Password);
            if (!resultado.Succeeded)
            {
                return BadRequest(new CodeErrorResponse(400, "Error al crear el usuario"));
            }
            return new UsuarioDto
            {
                Username = usuario.UserName,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Token = _tokenService.CreateToken(usuario, null),
                Admin = false
            };
        }

        [Authorize]
        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<UsuarioDto>> Actualizar(string id, RegistroDto registroDto)
        {
            var usuario = await _manager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new CodeErrorResponse(404, "El usuario no existe"));
            }
            usuario.Nombre = registroDto.Nombre;
            usuario.Apellidos = registroDto.Apellidos;

            if (!string.IsNullOrEmpty(registroDto.Password))
            {
                usuario.PasswordHash = _hasher.HashPassword(usuario, registroDto.Password);
            }

            var resultado = await _manager.UpdateAsync(usuario);
            if (!resultado.Succeeded)
            {
                return BadRequest(new CodeErrorResponse(400, "No se pudo actualizar el usuario"));
            }

            var roles = await _manager.GetRolesAsync(usuario);

            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Username = usuario.UserName,
                Token = _tokenService.CreateToken(usuario, roles),
                Admin = roles.Contains("ADMIN")
            };
        }

        [Authorize]
        [HttpGet("account/{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarioById(string id)
        {
            var usuario = await _manager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new CodeErrorResponse(404, "El Usuario no existe"));
            }

            var roles = await _manager.GetRolesAsync(usuario);

            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Username = usuario.UserName,
                Email = usuario.Email,
                Admin = roles.Contains("ADMIN")
            };
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> GetUsuario()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var usuario = await _manager.FindByEmailAsync(email);
            var roles = await _manager.GetRolesAsync(usuario);
            return new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Username = usuario.UserName,
                Email = usuario.Email,
                Token = _tokenService.CreateToken(usuario, roles),
                Admin = roles.Contains("ADMIN")
            };
        }

        [HttpGet("emailvalido")]
        public async Task<ActionResult<bool>> ValidarEmail([FromQuery] string email)
        {
            var usuario = await _manager.FindByEmailAsync(email);
            if (usuario == null) return false;
            return true;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut]
        public async Task<ActionResult<UsuarioDto>> UpdateRole(string id, RoleDto roleParam)
        {
            var role = await _roleManager.FindByNameAsync(roleParam.Nombre);
            if (role == null)
            {
                return NotFound(new CodeErrorResponse(404, "El rol no existe"));
            }

            var usuario = await _manager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new CodeErrorResponse(404, "El usuario no existe"));
            }

            var usuarioDto = new UsuarioDto
            {
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Username = usuario.UserName
            };

            if (roleParam.Status)
            {
                var resultado = await _manager.AddToRoleAsync(usuario, roleParam.Nombre);
                if (resultado.Succeeded)
                {
                    usuarioDto.Admin = true;
                }
                if (resultado.Errors.Any())
                {
                    if (resultado.Errors.Where(x => x.Code == "UserAlreadyInRole").Any())
                    {
                        usuarioDto.Admin = true;
                    }
                }
            }
            else
            {
                var resultado = await _manager.RemoveFromRoleAsync(usuario, roleParam.Nombre);
                if (resultado.Succeeded)
                {
                    usuarioDto.Admin = false;
                }
            }

            var roles = await _manager.GetRolesAsync(usuario);
            usuarioDto.Token = _tokenService.CreateToken(usuario, roles);

            return usuarioDto;
        }
    }
}