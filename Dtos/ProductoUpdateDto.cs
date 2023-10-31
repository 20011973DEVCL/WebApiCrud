using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProducto.Dtos
{
    public class ProductUpdateDto
    {
       public int Id { get; set; } 
       public string Descripcion { get; set; } = string.Empty;
       public decimal Precio { get; set; }
    }
}