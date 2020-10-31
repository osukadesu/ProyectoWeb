using Entity;

namespace ClienteModel
{
    public class ClienteInputModel
    {
        public string IdCliente { get; set; }
    }

    public class ClienteViewModel : ClienteInputModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            IdCliente = cliente.IdCliente;
        }
    }
}