using BankMore.Account.API.Service;
using BankMore.Account.API.Service.Implements;
using BankMore.Account.API.Service.Interface;
using BankMore.Account.Application.Features.Account.Commands;
using BankMore.Account.Application.Features.Account.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace BankMore.Account.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public AccountController(IMediator mediator, ITokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(NewAccountCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            result.Token = _tokenService.GenerateToken(command);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("Inactive")]
        public async Task<IActionResult> InactiveAccount(InactiveAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetBalance")]
        public async Task<IActionResult> GetBalance()
        {
            string accountNumberOrCPF = GetAccountNumber();

            if (string.IsNullOrEmpty(accountNumberOrCPF))
            {
                return Unauthorized();
            }

            var balance = await _mediator.Send(new GetAccountBalanceQuery(accountNumberOrCPF));
            
            return Ok(new { Balance = balance });
        }

        private string GetAccountNumber()
        {
            string accountNumber = string.Empty;
            string tokenJwt = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (!string.IsNullOrEmpty(tokenJwt))
            {
                tokenJwt = tokenJwt.Replace("Bearer", "");
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(tokenJwt);

                if (!(jwtSecurityToken is null))
                {
                    var numberOrCPF = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type.Equals("AccountNumberOrCPF", StringComparison.OrdinalIgnoreCase));

                    accountNumber = numberOrCPF.Value;
                }
            }

            return accountNumber;
        }
    }
}
