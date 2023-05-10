using System;
using System.Collections.ObjectModel;
using CodeRadio.Model;
using CodeRadio.Services;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeRadio.ViewModel;

public partial class MainViewModel : BaseViewModel
{
	RadioService radioService;

	[ObservableProperty]
	public RadioResponse response;

    IConnectivity connectivity;

    public MainViewModel(RadioService radioService, IConnectivity connectivity)
	{
		Title = "CodeRadio";
		this.radioService = radioService;
		this.connectivity = connectivity;
	}

	[RelayCommand]
	async Task GetRadioAsync()
	{
		if (IsBusy)
			return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No Internet",
                $"Please check and try again.", "OK");
            return;
        }

		IsBusy = true;

		var res = await radioService.GetRadio();

		if (res is null)
		{
			await Shell.Current.DisplayAlert("Try Again", "Could not get Code Radio", "OK");
			return;
		}

		Response = res;
		IsBusy = false;
	}
}

