using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinFan.Data;

public class TipoDeArma
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Descripcion { get; set; }

    public string? ImagenURL { get; set; }

    public List<Personaje>? Personajes { get; set; }
}
