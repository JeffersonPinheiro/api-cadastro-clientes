using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CadastroDeClientes.Entities
{
    public class Usuarios
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone  { get; set; }

        public string  Cpf { get; set; }

        public DateOnly DataNascimento { get; set; }

    }
}
