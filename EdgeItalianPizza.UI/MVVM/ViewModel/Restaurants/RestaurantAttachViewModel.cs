using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Restaurants;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Share.ResultPattern;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.MVVM.Model.Restaurants;
using EdgeItalianPizza.UI.Share.Info;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class RestaurantAttachViewModel(IRestaurantService service, RestaurantModel model) : ViewModelBase
{
    private RestaurantModel _model = model;
    /// <summary>
    /// Модель ресторана.
    /// </summary>
    public RestaurantModel Model
    {
        get => _model;
        set
        {
            _model = value; 
            OnPropertyChanged(nameof(Model));
        }
    }

    private string _attachErrorMessage = string.Empty;
    /// <summary>
    /// Сообщение об ошибке при прикреплению.
    /// </summary>
    public string AttachErrorMessage
    {
        get => _attachErrorMessage;
        set
        {
            _attachErrorMessage = value;
            OnPropertyChanged(nameof(AttachErrorMessage));
        }
    }

    /// <summary>
    /// Асинхронная команда для прикрепления терминала к ресторану.
    /// </summary>
    public IAsyncCommand AttachCommandAsync { get; private set; }

    protected override void InitializeComponents()
    {
        AttachCommandAsync = new AsyncCommand(AttachCommandAsyncExecute);
    }

    private async Task AttachCommandAsyncExecute()
    {
        if (!Model.IsValid())
            return;

        var request = new AuthorizationRequest(Model.Login, Model.Password);

        Result<AuthorizationResponse> response = await Task.Run(() => service.Authorization(request));

        HandleAuthorizationResponse(response);
    }

    private void HandleAuthorizationResponse(Result<AuthorizationResponse> response)
    {
        if (response.IsFailure)
            AttachErrorMessage = response.ErrorMessage;
        else
            RestaurantInfo.Info = response.Value.Id;
    }
}
