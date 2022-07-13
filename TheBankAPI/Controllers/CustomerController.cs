using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TheBankAPI.DataAccess.Models;
using TheBankAPI.Services.Utilities;

namespace TheBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public CustomerController(IEmailSender emailSender, UserManager<ApplicationUser> userManager
            ,IConfiguration config)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _config = config;
        }

        [HttpGet]
        public IActionResult Customer()
        {
            return Ok("Welcome to our bank");
        }
        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Customer customer)
        {
            try
            {
                var newUser = new ApplicationUser
                {
                    UserName = customer.FirstName,
                    OtherNames = customer.OtherNames,
                    LastName = customer.LastName,
                    PhoneNumber = customer.MobileNUmber,
                    Address = customer.Address,
                    DateOfBirth = customer.DateOfBirth,
                    AccountType = (int)customer.AccountType,
                    City = customer.City,
                    State = customer.State,
                    Email = customer.Email
                };
                var result = await _userManager.CreateAsync(newUser, customer.Password);
                var userFound = await _userManager.FindByNameAsync(newUser.UserName);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                    UriBuilder uriBuilder = new UriBuilder(_config["ReturnPath:ConfirmEmail"]);
                    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                    uriBuilder.Query = query.ToString();
                    var urlString = uriBuilder.ToString();

                    string senderEmail = _config["ReturnPath:SenderEmail"];

                    await _emailSender.SendEmail(senderEmail, userFound.Email, urlString, "<h1>Please confirm your mail</h2>");
                }
                return StatusCode(StatusCodes.Status201Created, "Customer successfully created.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}
