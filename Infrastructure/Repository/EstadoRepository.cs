using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        private readonly APITiendaContext _context;

        public EstadoRepository(APITiendaContext context): base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _context.Estados.Include(e => e.Pais).Include(e => e.Regiones).ToListAsync();
        }

        public override async Task<Estado> GetByIdAsync(int id)
        {
            return await _context.Estados
                .Include(e => e.Pais)
                .Include(e => e.Regiones)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
