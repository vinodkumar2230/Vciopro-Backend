using CoreEntities.ViewModels;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HomeUser.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/DashBoard")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DashBoardController : ApiController
    {
        private vCIOPRoEntities _ctx = new vCIOPRoEntities();
        private ILocations _lctnmngr;
        private IContacts _cntctmngr;
        private IConfiguration _configmanger;
        private IPassword _passwordmanger;

        public DashBoardController(ILocations lctnmngr, IContacts cntctmngr, IConfiguration configmanager,IPassword passwordmanager)
        {
            _lctnmngr = lctnmngr;
            _cntctmngr = cntctmngr;
            _configmanger = configmanager;
            _passwordmanger = passwordmanager;
        }
        //[HttpGet]
        //[Route("api/DashBoard/GetAllLoc")]
        //public IHttpActionResult GetAllLoc()
        //{
        //    var locations = _lctnmngr.GetAllLocations();

        //    return Ok(locations);
        //}
        [AllowAnonymous]
        [HttpGet]
        [Route("/api/Account/GetAllLoc/{id:int}")]
        public IHttpActionResult GetAllLoc(int id)
        {
            var locations = _lctnmngr.GetAllLocations(id);

            return Ok(locations);
        }
        [HttpPost]
        [Route("api/DashBoard/AddLoc")]
        public IHttpActionResult AddLoc(LocationsViewModel model)
         {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {


                bool locAdded = _lctnmngr.AddLocations(model);
                return Ok("ok");
            }

            catch (Exception EX)
            {
                throw EX;
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        [AllowAnonymous]
        [Route("api/DashBoard/EditLoc")]
        public IHttpActionResult EditLoc(LocationsViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool locupdated = _lctnmngr.EditLocations(model);
                return Ok("ok");

            }
            catch (Exception EX)
            {
                throw EX;
            }
            return BadRequest(ModelState);

        }
        [AllowAnonymous]
        [HttpDelete]
        [ActionName("DeleteOrg")]
        [Route("api/Organisations/DeleteOrg/{id:int}")]
        public IHttpActionResult DeleteLoc(int id)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool locdeleted = _lctnmngr.DeleteLocations(id);
                return Ok("ok");

            }
            catch (Exception EX)
            {
                throw EX;
            }

            return BadRequest(ModelState);
        }
        //contacts
        [HttpGet]
        [Route("api/DashBoard/GetAllContact")]
        public IHttpActionResult GetAllContact()
        {
            var contacts = _cntctmngr.GetAllContacts();

            return Ok(contacts);
        }
        [HttpPost]
        [Route("api/DashBoard/AddContact")]
        public IHttpActionResult AddContact(ContactViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {


                bool contactAdded = _cntctmngr.AddContacts(model);   

            }

            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }     
        [Route("api/DashBoard/EditContact")]
        public IHttpActionResult EditContact(ContactViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // if (result.Succeeded == true)
                //

                bool contactupdated = _cntctmngr.EditContacts(model);
                // }
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        [Route("api/DashBoard/DeleteContact")]
        public IHttpActionResult DeleteContact(int ContactId)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // if (result.Succeeded == true)
                //

                bool contactdeleted = _cntctmngr.DeleteContacts(ContactId);
                // }
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }

        //congiguration
        [HttpGet]
        [Route("api/DashBoard/GetAllConfig")]
        public IHttpActionResult GetAllConfig()
        {
            var configurations = _configmanger.GetAllConfigurations();

            return Ok(configurations);
        }
        [HttpPost]
        [Route("api/DashBoard/AddConfig")]
        public IHttpActionResult AddConfig(ConfigurationViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {


                bool locAdded = _configmanger.AddConfigurations(model);

            }

            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        [Route("api/DashBoard/EditConfig")]
        public IHttpActionResult EditConfig(ConfigurationViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // if (result.Succeeded == true)
                //

                bool locupdated = _configmanger.EditConfigurations(model);
                // }
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        [Route("api/DashBoard/DeleteConfig")]
        public IHttpActionResult DeleteConfig(int ID)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // if (result.Succeeded == true)
                //

                bool locdeleted = _configmanger.DeleteConfigurations(ID);
                // }
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        //Passwords
        #region "Create"
        [HttpPost]
        [Route("api/Password/AddPassword")]
        public IHttpActionResult AddPassword(PasswordViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool passwordAdded = _passwordmanger.AddPwd(model);
            }

            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        #endregion

        #region "Read"
        [HttpGet]
        [Route("api/Password/GetAllPassword")]
        public IHttpActionResult GetAllPassword()
        {
            var password = _passwordmanger.GetAllPwd();

            return Ok(password);
        }
        #endregion

        #region "Update"
        [HttpPut]
        [AllowAnonymous]
        [Route("api/Password/EditPassword")]
        public IHttpActionResult EditPassword(PasswordViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool passwordEdited = _passwordmanger.EditPwd(model);
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        #endregion

        #region "Delete"
        [Route("api/Password/DeletePassword")]
        public IHttpActionResult DeletePassword(int ID)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                bool passwordDeleted = _passwordmanger.DeletePwd(ID);
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        #endregion
    }
}
