using System.ComponentModel.DataAnnotations;

namespace core.Entities;

    public class Pais
    {
        [Key]
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public ICollection<Estado> Estados {get; set; }
    }
