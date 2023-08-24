using System.ComponentModel.DataAnnotations;

namespace core.Entities;
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string NombreRegion { get; set; }
        public int IdEstadoFk { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Persona> Personas { get; set; }
    }
