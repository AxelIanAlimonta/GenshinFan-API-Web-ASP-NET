using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenshinFan.Data;

namespace GenshinFan.Services.Interfaces;

public interface IRegionService
{
    Task<IEnumerable<Region>> GetAll();
    Task<Region?> Get(int id);
    Task<Region> Add(Region region);
    Task<Region> Update(Region region);
    Task<Region?> Delete(int id);
}
