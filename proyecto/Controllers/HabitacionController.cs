using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Datos;
using HabitacionModel;

[Route("api/[controller]")]
[ApiController]
public class HabitacionController : ControllerBase
{
    private readonly HabitacionService _habitacionService;
    public IConfiguration Configuration { get; }
    public HabitacionController(HotelContext context)
    {
        _habitacionService = new HabitacionService(context);
    }
    // GET: api/Persona​
    [HttpGet]
    public ActionResult<HabitacionViewModel> Gets()
    {
        var response = _habitacionService.ConsultarTodos();
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response.Habitaciones.Select(p => new HabitacionViewModel(p)));
        }
    }
    // GET: api/Persona/5​
    [HttpGet("{numerofactura}")]
    public ActionResult<HabitacionViewModel> Get(string numerohabitacion)
    {
        var habitacion = _habitacionService.BuscarxIdentificacion(numerohabitacion);
        if (habitacion == null) return NotFound();
        var habitacionViewModel = new HabitacionViewModel(habitacion);
        return habitacionViewModel;
    }

    // POST: api/Persona​

    [HttpPost]
    public ActionResult<FacturaViewModel> Post(FacturaInputModel facturaInput)
    {
        Factura factura = MapearFactura(facturaInput);
        var response = _habitacionService.Guardar(factura);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Factura);
    }

    // DELETE: api/Persona/5​

    [HttpDelete("{numerofactura}")]
    public ActionResult<string> Delete(string numerofactura)
    {
        string mensaje = _habitacionService.Eliminar(numerofactura);
        return Ok(mensaje);
    }

    private Factura MapearFactura(FacturaInputModel facturaInput)
    {
        var factura = new Factura
        {
            IdFactura = facturaInput.IdFactura,
            FechaFactura = facturaInput.FechaFactura,
            Iva = facturaInput.Iva,
            Subtotal = facturaInput.Subtotal,
            Total = facturaInput.Total,
            FechaEntrada = facturaInput.FechaEntrada,
            FechaSalida = facturaInput.FechaSalida,
        };
        return factura;
    }
}