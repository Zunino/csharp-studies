using System.Text.Json.Serialization;

namespace ExistingDb.Api.Entities;

public class ObjetoEtiqueta
{
    public string CodigoObjeto { get; set; }
    [JsonIgnore]
    public Objeto Objeto { get; set; }

    public int IdEtiqueta { get; set; }
    public Etiqueta Etiqueta { get; set; }
}