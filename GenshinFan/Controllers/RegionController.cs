using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenshinFan.Controllers;

[Route("api/[controller]es")]
[ApiController]
public class RegionController : ControllerBase
{

    IRegionService _regionService;

    public RegionController(IRegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regions = await _regionService.GetAll();
        return Ok(regions);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var region = await _regionService.Get(id);
        if (region == null)
        {
            return NotFound();
        }
        return Ok(region);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Region region)
    {
        var newRegion = await _regionService.Add(region);
        return CreatedAtAction(nameof(Get), new { id = newRegion.Id }, newRegion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Region region)
    {
        if (id != region.Id)
        {
            return BadRequest("El ID del cuerpo no coincide con el ID de la URL.");
        }

        var updatedRegion = await _regionService.Update(region);
        return Ok(updatedRegion);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var region = await _regionService.Delete(id);
        if (region == null)
        {
            return NotFound();
        }
        return Ok(region);
    }

}
