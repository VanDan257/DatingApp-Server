using AppChat_Server.DTOs;
using AppChat_Server.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace AppChat_Server.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Email))
            {
                return BadRequest("Email is taken!");
            }

            using var hmac = new HMACSHA512();

            //var user = _mapper.Map<AppUser>(registerDto);

            //user.UserName = registerDto.Username;
            //user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
            //user.PasswordSalt = hmac.Key;

            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                DateOfBirth = registerDto.DateOfBirth,
                Created = DateTime.Now,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                City = registerDto.City,
                Country = registerDto.Country,
                Gender = registerDto.Gender
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CresteToken(user),
                Gender = user.Gender
            };
        }

        private async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                //.Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);

            if (user == null)
            {
                return Unauthorized(0);
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return Unauthorized("invalid password");
            }
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CresteToken(user),
                PhotoUrl = user.PhotoUrl,
                Gender = user.Gender
            };
        }
    }
}
