using CadastroDeClientes.Entities;

namespace CadastroDeClientes.Repositories
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuarios>> GetUsers();

        Task<Usuarios> GetUser(string id);

        Task<IEnumerable<Usuarios>> GetUserByName(string name);

        Task<IEnumerable<Usuarios>> GetUserByEmail(string email);

        Task CreateUser(Usuarios user);

        Task<bool> UpdateUser(Usuarios user);

        Task<bool> DeleteUser(string id);
    }
}
