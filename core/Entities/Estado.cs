using System.ComponentModel.DataAnnotations;

namespace core.Entities;
    public class Estado : BaseEntity
    {
        public string NombreEstado { get; set; }
        public int IdPaisFK { get; set; }
        public Pais Pais {get; set;}
        public ICollection<Region> Regiones { get; set; }
    }
