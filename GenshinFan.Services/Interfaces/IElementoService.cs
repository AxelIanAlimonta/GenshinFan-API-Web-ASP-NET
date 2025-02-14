using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;

namespace GenshinFan.Services.Interfaces;

public interface IElementoService
{
    Task<IEnumerable<Elemento>> GetAll();
    Task<Elemento> Get(int id);
    Task<Elemento> Add(Elemento elemento);
    Task<Elemento> Update(Elemento elemento);
    Task<Elemento> Delete(int id);
}
