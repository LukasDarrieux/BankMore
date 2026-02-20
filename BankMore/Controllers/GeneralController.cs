using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BankMore.Account.API.Controllers
{
    public class GeneralController : ControllerBase
    {

        public GeneralController()
        {
            
        }

        protected string GetAccountNumber()
        {
            string accountNumber = string.Empty;
            string tokenJwt = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (!string.IsNullOrEmpty(tokenJwt))
            {
                tokenJwt = tokenJwt.Replace("Bearer", string.Empty);
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(tokenJwt);

                if (!(jwtSecurityToken is null))
                {
                    var numberOrCPF = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type.Equals("AccountNumber", StringComparison.OrdinalIgnoreCase));

                    accountNumber = numberOrCPF.Value;
                }
            }

            return accountNumber;
        }
    }
}
