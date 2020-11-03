using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Datos;
using FacturaModel;
using Microsoft.AspNetCore.Http;

[Route("api/[controller]")]
[ApiController]
public class FacturaController : ControllerBase
{
    private readonly FacturaService _facturaService;
    public IConfiguration Configuration { get; }
    public FacturaController(HotelContext context)
    {
        _facturaService = new FacturaService(context);
    }
    // GET: api/Persona​
    [HttpGet]
    public ActionResult<FacturaViewModel> Gets()
    {
        var response = _facturaService.ConsultarTodos();
        if (response.Error)
        {
            ModelState.AddModelError("Error al consultar la Factura", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        else
        {
            return Ok(response.Facturas.Select(p => new FacturaViewModel(p)));
        }
    }
    // GET: api/Persona/5​
    [HttpGet("{idfactura}")]
    public ActionResult<FacturaViewModel> Get(string idfactura)
    {
        var factura = _facturaService.BuscarxIdentificacion(idfactura);
        if (factura == null) return NotFound();
        var facturaViewModel = new FacturaViewModel(factura);
        return facturaViewModel;
    }

    // POST: api/Persona​

    [HttpPost]
    public ActionResult<FacturaViewModel> Post(FacturaInputModel facturaInput)
    {
        Factura factura = MapearFactura(facturaInput);
        var response = _facturaService.Guardar(factura);
        if (response.Error)
        {
            ModelState.AddModelError("Error al guardar la Factura", response.Mensaje);
            var detallesproblemas = new ValidationProblemDetails(ModelState);
            detallesproblemas.Status = StatusCodes.Status500InternalServerError;
            return BadRequest(detallesproblemas);
        }
        return Ok(response.Factura);
    }

    // DELETE: api/Persona/5​

    [HttpDelete("{idfactura}")]
    public ActionResult<string> Delete(string idfactura)
    {
        string mensaje = _facturaService.Eliminar(idfactura);
        return Ok(mensaje);
    }

    private Factura MapearFactura(FacturaInputModel facturaInput)
    {
        var factura = new Factura
        {
            IdFactura = facturaInput.IdFactura,
            FechaFactura = facturaInput.FechaFactura,
            Cedula = facturaInput.Cedula,
            Iva = facturaInput.Iva,
            Subtotal = facturaInput.Subtotal,
            Total = facturaInput.Total,
            Cantidad = facturaInput.Cantidad,
            FechaEntrada = facturaInput.FechaEntrada,
            FechaSalida = facturaInput.FechaSalida,
        };
        return factura;
    }
}