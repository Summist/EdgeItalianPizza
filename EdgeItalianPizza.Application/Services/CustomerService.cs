using EdgeItalianPizza.Application.DTOs;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities;
using EdgeItalianPizza.Domain.Enums;
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

    public async Task<ResultDto<AuthCustomerDto>> GetAuthorization(
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
                return new(null, Status.Error);
            }

            string hashPassword = hashService.Hash(password);

            CustomerEntity? searchedUser = await _userRepository.GetByLoginAndPasswordAsync(login, password);

            if (searchedUser is null)
            {
                return new(new(), Status.Filure);
            }

            var userDto = new AuthCustomerDto()
            {
                Id = searchedUser.Id,
                FirstName = searchedUser.FisrtName,
                LastName = searchedUser.LastName,
                DateOfBirth = searchedUser.DateOfBirth,
            };

            return new(userDto, Status.Success);
        }
        catch (Exception ex)
        {
            _loggerService.Error(ex.Message);
            return new(new(), Status.Error);
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
