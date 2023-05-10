using System;
using System.Net.Http.Json;
using CodeRadio.Model;

namespace CodeRadio.Services;

public class RadioService
{
	HttpClient httpClient;

	public RadioService()
	{
		this.httpClient = new HttpClient();
	}

	public async Task<RadioResponse> GetRadio()
	{
		var response = await httpClient.GetAsync("https://coderadio-admin.freecodecamp.org/api/live/nowplaying/coderadio");

		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadFromJsonAsync<RadioResponse>();
		}
		else
		{
			return null;
		} 
	}
}

