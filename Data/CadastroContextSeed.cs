using CadastroDeClientes.Entities;
using MongoDB.Driver;

namespace CadastroDeClientes.Data
{
    public class CadastroContextSeed
    {
        public static void SeedData(IMongoCollection<Usuarios> usuariosCollection, IMongoCollection<Pagamentos> pagamentosCollection)
        {
            bool existUsuario = usuariosCollection.Find(p => true).Any();
            if (existUsuario)
            {
                usuariosCollection.InsertManyAsync(GetMyUsers());
            }

            bool existPagamento = pagamentosCollection.Find(p => true).Any();
            if (existPagamento)
            {
                pagamentosCollection.InsertManyAsync(GetMyPayments());
            }

        }
        private static IEnumerable<Usuarios> GetMyUsers()
        {
            return new List<Usuarios>()
            {
                new Usuarios()
                {
                    Id = "1",
                    Nome = "Jefferson",
                    Email = "jeffersonpinheiro194@gmail.com",
                    Telefone = "21 9999999",
                    Cpf = "12312312332",
                    DataNascimento = new DateOnly(1994, 6, 29)
                },
                new Usuarios()
                {
                    Id = "2",
                    Nome = "Milena",
                    Email = "MilenaTeste@gmail.com",
                    Telefone = "21 9999999",
                    Cpf = "45645645665",
                    DataNascimento = new DateOnly(1999, 10, 1)
                }
            };
        }

        private static IEnumerable<Pagamentos> GetMyPayments()
        {
            return new List<Pagamentos>()
            {

            };
        }
    }
}
