using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Interfaces;
    public interface IUnitOfWork
    {
        IPais Paises { get; }

        IEstado Estados{ get; }

        Task<int> SaveAsync();
    }
