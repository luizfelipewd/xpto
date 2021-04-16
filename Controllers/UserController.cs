using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.Data;
using XPTO.Models;
using XPTO.Services;

namespace XPTO.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<User>> Signup([FromServices] DataContext context, [FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var passwordHasher = new PasswordHasher<User>();
                    model.Password = passwordHasher.HashPassword(model, model.Password);
                    context.Users.Add(model);
                    await context.SaveChangesAsync();
                    model.Password = "";
                    return model;
                }
                catch (Exception)
                {
                    return BadRequest("Não foi possível cadastrar");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromServices] DataContext context, [FromBody] User model)
        {
            var passwordHasher = new PasswordHasher<User>();

            var user = await context.Users.Where(x => x.Email == model.Email && passwordHasher.VerifyHashedPassword(model, x.Password, model.Password) == PasswordVerificationResult.Success).FirstOrDefaultAsync();
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };

        }
    }
}