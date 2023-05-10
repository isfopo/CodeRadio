using CodeRadio.ViewModel;

namespace CodeRadio;

public partial class MainPage : ContentPage
{
	MainViewModel viewModel;

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetRadioCommand.Execute(null);
    }
}


