using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GenshinFan.Data;

public class Arma
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? AtaqueBase { get; set; }

    public int? Rareza { get; set; }

    [ForeignKey("TipoDeArmaId")]
    public int? TipoDeArmaId { get; set; }

    public string? ImagenURL { get; set; }

    [JsonIgnore]
    public TipoDeArma? TipoDeArma { get; set; }

}