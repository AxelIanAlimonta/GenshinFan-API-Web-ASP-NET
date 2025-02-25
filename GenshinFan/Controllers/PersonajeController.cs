using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class PersonajeController : ControllerBase
{
    private readonly IPersonajeService _personajeService;


    public PersonajeController(IPersonajeService personajeService)
    {
        _personajeService = personajeService;

    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var personajes = await _personajeService.GetAll();
        return Ok(personajes);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var personaje = await _personajeService.Get(id);
        if (personaje == null)
        {
            return NotFound("Personaje no encontrado");
        }
        return Ok(personaje);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Personaje personaje)
    {
        if (personaje == null)
        {
            return BadRequest("Datos del personaje inválidos");
        }


        var nuevoPersonaje = await _personajeService.Add(personaje);
        return CreatedAtAction(nameof(Get), new { id = nuevoPersonaje.Id }, nuevoPersonaje);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Personaje personaje)
    {
        if (id != personaje.Id)
        {
            return BadRequest("El id del personaje no coincide con el id de la URL");
        }

        try
        {
            var personajeActualizado = await _personajeService.Update(personaje);
            return Ok(personajeActualizado);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var personajeEliminado = await _personajeService.Delete(id);
            return Ok(personajeEliminado);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
