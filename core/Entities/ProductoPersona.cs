

namespace core.Entities;
    public class ProductoPersona : BaseEntity
    {

        public int IdPersonaFk { get; set; }
        public Persona Persona{ get; set; }
        public int IdProductoFk { get; set; }
        public Producto Producto { get; set; }
    }
