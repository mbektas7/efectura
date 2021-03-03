using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Efectura.DTOs;
using Efectura.Helpers;
using Efectura.Model;
using Efectura.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Efectura.Controllers
{
    [Route("api/[controller]")]
    [ErrorLog]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();
            return new OkObjectResult(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{TCKN}")]
        public IActionResult Get(string TCKN)
        {
            var user = _userRepository.GetUserByTCKN(TCKN);
            return new OkObjectResult(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new NoContentResult();
                }
                using (var scope = new TransactionScope())
                {

                    User newUser = new User();
                    newUser.Name = user.name;
                    newUser.Surname = user.surname;
                    newUser.Address = user.address;
                    newUser.Birthday = user.birthday;
                    _userRepository.InsertUser(newUser);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { tckn = newUser.TCKN }, newUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        // PUT api/<UserController>/5
        [HttpPut("{TCKN}")]
        public IActionResult Put(string TCKN, [FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return new NoContentResult();
            }
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    var existUser = _userRepository.GetUserByTCKN(TCKN);

                    if (existUser==null)
                    {
                        
                        return new NoContentResult();
                    }
                    existUser.Address = user.address;
                    existUser.Birthday = user.birthday;
                    existUser.Name = user.name;
                    existUser.Surname = user.surname;

                    _userRepository.UpdateUser(existUser);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{TCKN}")]
        public IActionResult Delete(string tckn)
        {
            _userRepository.DeleteUser(tckn);
            return new OkResult();
        }
    }
}
