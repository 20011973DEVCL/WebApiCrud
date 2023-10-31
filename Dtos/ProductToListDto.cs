using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProducto.Dtos
{
    public class ProductToListDto
    {
       public int Id { get; set; } 
       public string Nombre { get; set; }   = string.Empty;
       public string Descripcion { get; set; } = string.Empty; 
    }
}