using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class CodeViewModel : ViewModelBase
{
	public static Action OnNextButtonClicked;

	private string _code;
	public string Code
	{
		get => _code;
		set 
		{ 
			_code = value;
			OnPropertyChanged(nameof(Code));
		}
	}

	public ICommand LoadedCommand { get; private set; }
    public ICommand NextCommand { get; private set; }

    protected override void InitializeComponents()
    {
		LoadedCommand = new RelayCommand(LoadedCommandExecute);
		NextCommand = new RelayCommand(NextCommandExecute);
    }

	private void LoadedCommandExecute(object obj)
	{
		Code = OrderInfo.Code;
		OrderInfo.Code = string.Empty;
    }

	private void NextCommandExecute(object obj) 
	{
		OnNextButtonClicked?.Invoke();

    }
}
