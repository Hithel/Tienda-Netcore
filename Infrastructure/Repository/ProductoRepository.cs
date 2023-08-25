using core.Entities;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
    public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
        private readonly APITiendaContext _context;

        public ProductoRepository(APITiendaContext context): base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _context.Productos
            .Include(P => P.ProductoPersonas)
            .ToListAsync();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Productos
                .Include(P => P.ProductoPersonas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


    }
