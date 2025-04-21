using Moq;

namespace Calculadora.Tests
{
    public class CarritoTest
    {
        private Mock<ICarrito> _carritoMock;
        private Carrito _carrito;

        [SetUp]
        public void Setup()
        {
            _carrito = new Carrito();

            List<Producto> productosSimulados = new();

            _carritoMock = new Mock<ICarrito>();

            _carritoMock.Setup(c => c.AgregarProducto(It.IsAny<string>(), It.IsAny<double>()))
                .Callback<string, double>((nombre, precio) =>
                {
                    productosSimulados.Add(new Producto(nombre, precio));
                });

            _carritoMock.Setup(c => c.CalcularMontoFinal())
                .Returns(() => productosSimulados.Sum(p => p.Precio));

            _carritoMock.Setup(c => c.ObtenerProductos())
                .Returns(() => productosSimulados);
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