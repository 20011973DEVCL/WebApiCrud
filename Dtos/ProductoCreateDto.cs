

namespace WebAPIProducto.Dtos
{
    public class ProductoCreateDto
    {
       public string Nombre { get; set; }   = string.Empty;
       public string Descripcion { get; set; } = string.Empty;
       public decimal Precio { get; set; }
    }
}