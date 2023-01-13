using ExistingDb.Api.Entities;

namespace ExistingDb.Api.Repositories;

public interface IEtiquetaRepository
{
    Task<IEnumerable<Etiqueta>> GetAllAsync();
}