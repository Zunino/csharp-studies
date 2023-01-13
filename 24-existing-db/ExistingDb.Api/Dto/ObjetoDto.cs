using ExistingDb.Api.Entities;

namespace ExistingDb.Api.Dto;

public class ObjetoDto
{
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public ICollection<EtiquetaDto> Etiquetas { get; set; }
    
    public static ObjetoDto ObjetoEntityToDto(Objeto entity)
    {
        var dto = new ObjetoDto()
        {
            Codigo = entity.Codigo,
            Descricao = entity.Descricao,
            Etiquetas = new List<EtiquetaDto>() 
        };
        foreach (var e in entity.Etiquetas)
        {
            dto.Etiquetas.Add(new EtiquetaDto()
            {
                Id = e.IdEtiqueta,
                Rotulo = e.Etiqueta.Rotulo
            });
        }
        return dto;
    }

    public static IList<ObjetoDto> ObjetoEntityListToDtoList(IEnumerable<Objeto> entities)
    {
        var dtos = new List<ObjetoDto>();
        dtos.AddRange(entities.Select(ObjetoEntityToDto));
        return dtos;
    }

    public static IList<EtiquetaDto> EtiquetaEntityListToDtoList(IEnumerable<Etiqueta> entities)
    {
        var dtos = new List<EtiquetaDto>();
        dtos.AddRange(entities.Select(entity => new EtiquetaDto() { Id = entity.Id, Rotulo = entity.Rotulo }));
        return dtos;
    }
}