using Jardineria_Gabriel.Data;
using Jardineria_Gabriel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace Jardineria_Gabriel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly GabrielContext _usersContext;
        private readonly UserManager<JardinUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(GabrielContext uscon, UserManager<JardinUser> usmanager, IConfiguration conf)
        {
            _userManager = usmanager;
            _usersContext = uscon;
            _configuration = conf;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] Register regis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Algun dato introducido es incorrecto");
            }
            JardinUser newUser = new JardinUser { UserName = regis.Email, Email = regis.Email, FullName = regis.FullName, Address = regis.Address, Phone = regis.Phone, PostalCode = regis.PostalCode };
            var adduser = await _userManager.CreateAsync(newUser, regis.Password);
            await _userManager.AddToRoleAsync(newUser, "Basic");
            var token = await _userManager.CreateSecurityTokenAsync(newUser);
            return Ok("Registrado correctamente");
        }
        //USAR [FROMBODY] AUTH (para usar el modelo creado anteriormente y no usar el signin)
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] Auth auth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Algo introducido es inválido");
            }
            var useremail = await _userManager.FindByEmailAsync(auth.Email);
            if (useremail == null)
            {
                return NotFound("El email es NULL");
            }
            var passcheck = await _userManager.CheckPasswordAsync(useremail, auth.Password);
            if (passcheck)
            {
                var tokencito = await GeneradorToken(useremail);
                return Ok(tokencito);
            }
            return NotFound("Contraseña introducida incorrecta");
        }

        private async Task<string> GeneradorToken(JardinUser user)
        {
            DateTimeOffset tiempo = new DateTimeOffset(DateTime.UtcNow);
            string tiempoUnix = tiempo.ToUnixTimeSeconds().ToString();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, tiempoUnix, ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("Upgrade")]
        [Authorize(Roles = "Basic")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<IActionResult> Upgrade()
        {
            var emailuser =  User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var user =  await _userManager.FindByEmailAsync(emailuser);
            var rol = await _userManager.GetRolesAsync(user);
            if (rol.Count <= 1 && rol.Contains("Basic"))
            {
                await _userManager.AddToRoleAsync(user, "Premium");
                await _userManager.RemoveFromRoleAsync(user, "Basic");
                return Ok("Se ha actualizado tu rol");
            }
            return StatusCode(405);
        }
        [HttpGet("Users")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Users()
        {
            var lista =  await _usersContext.Users.ToListAsync();
            return Ok(lista.Select(x => new 
            {
               Username = x.UserName,
               Email = x.Email,
               FullName = x.FullName,
               Address = x.Address,
               Phone = x.Phone,
               PostalCode = x.PostalCode
            }));
        }
    }
}
