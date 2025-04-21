namespace Calculadora
{
    public class CarritoController
    {
        private readonly ICarrito _carrito;

        public CarritoController(ICarrito carrito) => _carrito = carrito;

        public IEnumerable<Producto> ObtenerProductos()
            => _carrito.ObtenerProductos();

        public void AgregarProducto
            (string nombre, double precio)
            => _carrito.AgregarProducto(nombre, precio);

        public double CalcularMontoFinal()
            => _carrito.CalcularMontoFinal();
    }
}