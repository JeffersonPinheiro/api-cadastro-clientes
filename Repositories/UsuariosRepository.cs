using CadastroDeClientes.Data;
using CadastroDeClientes.Entities;
using MongoDB.Driver;

namespace CadastroDeClientes.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly ICadastroContext _context;
        public UsuariosRepository(ICadastroContext context)
        {
            _context = context;
        }

        public async Task CreateUser(Usuarios user)
        {
           await _context.Usuario.InsertOneAsync(user);
        }

        public async Task<bool> DeleteUser(string id)
        {
            FilterDefinition<Usuarios> filter = Builders<Usuarios>.Filter.Eq(p => p.Id, id) ;

            DeleteResult deleteResult = await _context.Usuario.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;    
        }

        public async Task<Usuarios> GetUser(string id)
        {
            return await _context.Usuario.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuarios>> GetUserByEmail(string email)
        {
            FilterDefinition<Usuarios> filter = Builders<Usuarios>.Filter.Eq(p => p.Email, email);

            return await _context.Usuario.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Usuarios>> GetUserByName(string name)
        {
            FilterDefinition<Usuarios> filter = Builders<Usuarios>.Filter.Eq(p => p.Nome, name);

            return await _context.Usuario.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Usuarios>> GetUsers()
        {
            return await _context.Usuario.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateUser(Usuarios user)
        {
            var updateResult = await _context.Usuario.ReplaceOneAsync(filter: g => g.Id == user.Id,
                                        replacement: user);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
