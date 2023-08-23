
namespace core.Entities;
    public class Producto
    {
        public int Id { get; set; }
        public string CodInterno { get; set; }
        public string NombreProducto { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int Stock { get; set; }
        public double ValorVenta { get; set; }

        public ICollection<ProductoPersona> ProductoPersonas { get; set; }
    }