using ExistingDb.Api.Database;
using ExistingDb.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExistingDb.Api.Repositories;

public class ObjetoRepository : IObjetoRepository
{
    private readonly UnjDbContext _dbContext;

    public ObjetoRepository(UnjDbContext dbContext)
    {
        this._dbContext = dbContext;
        // To debug EF Core's entities
        // Console.WriteLine(_dbContext.Model.ToDebugString());
    }

    public async Task<IEnumerable<Objeto>> GetAllAsync()
    {
        return await _dbContext.Objetos
            .Include(o => o.Etiquetas)!
            .ThenInclude(e => e.Etiqueta)
            .ToListAsync();
    }

    public async Task<Objeto> GetAsync(string cdobjeto)
    {
        return await _dbContext.Objetos
            .Include(e => e.Etiquetas)
            .ThenInclude(e => e.Etiqueta)
            .FirstAsync(e => e.Codigo == cdobjeto);
    }

    public async Task<IEnumerable<Etiqueta>> GetEtiquetasAsync(string cdobjeto)
    {
        var objeto = await _dbContext.Objetos
            .Where(e => e.Codigo == cdobjeto)
            .Include(e => e.Etiquetas)
            .ThenInclude(e => e.Etiqueta)
            .SingleAsync();
        var etiquetas = new List<Etiqueta>(objeto.Etiquetas.Count());
        etiquetas.AddRange(objeto.Etiquetas.Select(oe => oe.Etiqueta));
        return etiquetas;
    }
}