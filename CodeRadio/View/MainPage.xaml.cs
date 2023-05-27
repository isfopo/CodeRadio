using CodeRadio.ViewModel;
using CommunityToolkit.Maui.Core.Primitives;

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

	void Play(object? sender, EventArgs e)
    {
		mediaElement.Play();
		viewModel.ResumeIncrementCommand.Execute(null);
	}

	void Pause(object? sender, EventArgs e)
    {
		mediaElement.Pause();
        viewModel.PauseIncrementCommand.Execute(null);
    }
}
