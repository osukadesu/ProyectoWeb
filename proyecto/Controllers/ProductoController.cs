using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Datos;
using ProductoModel;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly ProductoService _productoService;
    public IConfiguration Configuration { get; }
    public ProductoController(HotelContext context)
    {
        _productoService = new ProductoService(context);
    }
    // GET: api/Persona​
    [HttpGet]
    public ActionResult<ProductoViewModel> Gets()
    {
        var response = _productoService.ConsultarTodos();
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response.Productos.Select(p => new ProductoViewModel(p)));
        }
    }
    // GET: api/Persona/5​
    [HttpGet("{idhabitacion}")]
    public ActionResult<ProductoViewModel> Get(string idhabitacion)
    {
        var producto = _productoService.BuscarxIdentificacion(idhabitacion);
        if (producto == null) return NotFound();
        var productoViewModel = new ProductoViewModel(producto);
        return productoViewModel;
    }

    // POST: api/Persona​

    [HttpPost]
    public ActionResult<ProductoViewModel> Post(ProductoInputModel productoInput)
    {
        Producto producto = MapearProducto(productoInput);
        var response = _productoService.Guardar(producto);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Producto);
    }

    // DELETE: api/Persona/5​

    [HttpDelete("{idproducto}")]
    public ActionResult<string> Delete(string idproducto)
    {
        string mensaje = _productoService.Eliminar(idproducto);
        return Ok(mensaje);
    }

    private Producto MapearProducto(ProductoInputModel productoInput)
    {
        var producto = new Producto
        {
            IdProducto = productoInput.IdProducto,
            Nombre = productoInput.Nombre,
            Tipo = productoInput.Tipo,
            Cantidad = productoInput.Cantidad,
            Precio = productoInput.Precio,
        };
        return producto;
    }
}