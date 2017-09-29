using HomeUser.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using CoreEntities.ViewModels;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer;
using System.Web.Http.Cors;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace HomeUser.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        //private const string LocalLoginProvider = "Local";
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private vCIOPRoEntities _ctx = new vCIOPRoEntities();
        private IRegistration _tenantDataManager;
        private ICountry _country;
        private IState _state;
        public AccountController(IRegistration tntMgr, ICountry countrymanager, IState statemanager)
        {
            _tenantDataManager = tntMgr;
            _country = countrymanager;
            _state = statemanager;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }


        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? Request.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Account/Register")]
        public async Task<IHttpActionResult> Register(APiRegisterViewModel model)
                {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            try {
                if (result.Succeeded == true)
                {
                    
                     bool userAdded = _tenantDataManager.AddUser(model);
                    return Ok("Ok");
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }
        
            return BadRequest(ModelState);


        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            #endregion
        }

        //}
        [AllowAnonymous]
        [Route("/api/Account/Login")]
    public IHttpActionResult Login(LoginViewModel model)
    { 
            bool userLoggedIn = _tenantDataManager.LoginUser(model);

            if (userLoggedIn == false)
            return Unauthorized(); 

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor  
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, model.UserId.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return Ok(new
        {
            Id =model.UserId,
            Username = model.Email,
            Password =model.Password,
            Token = tokenString
        });

    }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Account/GetCountry")]
        public IHttpActionResult GetCountry()
        {
            var a = _country.GetAllCountry();

            return Ok(a);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("/api/Account/GetStates/{id:int}")]
        public IHttpActionResult GetStates(int id)
        {
            var result = _state.GetAllState(id);

            return Ok(result);
        }

    }
public class AppSettings
{
    public string Secret { get; set; }
}
}
