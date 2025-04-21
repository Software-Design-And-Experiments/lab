namespace Calculadora
{
    public interface ICarrito
    {
        IEnumerable<Producto> ObtenerProductos();
        void AgregarProducto(string nombre, double precio);
        double CalcularMontoFinal();
    }
}