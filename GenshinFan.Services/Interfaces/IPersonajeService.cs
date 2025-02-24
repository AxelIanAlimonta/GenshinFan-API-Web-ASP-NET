using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;

namespace GenshinFan.Services.Interfaces;

public interface IPersonajeService
{
    Task<IEnumerable<Personaje>> GetAll();
    Task<Personaje?> Get(int id);
    Task<Personaje> Add(Personaje personaje);
    Task<Personaje> Update(Personaje personaje);
    Task<Personaje> Delete(int id);


}
