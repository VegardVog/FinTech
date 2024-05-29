
using AutoMapper;
using FinTech.Data;
using FinTech.Models;
using FinTech.Models.DTOs;
using FinTech.Repository;
using FinTech.Repository.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;

namespace FinTech.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class UserController : BaseController
    {
  
        private IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound("User not found by that id");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User is null");
                }

                await _userRepository.AddAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserDTOLogin user)
        {
            try
            {
                var loginUser = await _userRepository.GetByUserNameAsync(user.UserName);
                if (loginUser != null)
                {
                    if(loginUser.Password.Equals(user.Password))
                    {
                        return Ok(loginUser);
                    }
                }
                return BadRequest("User Not Found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

    }

}

