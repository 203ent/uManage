﻿using E203.uManage.Services;
using E203.uManage.Services.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace E203.uManage.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            if (_userService == null)
                _userService = userService;
        }

        [Route("me")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            var user = await _userService.GetUser(CurrentUser.Identity.Name);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Route("{id:guid}")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
