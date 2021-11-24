using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using MediatR;
using MerchandiseService.Infrastructure.Commands;
using MerchandiseService.Models;
using Microsoft.AspNetCore.Mvc;
using MerchandiseService.Domain.AggregationModels.MerchPackRequest;

namespace MerchandiseService.Controllers
{
    
    [ApiController]
    [Route("v1/api/merchs")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchandiseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult>GetEmployeeMerchInfoAsync(int employeeId, CancellationToken token)
        {
            var command = new EmployeeMerchPackInfoCommand(employeeId);
            var merchInfo = await _mediator.Send(command, token);
            return Ok(merchInfo);
        }

        [HttpGet("getmerch/{requeststring}")]
        public async Task<IActionResult> GetMerchPackAsync(string requeststring, CancellationToken token)
        {
            GetMerchRequestHttp getMerchRequestHttp = JsonSerializer.Deserialize<GetMerchRequestHttp>(requeststring);
            MerchPackRequest merchPackRequest = new MerchPackRequest(
                getMerchRequestHttp.Employee,
                getMerchRequestHttp.Email,
                getMerchRequestHttp.MerchType,
                DateTimeOffset.Now,
                null
                );
            var command = new GetMerchPackCommand(merchPackRequest);
            
            var result = await _mediator.Send(command, token); 
            return Ok(result);
        }
    }
}