﻿using Microsoft.Extensions.Logging;
using ApiClient.IoC;
using MauiBlazor.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Globalization;

namespace MauiBlazor
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            //builder.Services.AddAuthorizationCore();
            builder.Services.AddApiClientService(x => x.BaseAddress = "http://10.0.2.2:5172/");
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<Services.AppData>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
#endif
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de-DE");

            return builder.Build();
		}
	}
}
