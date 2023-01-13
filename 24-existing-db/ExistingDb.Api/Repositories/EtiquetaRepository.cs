using ExistingDb.Api.Database;
using ExistingDb.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExistingDb.Api.Repositories;

public class EtiquetaRepository : IEtiquetaRepository
{
    private readonly UnjDbContext _dbContext;
    
    public EtiquetaRepository(UnjDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Etiqueta>> GetAllAsync()
    {
        return await _dbContext.Etiquetas.ToListAsync();
    }
}