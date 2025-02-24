using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;
using GenshinFan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GenshinFan.Services.Implementations;

public class PersonajeService : IPersonajeService
{
    private readonly GenshinImpactContext _context;

    public PersonajeService(GenshinImpactContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Personaje>> GetAll()
    {
        return await _context.Personajes.ToListAsync();
    }

    public async Task<Personaje> Get(int id)
    {
        var personaje = await _context.Personajes.FindAsync(id);
        if (personaje == null)
        {
            throw new Exception("Personaje no encontrado");
        }
        return personaje;
    }

    public async Task<Personaje> Add(Personaje personaje)
    {
        _context.Personajes.Add(personaje);
        await _context.SaveChangesAsync();
        return personaje;
    }

    public async Task<Personaje> Delete(int id)
    {
        var personaje = await _context.Personajes.FindAsync(id);
        if (personaje == null)
        {
            throw new Exception("Personaje no encontrado");
        }
        _context.Personajes.Remove(personaje);
        await _context.SaveChangesAsync();
        return personaje;
    }

    public async Task<Personaje> Update(Personaje personaje)
    {
        var existingPersonaje = await _context.Personajes.FindAsync(personaje.Id);
        if (existingPersonaje == null)
        {
            throw new Exception("Personaje no encontrado");
        }

        existingPersonaje.Nombre = personaje.Nombre;
        existingPersonaje.Rareza = personaje.Rareza;
        existingPersonaje.AtkBase = personaje.AtkBase;
        existingPersonaje.DefBase = personaje.DefBase;
        existingPersonaje.VidaBase = personaje.VidaBase;
        existingPersonaje.ImgTarjeta = personaje.ImgTarjeta;
        existingPersonaje.ImgDisenio = personaje.ImgDisenio;
        existingPersonaje.Id_Elemento = personaje.Id_Elemento;
        existingPersonaje.Id_Region = personaje.Id_Region;
        existingPersonaje.Id_TipoDeArma = personaje.Id_TipoDeArma;

        _context.Personajes.Update(existingPersonaje);
        await _context.SaveChangesAsync();

        return existingPersonaje;
    }

}
