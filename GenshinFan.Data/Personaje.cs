using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinFan.Data;

public class Personaje
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public int? Rareza { get; set; }

    public int? AtkBase { get; set; }

    public int? DefBase { get; set; }

    public int? VidaBase { get; set; }

    public string? ImgTarjeta { get; set; }

    public string? ImgDisenio { get; set; }

    public int? Id_Elemento { get; set; }
    public Elemento? Elemento { get; set; }

    public int? Id_Region { get; set; }
    public Region? Region { get; set; }

    public int? Id_TipoDeArma { get; set; }
    public TipoDeArma? TipoDeArma { get; set; }
}
