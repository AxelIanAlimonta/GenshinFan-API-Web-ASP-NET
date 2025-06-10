using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GenshinFan.Data;

public class Elemento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? ImagenURL { get; set; }

    [JsonIgnore]
    public List<Personaje>? Personajes { get; set; }

}
