using DivisionOfWorkModels.ViewModels;
using DivisionOfWorkWebAPI.Reponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetUserList();
            var assignees = users.Select(x => new AssigneeDto()
            {

                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName
            });

            return Ok(assignees);
        }
    }
}
