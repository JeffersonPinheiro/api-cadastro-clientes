using CadastroDeClientes.Entities;
using MongoDB.Driver;

namespace CadastroDeClientes.Data
{
    public class CadastroContext : ICadastroContext
    {

        public CadastroContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));

            Usuario = database.GetCollection<Usuarios>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));

            Pagamento = database.GetCollection<Pagamentos>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));

            CadastroContextSeed.SeedData(Usuario, Pagamento);

        }


        public IMongoCollection<Usuarios> Usuario { get; }

        public IMongoCollection<Pagamentos> Pagamento { get; }
    }
}
