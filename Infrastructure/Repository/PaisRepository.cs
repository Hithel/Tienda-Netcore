using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class PaisRepository: GenericRepository<Pais>, IPais
    {
        private readonly APITiendaContext _context;

        public PaisRepository(APITiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises.Include(p => p.Estados).ToListAsync();
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
            .Include(p => p.Estados)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
