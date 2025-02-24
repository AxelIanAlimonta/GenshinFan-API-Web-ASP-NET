using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeArmaController : ControllerBase
    {
        ITipoDeArmaService _tipoDeArmaService;

        public TiposDeArmaController(ITipoDeArmaService tipoDeArmaService)
        {
            _tipoDeArmaService = tipoDeArmaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tiposDeArma = await _tipoDeArmaService.GetAll();
            return Ok(tiposDeArma);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tipoDeArma = await _tipoDeArmaService.Get(id);
            if (tipoDeArma == null)
            {
                return NotFound();
            }
            return Ok(tipoDeArma);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TipoDeArma tipoDeArma)
        {
            var newTipoDeArma = await _tipoDeArmaService.Add(tipoDeArma);
            return CreatedAtAction(nameof(Get), new { id = newTipoDeArma.Id }, newTipoDeArma);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, TipoDeArma tipoDeArma)
        {
            if (id != tipoDeArma.Id)
            {
                return BadRequest();
            }
            var updatedTipoDeArma = await _tipoDeArmaService.Update(tipoDeArma);
            if (updatedTipoDeArma == null)
            {
                return NotFound();
            }
            return Ok(updatedTipoDeArma);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoDeArma = await _tipoDeArmaService.Delete(id);
            if (tipoDeArma == null)
            {
                return NotFound();
            }
            return Ok(tipoDeArma);
        }


    }
}
