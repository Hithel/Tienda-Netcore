using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
    {
        private readonly APITiendaContext _context;

        public TipoPersonaRepository(APITiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
        {
            return await _context.TipoPersonas
            .Include(tp => tp.Personas)
            .ToListAsync();
        }

        public override async Task<TipoPersona> GetByIdAsync(int id)
        {
            return await _context.TipoPersonas
                .Include(tp => tp.Personas)
                .FirstOrDefaultAsync(tp => tp.Id == id);
        }
    }
