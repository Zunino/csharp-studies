namespace ExistingDb.Api.Entities;

public class Objeto
{
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    // public ICollection<ObjetoEtiqueta> EtiquetasLink { get; set; }
    public IEnumerable<ObjetoEtiqueta> Etiquetas { get; set; }
}