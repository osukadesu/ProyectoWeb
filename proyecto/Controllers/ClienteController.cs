using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Entity;
using HotelNeruda.Models;
using Datos;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;
    public IConfiguration Configuration { get; }
    public ClienteController(HotelContext context)
    {
        _clienteService = new ClienteService(context);
    }
    // GET: api/Persona​
    [HttpGet]
    public ActionResult<ClienteViewModel> Gets()
    {
        var response = _clienteService.ConsultarTodos();
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response.Clientes.Select(p => new ClienteViewModel(p)));
        }
    }
    // GET: api/Persona/5​
    [HttpGet("{cedula}")]
    public ActionResult<ClienteViewModel> Get(string cedula)
    {
        var cliente = _clienteService.BuscarxIdentificacion(cedula);
        if (cliente == null) return NotFound();
        var clienteViewModel = new ClienteViewModel(cliente);
        return clienteViewModel;
    }

    // POST: api/Persona​

    [HttpPost]
    public ActionResult<ClienteViewModel> Post(ClienteInputModel clienteInput)
    {
        Cliente cliente = MapearCliente(clienteInput);
        var response = _clienteService.Guardar(cliente);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Cliente);
    }

    // DELETE: api/Persona/5​

    [HttpDelete("{cedula}")]
    public ActionResult<string> Delete(string cedula)
    {
        string mensaje = _clienteService.Eliminar(cedula);
        return Ok(mensaje);
    }

    private Cliente MapearCliente(ClienteInputModel clienteInput)
    {
        var cliente = new Cliente
        {
            Cedula = clienteInput.Cedula,
            PrimerNombre = clienteInput.PrimerNombre,
            SegundoNombre = clienteInput.SegundoNombre,
            PrimerApellido = clienteInput.PrimerApellido,
            SegundoApellido = clienteInput.SegundoApellido,
            Email = clienteInput.Email,
            Edad = clienteInput.Edad,
            Sexo = clienteInput.Sexo,
            Departamento = clienteInput.Departamento,
            Ciudad = clienteInput.Ciudad,
        };
        return cliente;
    }
}