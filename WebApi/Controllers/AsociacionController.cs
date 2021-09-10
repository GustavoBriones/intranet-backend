using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsociacionController : ControllerBase
    {
        private readonly IGenericRepository<Asociacion> _asociacionRepository;

        public AsociacionController(IGenericRepository<Asociacion> asociacionRepository)
        {
            _asociacionRepository = asociacionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Asociacion>>> GetAsociaciones()
        {
            var asociaciones = await _asociacionRepository.GetAllAsync();
            return Ok(asociaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asociacion>> GetAsociacion(int id)
        {
            var asociacion = await _asociacionRepository.GetByIdAsync(id);

            if (asociacion == null)
            {
                return NotFound(new CodeErrorResponse(404, "Asociacion no encontrada."));
            }

            return asociacion;
        }

        [HttpPost]
        public async Task<ActionResult<Asociacion>> AddAsociacion(Asociacion asociacion)
        {
            var result = await _asociacionRepository.Add(asociacion);
            if (result == 0)
            {
                throw new Exception("No se inserto la Asociacion");
            }
            return Ok(asociacion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Asociacion>> UpdateAsociacion(int id, Asociacion asociacion)
        {
            asociacion.Id = id;
            var resultado = await _asociacionRepository.Update(asociacion);
            if (resultado == 0)
            {
                throw new Exception("No se puedo actualizar la Asociacion");
            }
            return Ok(asociacion);
        }
    }
}