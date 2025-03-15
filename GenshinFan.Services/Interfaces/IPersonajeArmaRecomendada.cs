using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;

namespace GenshinFan.Services.Interfaces;

public interface IPersonajeArmaRecomendada
{
    Task<IEnumerable<PersonajeArmaRecomendada>?> GetAllAsync();
    Task<IEnumerable<PersonajeArmaRecomendada>?> GetByPersonajeIdAsync(int personajeId);
    Task<IEnumerable<PersonajeArmaRecomendada>?> GetByArmaIdAsync(int armaId);
    Task<PersonajeArmaRecomendada?> GetByArmaIdAndPersonajeIdAsync(int armaId, int personajeId);
    Task<PersonajeArmaRecomendada?> AddAsync(PersonajeArmaRecomendada personajeArmaRecomendada);
    Task<PersonajeArmaRecomendada?> RemoveAsync(PersonajeArmaRecomendada personajeArmaRecomendada);
}
