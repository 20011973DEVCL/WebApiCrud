
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIProducto.Data;
using WebAPIProducto.Models;

namespace WebAPIProducto.Controllers
{
    [Route("[controller]")]
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

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}