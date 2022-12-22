using CadastroDeClientes.Entities;
using CadastroDeClientes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeClientes.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly IUsuariosRepository _repository;

        public CadastroController(IUsuariosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Usuarios>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsers()
        {
            var users = await _repository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Usuarios), StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuarios>> GetUser(string id)
        {
            var user = await _repository.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);    
        }

        [Route("[action]/{name}", Name = "GetUserByName")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Usuarios>))]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUserByName(string name)
        {
            if (name is null)
            {
                return BadRequest("Invalid name");    
            }

            var names = await _repository.GetUserByName(name);

            return Ok(names);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Usuarios), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Usuarios>> CreateUser([FromBody] Usuarios user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user");
            }
            await _repository.CreateUser(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Usuarios), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] Usuarios user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user");
            }
            return Ok(await _repository.UpdateUser(user));
        }
        
        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(typeof(Usuarios), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return Ok(await _repository.DeleteUser(id));
        }



    }
}
