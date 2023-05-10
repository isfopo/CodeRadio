using System;
using System.Collections.ObjectModel;
using CodeRadio.Model;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;

namespace CodeRadio.ViewModel;

public partial class MainViewModel : BaseViewModel
{
	public ObservableCollection<RadioResponse> Response { get; } = new();

    public MainViewModel()
	{
		Title = "CodeRadio";
	}

	[RelayCommand]
	async Task GetRadioAsync()
	{
		if (IsBusy)
			return;
	}
}

