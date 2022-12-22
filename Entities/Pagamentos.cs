using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CadastroDeClientes.Entities
{
    public class Pagamentos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public int Id { get; set; }

        [BsonElement("Nome")]

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public char statusPagamento { get; set; }

        public DateOnly DataRegistro { get; set; }
    }
}
