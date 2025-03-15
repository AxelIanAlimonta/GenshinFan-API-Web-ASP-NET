using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PersonajeArmaRecomendadaService : IPersonajeArmaRecomendada
{
    GenshinImpactContext _context;

    public PersonajeArmaRecomendadaService(GenshinImpactContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PersonajeArmaRecomendada>?> GetAllAsync()
    {
        return await _context.PersonajeArmaRecomendada.ToListAsync();
    }

    public async Task<IEnumerable<PersonajeArmaRecomendada>?> GetByPersonajeIdAsync(int id)
    {
        return await _context.PersonajeArmaRecomendada.Where(p => p.PersonajeId == id).ToListAsync();
    }

    public async Task<IEnumerable<PersonajeArmaRecomendada>?> GetByArmaIdAsync(int armaId)
    {
        return await _context.PersonajeArmaRecomendada.Where(p => p.ArmaId == armaId).ToListAsync();
    }

    public async Task<PersonajeArmaRecomendada?> GetByArmaIdAndPersonajeIdAsync(int armaId, int personajeId)
    {
        return await _context.PersonajeArmaRecomendada
            .FirstOrDefaultAsync(p => p.ArmaId == armaId && p.PersonajeId == personajeId);
    }

    public async Task<PersonajeArmaRecomendada?> AddAsync(PersonajeArmaRecomendada personajeArmaRecomendada)
    {
        _context.PersonajeArmaRecomendada.Add(personajeArmaRecomendada);
        await _context.SaveChangesAsync();
        return personajeArmaRecomendada;
    }

    public async Task<PersonajeArmaRecomendada?> RemoveAsync(PersonajeArmaRecomendada personajeArmaRecomendada)
    {
        _context.PersonajeArmaRecomendada.Remove(personajeArmaRecomendada);
        await _context.SaveChangesAsync();
        return personajeArmaRecomendada;
    }
}
