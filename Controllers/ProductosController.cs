
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIProducto.Data;
using WebAPIProducto.Dtos;
using WebAPIProducto.Models;

namespace WebAPIProducto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly ILogger<ProductosController> _logger;  
        private readonly  DataContext _context;

        public ProductosController(ILogger<ProductosController> logger, DataContext context)
        {
            
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name ="GetProductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}", Name ="GetProducto")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Post(ProductoCreateDto productoDto)
        {
            var productToCreate = new Producto();

            productToCreate.Nombre = productoDto.Nombre;
            productToCreate.Descripcion = productoDto.Descripcion;
            productToCreate.Precio = productoDto.Precio;
            productToCreate.FechaDeAlta = DateTime.Now;
            productToCreate.Activo = true;
            _context.Add(productToCreate);
            await _context.SaveChangesAsync();

            var value = new { id = productToCreate.Id };
            return new CreatedAtRouteResult("GetProducto",new {id= productToCreate.Id }, productToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoUpdateDto productoDto)
        {
            if (id != productoDto.Id )
            {
                return BadRequest("Los Ids no coinciden");
            }

            var productToUpdate = await _context.Productos.FindAsync(id);
            if (productToUpdate == null)
            {
                return BadRequest();
            }

            productToUpdate.Descripcion = productoDto.Descripcion;
            productToUpdate.Precio = productoDto.Precio;

            _context.Entry(productToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id); 
            
            if (producto == null)
            {
                return NotFound();
            }

            _context.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }
    }
}