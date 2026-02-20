using BankMore.Transfer.Application.Feature.Transference.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMore.Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransferenceController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TransferenceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Transfer")]
        public async Task<IActionResult> Transference(TransferenceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
