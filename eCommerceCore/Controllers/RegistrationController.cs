using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class RegistrationController : ControllerBase
    {
        private readonly AppDbContext context;

        public RegistrationController(AppDbContext context) => this.context = context;

        // POST: api/Registration
        [HttpPost]
        public async Task<RegistrationResponse> Post([FromBody] RegisterUser registerUser)
        {
            var resp = new RegistrationResponse { Success = false };

            try
            {
                if (!context.Users.Any(u => u.Email == registerUser.Email))
                {
                    var emailValidator = new EmailAddressAttribute();


                    if (emailValidator.IsValid(registerUser.Email) &&
                        !string.IsNullOrEmpty(registerUser.FirstName)&& !string.IsNullOrEmpty(registerUser.LastName)
                        && !string.IsNullOrEmpty(registerUser.Province) && !string.IsNullOrEmpty(registerUser.City)
                        && !string.IsNullOrEmpty(registerUser.Address) && !string.IsNullOrEmpty(registerUser.Pincode)
                        && !string.IsNullOrEmpty(registerUser.PhoneNumber))
                    {
                        //userCredential.Password = PasswordHash.HashPassword(userCredential.Password);
                        Users user = MakeUser(registerUser);
                        await context.Users.AddAsync(user);
                        //await context.UserCredential.AddAsync(userCredential);

                        await context.SaveChangesAsync();

                        StoreUserCredentials(registerUser.Password, user.Id);

                        resp.Success = true;
                        resp.Message = "Registered Successfully" + user.Id;
                    }
                    else
                        resp.Message = "Sorry!!..Empty String Not Allow";
                }
                else
                    resp.Message = "oops!!Email Already Exists...";
            }
            catch(Exception e)
            {
                resp.Message = e.Message; 
            }

            return resp;
        }
        private async void StoreUserCredentials(String password, int userId)
        {
            UserCredential cred = new UserCredential();
            cred.Password = PasswordHash.HashPassword(password);
            cred.UserId = userId;
            await context.UserCredential.AddAsync(cred);

            await context.SaveChangesAsync();

        }
        private Users MakeUser(RegisterUser userDto)
        {
            Users user = new Users();
            user.Address = userDto.Address;
            user.City = userDto.City;
            user.Email = userDto.Email;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.IsRegistered = true;
            user.Pincode = userDto.Pincode;
            user.Province = userDto.Province;
            user.PhoneNumber = userDto.PhoneNumber;
            return user;
        }
    }
    public class RegistrationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class RegisterUser
    {

        public string Password;
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Email;
        public string Address;
        public string Pincode;
        public string City;
        public string Province;
    }
}
