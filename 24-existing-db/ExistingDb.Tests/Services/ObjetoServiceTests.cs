using ExistingDb.Api.Dto;
using ExistingDb.Api.Entities;
using ExistingDb.Api.Repositories;
using ExistingDb.Api.Services;
using Moq;

namespace ExistingDb.Tests.Services;

public class ObjetoServiceTests
{
    private readonly IObjetoService _objetoService;
    private readonly Mock<IObjetoRepository> _objetoRepositoryMock = new Mock<IObjetoRepository>();

    private static readonly IList<Etiqueta> EtiquetasTeste = new List<Etiqueta>
    {
        new() { Id = 1, Rotulo = "Etiqueta de teste 1" },
        new() { Id = 2, Rotulo = "Etiqueta de teste 2" },
    };

    private static readonly IList<Objeto> ObjetosTeste = new List<Objeto>
    {
        new()
        {
            Codigo = "OBJ01",
            Descricao = "Primeiro objeto de teste",
            Etiquetas = new List<ObjetoEtiqueta>
            {
                new ObjetoEtiqueta { CodigoObjeto = "OBJ01", IdEtiqueta = 1, Etiqueta = EtiquetasTeste[0] },
            }
        },
        new()
        {
            Codigo = "OBJ02",
            Descricao = "Segundo objeto de teste",
            Etiquetas = new List<ObjetoEtiqueta>
            {
                new() { CodigoObjeto = "OBJ02", IdEtiqueta = 1, Etiqueta = EtiquetasTeste[0] },
                new() { CodigoObjeto = "OBJ02", IdEtiqueta = 2, Etiqueta = EtiquetasTeste[1] },
            }
        }
    };

    private static readonly IList<ObjetoDto>
        ExpectedObjetoDtoList = ObjetoDto.ObjetoEntityListToDtoList(ObjetosTeste);

    public ObjetoServiceTests()
    {
        this._objetoService = new ObjetoService(_objetoRepositoryMock.Object);
    }

    [Fact]
    public async void GetObjetosAsyncShouldReturnAllObjetosDtoWithEtiquetas()
    {
        _objetoRepositoryMock.Setup(m => m.GetAllAsync())
            .ReturnsAsync(ObjetosTeste);

        var objetosDto = (await _objetoService.GetObjetosAsync()).ToList();
        
        Assert.Equal(2, objetosDto.Count);
        
        Assert.Single(objetosDto[0].Etiquetas);
        Assert.Equivalent(ExpectedObjetoDtoList[0], objetosDto[0]);
        
        Assert.Equal(2, objetosDto[1].Etiquetas.Count);
        Assert.Equivalent(ExpectedObjetoDtoList[1], objetosDto[1]);
    }

    [Fact]
    public async void GetObjetoAsyncShouldReturnObjetoWithGivenCodigo()
    {
        _objetoRepositoryMock.Setup(m => m.GetAsync("OBJ01"))
            .ReturnsAsync(ObjetosTeste[0]);

        var objetoDto = await _objetoService.GetObjetoAsync("OBJ01");
        
        Assert.Equivalent(ExpectedObjetoDtoList[0], objetoDto);
    }

    [Fact]
    public async void GetEtiquetasAsyncShouldReturnEtiquetasOfTheSpecifiedObjeto()
    {
        _objetoRepositoryMock.Setup(m => m.GetEtiquetasAsync("OBJ02"))
            .ReturnsAsync(EtiquetasTeste);

        var etiquetasDto = await _objetoService.GetEtiquetasAsync("OBJ02");
        
        Assert.Equivalent(ExpectedObjetoDtoList[1].Etiquetas, etiquetasDto);
    }
}