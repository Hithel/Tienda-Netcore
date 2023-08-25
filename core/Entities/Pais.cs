using System.ComponentModel.DataAnnotations;

namespace core.Entities;

    public class Pais : BaseEntity
    {
        public string NombrePais { get; set; }
        public ICollection<Estado> Estados {get; set; }
    }
