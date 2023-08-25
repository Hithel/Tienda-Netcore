using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class RegionRepository : GenericRepository<Region>, IRegion
    {
        private readonly APITiendaContext _context;

        public RegionRepository(APITiendaContext context): base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regiones
            .Include(r => r.Estado)
            .Include(r => r.Personas)
            .ToListAsync();
        }

        public override async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regiones
                .Include(r => r.Estado)
                .Include(r => r.Personas)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
