using CryptoTracker.ApplicationServices.API.Domain.User;
using CryptoTracker.ApplicationServices.API.Domain.User.Add;
using CryptoTracker.ApplicationServices.API.Domain.User.Delete;
using CryptoTracker.ApplicationServices.API.Domain.User.Put;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {

            var request = new GetUserByIdRequest()
            {
                UserId = userId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromQuery] AddUserRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> PutUser([FromRoute] int userId)
        {
            var request = new PutUserRequest()
            {
               UserId = userId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{userdId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {

            var request = new DeleteUserRequest()
            {
                UserId = userId
            };
            var response = await this.mediator.Send(request);
            return this.Ok();
        }
    }
}
