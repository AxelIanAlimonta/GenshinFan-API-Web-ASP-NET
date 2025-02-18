using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ElementoController : ControllerBase
{
    private readonly IElementoService _elementoService;
    public ElementoController(IElementoService elementoService)
    {
        _elementoService = elementoService;
    }

    // Obtener todos los elementos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Elemento>>> GetAll()
    {
        try
        {
            var elementos = await _elementoService.GetAll();
            return Ok(elementos);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    // Obtener un elemento por ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Elemento>> Get(int id)
    {
        try
        {
            var elemento = await _elementoService.Get(id);
            if (elemento == null)
            {
                return NotFound();
            }
            return Ok(elemento);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    // Crear un nuevo elemento
    [HttpPost]
    public async Task<ActionResult<Elemento>> Add(Elemento elemento)
    {
        try
        {
            if (elemento == null)
            {
                return BadRequest();
            }

            var createdElemento = await _elementoService.Add(elemento);
            return CreatedAtAction(nameof(Get), new { id = createdElemento.Id }, createdElemento);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    // Actualizar un elemento existente
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Elemento>> Update(int id, Elemento elemento)
    {
        try
        {
            // Asegúrate de que el ID en la URL se asigna al objeto Elemento
            elemento.Id = id;

            var updatedElemento = await _elementoService.Update(elemento);
            if (updatedElemento == null)
            {
                return NotFound();
            }

            return Ok(updatedElemento);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    // Eliminar un elemento por ID
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Elemento>> Delete(int id)
    {
        try
        {
            var deletedElemento = await _elementoService.Delete(id);
            if (deletedElemento == null)
            {
                return NotFound();
            }

            return Ok(deletedElemento);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework here)
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
