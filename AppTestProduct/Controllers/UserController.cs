using APITestProduct.Models;
using APITestProduct.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITestProduct.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseServices<User> _userServices;

        public UserController(IBaseServices<User> userServices)
        {
            _userServices = userServices;
        }
        // GET: <UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(int Id)
        {
            IEnumerable<User> users = await _userServices.GetAll();

            return Ok(users);
        }

        // GET <UserController>/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUserById(int Id)
        {
            var user = await _userServices.Get(Id);
            if (user == null)
                return NotFound(new User());

            return Ok(user);
        }

        // POST <UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            User _user = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age
            };

            await _userServices.Add(_user);
            return Ok(_user);
        }

        // PUT <UserController>/5
        [HttpPut("{Id}")]
        public async Task<ActionResult<User>> Put(int Id, [FromBody] User user)
        {
            User _user = await _userServices.Get(Id);
            if (_user == null)
                return NotFound(_user);

            _user = user;

            await _userServices.Update(_user);
            return Ok(_user);
        }

        // DELETE <UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var user = await _userServices.Get(Id);
            if (user == null)
                return NotFound();
            await _userServices.Delete(Id);
            return Ok();
        }
    }
}
