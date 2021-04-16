using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.Data;
using XPTO.Models;

namespace XPTO.Repositories
{
    public class UserRepository
    {
        public async static Task<ActionResult<User>> Get([FromServices] DataContext context, string email, string password)
        {
            var user = await context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
            return user;
        }
    }
}