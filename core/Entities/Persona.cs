
namespace core.Entities;
    public class Persona
    {
        public int Id { get; set; }
        public string NombrePersona { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string EmailPersona { get; set; }
        public int IdTipoPersona { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public int IdRegionFK { get; set; }
        public Region Region { get; set; }
        public ICollection<ProductoPersona> ProductoPersonas { get; set; }
    }
