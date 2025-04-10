namespace Calculadora
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto()
        {
            this.Id = Guid.Empty;
            this.Nombre = string.Empty;
            this.Precio = 0;
        }
        public Producto
            (string nombre, double precio)
        {
            this.Id = Guid.NewGuid();
            this.Nombre = nombre;
            this.Precio = precio;
        }
    }
}