using EdgeItalianPizza.Application.DTOs.Customers;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities.Customers;
using EdgeItalianPizza.Domain.Entities.Customers.Interfaces;
using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using EdgeItalianPizza.Share.ResultPattern;
using EdgeItalianPizza.Share.ResultPattern.Extensions;

namespace EdgeItalianPizza.Application.Services;

public sealed class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public async Task<Result<Response>> AuthorizationAsync(Request request)
    {
        string errorMessage = "Неверный номер телефона или пароль";

        try
        {
            if (!AttemptHandleRequest(request, out PhoneNumber phoneNumber, out Password password))
                return errorMessage;

            var customer = Customer.Create(phoneNumber, password);

            if (customer.IsFailure)
                return errorMessage;

            var memberNames = new string[]
            {
                nameof(Customer.Id),
                nameof(Customer.PhoneNumber),
                nameof(Customer.DateOfBirth),
                nameof(Customer.BonusCoins)
            };

            var searchedCustomer = await repository.GetAsync(phoneNumber, password, memberNames).ConfigureAwait(false);

            return searchedCustomer.Match(
                () => GetResponse(searchedCustomer),
                () => errorMessage);
        }
        catch
        {
            return errorMessage;
        }
    }

    public async Task<Result<Response>> RegistrationAsync(Request request)
    {
        string errorMessage = "Неверный номер телефона или пароль";

        try
        {
            if (!AttemptHandleRequest(request, out PhoneNumber phoneNumber, out Password password))
                return errorMessage;

            var customer = await CreateCustomer(phoneNumber, password);

            if (customer.IsFailure)
                return customer.ErrorMessage;

            var searchedCustomer = await repository.AddAsync(customer.Value).ConfigureAwait(false);

            if (searchedCustomer is null)
                return errorMessage;

            return GetResponse(searchedCustomer);
        }
        catch
        {
            return errorMessage;
        }
    }

    /// <summary>
    /// Получение покупателя.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    private async Task<Result<Customer>> CreateCustomer(PhoneNumber phoneNumber, Password password)
    {
        var phoneNumbers = await repository.GetAllPhoneNumbersAsync().ConfigureAwait(false);

        return Customer.Create(phoneNumber, phoneNumbers, password);
    }

    /// <summary>
    /// Метод попытки обработать запрос.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если данные с <see cref="Request"/> прошли валидацию,
    /// в противном случае <see langword="false"/>.
    /// </returns>
    private static bool AttemptHandleRequest(Request request, out PhoneNumber phoneNumber, out Password password)
    {
        var creationPhoneNumber = PhoneNumber.Create(request.PhoneNumber);
        var creationPassword = Password.Create(request.Password);

        phoneNumber = creationPhoneNumber.Value;
        password = creationPassword.Value;

        return creationPhoneNumber.IsSuccess && creationPassword.IsSuccess;
    }

    /// <summary>
    /// Метод получения экземпляра класса <see cref="Response"/>.
    /// </summary>
    /// <param name="customer">Покупатель.</param>
    private static Response GetResponse(Customer customer)
    {
        return new Response(
            customer.Id,
            customer.PhoneNumber.Number,
            customer.DateOfBirth,
            customer.BonusCoins);
    }

    public async Task<Result> SetDateOfBirthAsync(DateOfBirthRequest request)
    {
        if (request.DateOfBirth is null)
            return "Неверно указанная дата рождения, необходимый формат: День-Месяц-Год";

        string errorMessage = "Не удалось установить дату рождения";

        try
        {
            var customer = await repository.GetAsync(request.CustomerId).ConfigureAwait(false);

            if (customer is null)
                return errorMessage;

            if (!customer.SetDateOfBirth(request.DateOfBirth))
                return errorMessage;

            if (!await repository.UpdateAsync(customer))
                return errorMessage;

            return Result.Success();
        }
        catch
        {
            return errorMessage;
        }
    }

    public async Task<Result> ChangePasswordAsync(ChangePasswordRequest request)
    {
        string errorMessage = "Не удалось сменить пароль";

        try
        {
            if (!AttemptHandleChangePasswordRequest(request, out Password oldPassword, out Password newPassword))
                return errorMessage;

            var customer = await repository.GetAsync(request.CustomerId).ConfigureAwait(false);

            if (customer is null)
                return errorMessage;

            var changePassword = customer.ChangePassword(oldPassword, newPassword);

            if (changePassword.IsFailure)
                return changePassword.ErrorMessage;

            if (!await repository.UpdateAsync(customer))
                return errorMessage;

            return Result.Success();
        }
        catch
        {
            return errorMessage;
        }
    }

    private static bool AttemptHandleChangePasswordRequest(ChangePasswordRequest request, out Password oldPassword, out Password newPassword)
    {
        var oldPasswordCreation = Password.Create(request.OldPassword);
        var newPasswordCreation = Password.Create(request.NewPassword);

        oldPassword = oldPasswordCreation.Value; 
        newPassword = newPasswordCreation.Value;

        return oldPasswordCreation.IsSuccess && newPasswordCreation.IsSuccess;
    }

    public async Task AddBonusCoins(long id, int bonusCoins)
    {
        try
        {
            Customer customer = repository.Get(id);

            customer.AddBonusCoins(bonusCoins);

            await repository.UpdateAsync(customer);
        }
        catch { }
    }

    public async Task RemoveBonusCoins(long id)
    {
        try
        {
            Customer customer = repository.Get(id);

            customer.RemoveBonusCoins();

            await repository.UpdateAsync(customer);
        }
        catch { }
    }
}
