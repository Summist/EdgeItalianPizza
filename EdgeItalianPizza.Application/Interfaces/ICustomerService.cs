using EdgeItalianPizza.Application.DTOs;

namespace EdgeItalianPizza.Application.Interfaces;

public interface ICustomerService
{
    Task<ResultDto<AuthCustomerDto>> GetAuthorization(
        string login,
        string password,
        ILoginValidateService loginValidateService,
        IPasswordValidateService passwordValidateService,
        IHashService hashService);
}
