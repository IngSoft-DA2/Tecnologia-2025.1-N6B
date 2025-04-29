using Microsoft.AspNetCore.Mvc;
using shop.IBusinessLogic;
using shop.Domain;
using System.Collections.Generic;
using shop.WebApi.Filters;

namespace shop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AuthorizationFilter("Admin", "User")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        //Si esto no lanza excepciones, el resultado es OK(200)
        [HttpPost]
        public void CreateUser(User user) => _userLogic.CreateUser(user);

        [HttpGet("{id}")]
        public User GetUser(int id) => _userLogic.GetUser(id);

        [HttpGet]
        public IEnumerable<User> GetAllUsers() => _userLogic.GetAllUsers();

        [HttpPut]
        public void UpdateUser(User user) => _userLogic.UpdateUser(user);

        [HttpDelete("{id}")]
        public void DeleteUser(int id) => _userLogic.DeleteUser(id);
    }
}