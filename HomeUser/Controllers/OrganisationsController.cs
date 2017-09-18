using CoreEntities.ViewModels;
using Microsoft.Owin.Security;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
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
    [RoutePrefix("api/Organisations")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrganisationsController : ApiController
    {


        private vCIOPRoEntities _ctx = new vCIOPRoEntities();
        private IOrganisations _tenantDataManager;

        public OrganisationsController(IOrganisations tntMgr)
        {
            _tenantDataManager = tntMgr;

        }
        [HttpGet]
        [Route("api/Organisations/GetAllOrg")]
        public IHttpActionResult GetAllOrg()
        {
            var a = _tenantDataManager.GetAllOrganisations();

            return Ok(a);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/api/Organisations/GetAllOrgById/{id:int}")]
        public IHttpActionResult GetAllOrgById(int id)
        {
            var result = _tenantDataManager.GetOrgById(id);

            return Ok(result);
        }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        [HttpPost]
        [Route("api/Organisations/AddOrg")]
        public IHttpActionResult AddOrg(OrganisationsViewModel model)
        {
            ResponseViewModel ResponseObj = new ResponseViewModel();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var user = new ApplicationUser() { UserName = model.EmailId, Email = model.EmailId };

            //IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            try
            {
                // if (result.Succeeded == true)
                //

                bool userAdded = _tenantDataManager.AddOrg(model);
                // }
            }

            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        //put
        [Route("api/Organisations/EditOrg")]
        public IHttpActionResult EditOrg(OrganisationsViewModel model)
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

                bool userAdded = _tenantDataManager.EditOrg(model);
                // }
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
        [Route("api/Organisations/DeleteOrg")]
        public IHttpActionResult DeleteOrg(int OrganisationId)
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

                bool userdeleted = _tenantDataManager.DeleteOrg(OrganisationId);
                // }
            }
            catch (Exception EX)
            {
                throw EX;
            }

            return Ok();
        }
    }
}