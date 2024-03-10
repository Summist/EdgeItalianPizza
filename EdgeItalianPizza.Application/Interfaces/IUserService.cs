using EdgeItalianPizza.Application.DTOs;

namespace EdgeItalianPizza.Application.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetAuthorization(
        string login,
        string password,
        ILoginValidateService loginValidateService,
        IPasswordValidateService passwordValidateService,
        IHashService hashService);
}
