using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly APITiendaContext _context;

        public PersonaRepository(APITiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
            .Include(p => p.TipoPersona)
            .Include(p => p.Region)
            .Include(p => p.ProductoPersonas)
            .ToListAsync();
        }

        public override async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas
                .Include(p => p.TipoPersona)
                .Include(p => p.Region)
                .Include(p => p.ProductoPersonas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
