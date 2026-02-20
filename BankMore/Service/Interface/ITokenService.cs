using BankMore.Account.Application.Features.Account.Commands;

namespace BankMore.Account.API.Service.Interface
{
    public interface ITokenService
    {
        string GenerateToken(LoginCommand loginCommand);
    }
}
