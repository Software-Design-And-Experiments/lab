namespace Calculadora.Tests
{
    public class CarritoTest
    {
        private Carrito _carrito;

        [SetUp]
        public void Setup()
        {
            _carrito = new Carrito();
        }

        [Test]
        public void AgregarProductoTest()
        {
            _carrito.AgregarProducto("PAPA", 4.50);

            var productos = _carrito.ObtenerProductos().ToList();

            Assert.That(productos, Has.Count.EqualTo(1), "El producto no fue agregado correctamente.");

            Assert.Multiple(() =>
            {
                Assert.That(productos[0].Nombre, Is.EqualTo("PAPA"), "El nombre del producto no coincide.");
                Assert.That(productos[0].Precio, Is.EqualTo(4.50), "El precio del producto no coincide.");
            });
        }

        [Test]
        public void CalcularMontoFinalTest()
        {
            var resultado = _carrito.CalcularMontoFinal();

            Assert.That(resultado, Is.EqualTo(4.50), "EL MONTO FINAL ES S/4.50");
        }
    }
}