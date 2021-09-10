using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunidadController : ControllerBase
    {
        private readonly IGenericRepository<Comunidad> _comunidadRepository;

        public ComunidadController(IGenericRepository<Comunidad> comunidadRepository)
        {
            _comunidadRepository = comunidadRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comunidad>>> GetComunidades(){
            var spec = new ComunidadSpec();
            var comunidades = await _comunidadRepository.GetAllWithSpec(spec);
            return Ok(comunidades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comunidad>> GetComunidad(int id){
            var spec = new ComunidadSpec(id);
            return await _comunidadRepository.GetByIdWithSpec(spec);
        }
    }
}