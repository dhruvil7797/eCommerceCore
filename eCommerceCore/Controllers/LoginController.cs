using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceCore.Code;
using eCommerceCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext context;

        public LoginController(AppDbContext context) => this.context = context;

        // POST: api/Login
        [HttpPost]
        public async Task<LoginResponse> Post([FromBody] LoginData ld)
        {
            var resp = new LoginResponse { Success = false };

            try
            {
                var user = context.Users.FirstOrDefault(u => u.Email == ld.Email);
                var userCredential = context.UserCredential.FirstOrDefault(u => u.UserId == user.Id);

                if (user != null && userCredential != null)
                {
                    if (userCredential.Password.Equals(ld.Password))
                    {
                        await HttpContext.Session.LoadAsync();
                        HttpContext.Session.SetInt32("UserId", user.Id);
                        await HttpContext.Session.CommitAsync();

                        resp.Name = user.FirstName;
                        resp.Success = true;
                    }
                }
            }
            catch {
            }

            return resp;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<LoginResponse> Delete()
        {
            try
            {
                await HttpContext.Session.LoadAsync();
                HttpContext.Session.SetInt32("UserId", 0);
                await HttpContext.Session.CommitAsync();
            }
            catch { }

            return new LoginResponse { Success = true };
        }
    }
    public class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Name { get; set; }
        public bool Success { get; set; }
    }
}
