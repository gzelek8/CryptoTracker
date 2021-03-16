using CryptoTracker.ApplicationServices.API.Domain.Alert;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Add;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Delete;
using CryptoTracker.ApplicationServices.API.Domain.Alert.Put;
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
    public class AlertsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AlertsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAlerts([FromQuery] GetAlertsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{alertId}")]
        public async Task<IActionResult> GetById([FromRoute] int alertId)
        {

            var request = new GetAlertByIdRequest()
            {
                AlertId = alertId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);

        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAlert([FromQuery] AddAlertRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutAlert([FromQuery] PutAlertRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteAlert([FromQuery] DeleteAlertRequest request)
        {

            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
