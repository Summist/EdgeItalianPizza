using EdgeItalianPizza.Application.DTOs;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities;
using EdgeItalianPizza.Domain.Interfaces.Repository;

namespace EdgeItalianPizza.Application.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _userRepository;
    private readonly ILoggerService _loggerService;

    public CustomerService(ICustomerRepository userRepository, ILoggerService loggerService)
    {
        _userRepository = userRepository;
        _loggerService = loggerService;
    }

    public async Task<AuthorizationUserDto> GetAuthorization(
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
                return new AuthorizationUserDto() { Status = -1 };
            }

            string hashPassword = hashService.Hash(password);

            CustomerEntity? searchedUser = await _userRepository.GetByLoginAndPasswordAsync(login, password);

            if (searchedUser is null)
            {
                return new AuthorizationUserDto() { Status = 0 };
            }

            var userDto = new AuthorizationUserDto()
            {
                Status = 1,
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

        return loginValidateService.IsValidate(login) &
               passwordValidateService.IsValidate(password);
    }
}
