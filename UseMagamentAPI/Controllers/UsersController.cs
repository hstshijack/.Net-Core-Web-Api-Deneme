using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UseMagamentAPI.Models;

namespace UseMagamentAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private List<User> _users = Fake.FakeData.GetUsers(200);

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user =_users.FirstOrDefault(x=>x.Id== id);
            return user;
        }
        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            var edituser =_users.FirstOrDefault(x=>x.Id==user.Id);
            edituser.FirstName= user.FirstName;
            edituser.LastName= user.LastName;
            edituser.Address= user.Address;
            return user;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user=_users.FirstOrDefault(x=>x.Id==id);
            _users.Remove(user);
        }


    }
}
