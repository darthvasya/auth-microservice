using AuthServer.Model;
using AuthServer.Model.Models;
using AuthServer.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthServer.API.Controllers
{
    public class UsersController : ApiController
    {
        private IUserManagerService _userManagerService;
        public UsersController(IUserManagerService userManager)
        {
            _userManagerService = userManager;
        }

        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            return _userManagerService.Users();
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            return null;
        }

        // GET api/<controller>/{email}
        [Route("api/users/search/email/{email}")]
        public User GetByEmail(string email)
        {
            return _userManagerService.GetByEmail(email);
        }

        // POST api/<controller>
        public User Post([FromBody]CreateUserWrapper user)
        {
            return _userManagerService.CreateUser(user); ;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}