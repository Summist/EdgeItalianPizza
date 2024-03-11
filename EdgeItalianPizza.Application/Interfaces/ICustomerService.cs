using EdgeItalianPizza.Application.DTOs;

namespace EdgeItalianPizza.Application.Interfaces;

public interface ICustomerService
{
    Task<AuthorizationUserDto> GetAuthorization(
        string login,
        string password,
        ILoginValidateService loginValidateService,
        IPasswordValidateService passwordValidateService,
        IHashService hashService);
}
