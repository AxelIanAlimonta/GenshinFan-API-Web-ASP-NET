using GenshinFan.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GenshinFan.Data;

namespace GenshinFan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajeArmaRecomendadaController : ControllerBase
    {
        private readonly IPersonajeArmaRecomendada _personajeArmaRecomendadaService;

        public PersonajeArmaRecomendadaController(IPersonajeArmaRecomendada personajeArmaRecomendadaService)
        {
            _personajeArmaRecomendadaService = personajeArmaRecomendadaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonajeArmaRecomendada>>> GetAllAsync()
        {
            var result = await _personajeArmaRecomendadaService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("personaje/{personajeId}")]
        public async Task<ActionResult<IEnumerable<PersonajeArmaRecomendada>>> GetByPersonajeIdAsync(int personajeId)
        {
            var result = await _personajeArmaRecomendadaService.GetByPersonajeIdAsync(personajeId);
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("arma/{armaId}")]
        public async Task<ActionResult<IEnumerable<PersonajeArmaRecomendada>>> GetByArmaIdAsync(int armaId)
        {
            var result = await _personajeArmaRecomendadaService.GetByArmaIdAsync(armaId);
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("personaje/{personajeId}/arma/{armaId}")]
        public async Task<ActionResult<PersonajeArmaRecomendada>> GetByArmaIdAndPersonajeIdAsync(int personajeId, int armaId)
        {
            var result = await _personajeArmaRecomendadaService.GetByArmaIdAndPersonajeIdAsync(armaId, personajeId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonajeArmaRecomendada>> AddAsync(PersonajeArmaRecomendada personajeArmaRecomendada)
        {
            var result = await _personajeArmaRecomendadaService.AddAsync(personajeArmaRecomendada);
            return CreatedAtAction(nameof(GetByArmaIdAndPersonajeIdAsync), new { personajeId = result.PersonajeId, armaId = result.ArmaId }, result);
        }

        [HttpDelete("personaje/{personajeId}/arma/{armaId}")]
        public async Task<ActionResult<PersonajeArmaRecomendada>> RemoveAsync(int personajeId, int armaId)
        {
            var personajeArmaRecomendada = await _personajeArmaRecomendadaService.GetByArmaIdAndPersonajeIdAsync(armaId, personajeId);
            if (personajeArmaRecomendada == null)
            {
                return NotFound();
            }

            var result = await _personajeArmaRecomendadaService.RemoveAsync(personajeArmaRecomendada);
            return Ok(result);
        }
    }
}


