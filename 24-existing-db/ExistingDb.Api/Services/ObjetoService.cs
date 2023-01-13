using ExistingDb.Api.Dto;
using ExistingDb.Api.Entities;
using ExistingDb.Api.Repositories;

namespace ExistingDb.Api.Services;

public class ObjetoService : IObjetoService
{
    private readonly IObjetoRepository _objetoRepository;

    public ObjetoService(IObjetoRepository objetoRepository)
    {
        this._objetoRepository = objetoRepository;
    }
    
    public async Task<IEnumerable<ObjetoDto>> GetObjetosAsync()
    {
        var objetos = await _objetoRepository.GetAllAsync();
        return ObjetoDto.ObjetoEntityListToDtoList(objetos);
    }

    public async Task<ObjetoDto> GetObjetoAsync(string cdobjeto)
    {
        var objeto = await _objetoRepository.GetAsync(cdobjeto);
        return ObjetoDto.ObjetoEntityToDto(objeto);
    }

    public async Task<IEnumerable<EtiquetaDto>> GetEtiquetasAsync(string cdobjeto)
    {
        var etiquetas = await _objetoRepository.GetEtiquetasAsync(cdobjeto);
        return ObjetoDto.EtiquetaEntityListToDtoList(etiquetas);
    }
}