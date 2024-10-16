using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Auth;
using api.Dtos.User;
using api.Interface;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepo;
        public UserController(AppDbContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var selectedUsers = _context.Users.Select(s => s.ToUserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetOne([FromRoute] int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserDto body)
        {
            var userBody = body.ToUserFromCreateUser();
            await _userRepo.AddAsync(userBody);
            return Ok();
        }
    }
}