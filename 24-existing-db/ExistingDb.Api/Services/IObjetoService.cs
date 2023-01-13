using ExistingDb.Api.Dto;

namespace ExistingDb.Api.Services;

public interface IObjetoService
{
    Task<IEnumerable<ObjetoDto>> GetObjetosAsync();
    Task<ObjetoDto> GetObjetoAsync(string cdobjeto);
    Task<IEnumerable<EtiquetaDto>> GetEtiquetasAsync(string cdobjeto);
}