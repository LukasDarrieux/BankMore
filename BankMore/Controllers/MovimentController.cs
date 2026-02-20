using BankMore.Account.API.Service.Interface;
using BankMore.Account.Application.Features.Moviment.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankMore.Account.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimentController : GeneralController
    {

        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public MovimentController(IMediator mediator, ITokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(DepositCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw(WithdrawCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
