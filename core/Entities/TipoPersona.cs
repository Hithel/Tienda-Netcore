namespace core.Entities;
    public class TipoPersona
    {
        public int IdTipoPersona { get; set; }
        public string Descripcion { get; set; }
        public ICollection<TipoPersona> Personas { get; set;}
    }
