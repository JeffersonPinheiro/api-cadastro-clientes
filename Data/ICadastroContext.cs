using CadastroDeClientes.Entities;
using MongoDB.Driver;

namespace CadastroDeClientes.Data
{
    public interface ICadastroContext
    {
        IMongoCollection<Usuarios> Usuario { get; }
        IMongoCollection<Pagamentos> Pagamento { get; }
    }
}
