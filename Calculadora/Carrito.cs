namespace Calculadora
{
    public class Carrito : ICarrito
    {
        private List<Producto> _productos;

        public Carrito()
        {
            this._productos = new List<Producto>();
        }

        public IEnumerable<Producto> ObtenerProductos()
            => _productos;

        public void AgregarProducto
            (string nombre, double precio)
            => _productos.Add(new Producto(nombre, precio));

        public double CalcularMontoFinal()
            => _productos.Sum(p => p.Precio);
    }
}