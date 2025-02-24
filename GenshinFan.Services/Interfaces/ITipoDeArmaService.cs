using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;

namespace GenshinFan.Services.Interfaces;

public interface ITipoDeArmaService
{
    Task<IEnumerable<TipoDeArma>> GetAll();
    Task<TipoDeArma?> Get(int id);
    Task<TipoDeArma> Add(TipoDeArma tipoDeArma);
    Task<TipoDeArma> Update(TipoDeArma tipoDeArma);
    Task<TipoDeArma?> Delete(int id);
}
