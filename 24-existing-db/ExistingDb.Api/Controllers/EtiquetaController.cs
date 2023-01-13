using ExistingDb.Api.Entities;
using ExistingDb.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExistingDb.Api.Controllers;

[Route("etiquetas")]
public class EtiquetaController
{
    private readonly IEtiquetaRepository _etiquetaRepository;

    public EtiquetaController(IEtiquetaRepository etiquetaRepository)
    {
        this._etiquetaRepository = etiquetaRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Etiqueta>> GetEtiquetas()
    {
        return await _etiquetaRepository.GetAllAsync();
    }
}