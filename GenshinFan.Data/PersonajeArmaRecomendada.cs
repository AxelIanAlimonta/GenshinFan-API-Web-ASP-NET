using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinFan.Data;

public class PersonajeArmaRecomendada
{
    [Key, Column(Order = 0)]
    public int PersonajeId { get; set; }

    [Key, Column(Order = 1)]
    public int ArmaId { get; set; }

}