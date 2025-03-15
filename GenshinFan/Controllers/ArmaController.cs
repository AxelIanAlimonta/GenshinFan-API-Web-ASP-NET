using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ArmaController : ControllerBase
{
    IArmaService _armaService;

    public ArmaController(IArmaService armaService)
    {
        _armaService = armaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Arma>>> GetAll()
    {
        try
        {
            return Ok(await _armaService.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Arma>> Get(int id)
    {
        try
        {
            var arma = await _armaService.Get(id);
            if (arma == null)
            {
                return NotFound();
            }
            return Ok(arma);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Arma>> Add([FromBody] Arma arma)
    {
        try
        {
            return CreatedAtAction(nameof(Get), new { id = arma.Id }, await _armaService.Add(arma));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Arma>> Update(int id, [FromBody] Arma arma)
    {
        try
        {
            if (id != arma.Id)
            {
                return BadRequest("Arma ID mismatch");
            }

            arma.Id = id;

            var updatedArma = await _armaService.Update(arma);
            if (updatedArma == null)
            {
                return NotFound($"Arma with Id = {id} not found");
            }

            return Ok(updatedArma);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Arma>> Delete(int id)
    {
        try
        {
            var arma = await _armaService.Delete(id);
            if (arma == null)
            {
                return NotFound();
            }
            return Ok(arma);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}