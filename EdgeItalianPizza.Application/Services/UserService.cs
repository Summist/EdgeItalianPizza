using EdgeItalianPizza.Application.DTOs;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities;
using EdgeItalianPizza.Domain.Interfaces.Repository;

namespace EdgeItalianPizza.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILoggerService _loggerService;

    public UserService(IUserRepository userRepository, ILoggerService loggerService)
    {
        _userRepository = userRepository;
        _loggerService = loggerService;
    }

    public async Task<UserDto?> GetAuthorization(
        string login,
        string password,
        ILoginValidateService loginValidateService,
        IPasswordValidateService passwordValidateService,
        IHashService hashService)
    {
        try
        {
            if (!IsInputValidate(login, password, loginValidateService, passwordValidateService))
            {
                return null;
            }

            string hashPassword = hashService.Hash(password);

            CustomerEntity? searchedUser = await _userRepository.GetByLoginAndPasswordAsync(login, password);

            if (searchedUser is null)
            {
                return null;
            }

            var userDto = new UserDto()
            {
                Id = searchedUser.Id,
                FisrtName = searchedUser.FisrtName,
                LastName = searchedUser.LastName,
                DateOfBirth = searchedUser.DateOfBirth,
            };

            return userDto;
        }
        catch (Exception ex)
        {
            _loggerService.Error(ex.Message);
            return null;
        }
    }

    private bool IsInputValidate(
        string login,
        string password,
        ILoginValidateService loginValidateService,
        IPasswordValidateService passwordValidateService)
    {
        if (loginValidateService is null ||
            passwordValidateService is null)
        {
            _loggerService.Error("");
            return false;
        }

        return loginValidateService.IsValidate(login) &&
               passwordValidateService.IsValidate(password);
    }
}
