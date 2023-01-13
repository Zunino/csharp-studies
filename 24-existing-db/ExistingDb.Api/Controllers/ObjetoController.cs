using ExistingDb.Api.Dto;
using ExistingDb.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExistingDb.Api.Controllers;

[ApiController]
[Route("objetos")]
public class ObjetoController : ControllerBase
{
    private readonly IObjetoService _objetoService;
    
    public ObjetoController(IObjetoService objetoService)
    {
        this._objetoService = objetoService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ObjetoDto>> GetObjetosAsync()
    {
        return await _objetoService.GetObjetosAsync();
    }

    [HttpGet("{cdobjeto}")]
    public async Task<IActionResult> GetObjetoAsync(string cdobjeto)
    {
        try
        {
            return Ok(await _objetoService.GetObjetoAsync(cdobjeto));
        }
        catch (InvalidOperationException)
        {
            return new NotFoundResult();
        }
    }

    [HttpGet("{cdobjeto}/etiquetas")]
    public async Task<IActionResult> GetEtiquetasAsync(string cdobjeto)
    {
        try
        {
            return Ok(await _objetoService.GetEtiquetasAsync(cdobjeto));
        }
        catch (InvalidOperationException)
        {
            return new NotFoundResult();
        }
    }
}