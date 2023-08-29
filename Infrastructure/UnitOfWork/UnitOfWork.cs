using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infraestructura.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly APITiendaContext context;
    private PaisRepository _paises;

    private EstadoRepository _estados;

    public UnitOfWork(APITiendaContext _context)
    {
        context = _context;
    }

    public IPais Paises
    {
        get{
            if(_paises == null)
            {
                _paises = new PaisRepository(context);
            }
            return _paises;
        }
    }

    public IEstado Estados
    {
        get{
            if(_estados == null)
            {
                _estados = new EstadoRepository(context);
            }
            return _estados;
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}