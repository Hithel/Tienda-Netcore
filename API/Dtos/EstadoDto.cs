
using core.Entities;

namespace API.Dtos
{
    public class EstadoDto
    {
        public string Id { get; set; }
        public string NombreEstado { get; set; }
        public int IdPaisFK { get; set; }  // Propiedad para la relación con el país
        
        // Si deseas también incluir el objeto PaisDto, puedes agregarlo aquí
        public PaisDto Pais { get; set; }
    }
}