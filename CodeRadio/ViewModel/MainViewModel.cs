using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
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
    public Station station;

    [ObservableProperty]
    public Listeners listeners;

    [ObservableProperty]
    public Live live;

    [ObservableProperty]
    public NowPlaying nowPlaying;

    [ObservableProperty]
    public PlayingNext playingNext;

    [ObservableProperty]
    public NowPlaying[] songHistory;

    [ObservableProperty]
    public bool isOnline;

    [ObservableProperty]
    public string cache;

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

        Station = res.Station;
        Listeners = res.Listeners;
        Live = res.Live;
        NowPlaying = res.NowPlaying;
        PlayingNext = res.PlayingNext;
        SongHistory = res.SongHistory;
        IsOnline = res.IsOnline;
        Cache = res.Cache;

		IsBusy = false;
	}
}

