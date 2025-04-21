using Moq;

namespace Calculadora.Tests
{
    public class CarritoTest
    {
        private Mock<ICarrito> _carritoMock;
        private Carrito _carrito;
        private CarritoController _carritoController;

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

            _carritoController = new CarritoController(_carritoMock.Object);
        }

        [Test]
        public void AgregarProductoTest()
        {
            _carritoController.AgregarProducto("PAPA", 4.50);

            var productos = _carritoController.ObtenerProductos().ToList();

            Assert.That(productos, Has.Count.EqualTo(1), "El producto no fue agregado correctamente.");

            Assert.Multiple(() =>
            {
                Assert.That(productos[0].Nombre, Is.EqualTo("PAPA"), "El nombre del producto no coincide.");
                Assert.That(productos[0].Precio, Is.EqualTo(4.50), "El precio del producto no coincide.");
            });

            _carritoMock.Verify(c => c.AgregarProducto(It.IsAny<string>(), It.IsAny<double>()), Times.Exactly(1));
        }

        [Test]
        public void CalcularMontoFinalTest()
        {
            _carritoController.AgregarProducto("PAPA", 4.50);

            var resultado = _carritoController.CalcularMontoFinal();

            Assert.That(resultado, Is.EqualTo(4.50), "EL MONTO FINAL DEBE SER S/4.50");

            _carritoMock.Verify(c => c.CalcularMontoFinal(), Times.Exactly(1));
        }
    }
}