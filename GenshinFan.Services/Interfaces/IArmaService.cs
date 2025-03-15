using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;

namespace GenshinFan.Services.Interfaces;

public interface IArmaService
{
    Task<IEnumerable<Arma>> GetAll();
    Task<Arma?> Get(int id);
    Task<Arma> Add(Arma arma);
    Task<Arma> Update(Arma arma);
    Task<Arma?> Delete(int id);

}
