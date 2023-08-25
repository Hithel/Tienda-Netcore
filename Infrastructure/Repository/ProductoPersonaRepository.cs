using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class ProductoPersonaRepository : GenericRepository<ProductoPersona>, IProductoPersona
    {
        private readonly APITiendaContext _context;

        public ProductoPersonaRepository(APITiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<ProductoPersona>> GetAllAsync()
        {
            return await _context.ProductoPersonas
            .Include(Pp => Pp.Persona)
            .Include(Pp => Pp.Producto)
            .ToListAsync();
        }

        public override async Task<ProductoPersona> GetByIdAsync(int id)
        {
            return await _context.ProductoPersonas
                .Include(r => r.Persona)
                .Include(r => r.Producto)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
