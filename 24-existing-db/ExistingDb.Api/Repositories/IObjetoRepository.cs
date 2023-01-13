using ExistingDb.Api.Entities;

namespace ExistingDb.Api.Repositories;

public interface IObjetoRepository
{
    Task<IEnumerable<Objeto>> GetAllAsync();
    Task<Objeto> GetAsync(string cdobjeto);
    Task<IEnumerable<Etiqueta>> GetEtiquetasAsync(string cdobjeto);
}