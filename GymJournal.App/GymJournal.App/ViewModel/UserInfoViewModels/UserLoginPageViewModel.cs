﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymJournal.App.Services;
using GymJournal.App.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymJournal.App.ViewModel
{
	public partial class LoginPageViewModel : BaseViewModel
	{
		private readonly IUserInfoService _userInfoService;
		private readonly ExceptionHandlerService _exceptionHandlerService;

		public LoginPageViewModel(IUserInfoService userInfoService, ExceptionHandlerService exceptionHandlerService)
		{
			_userInfoService = userInfoService ?? throw new ArgumentNullException(nameof(userInfoService));
			_exceptionHandlerService = exceptionHandlerService ?? throw new ArgumentNullException(nameof(exceptionHandlerService));
		}

		[ObservableProperty]
		public string inputUserName;

		[ObservableProperty]
		public string inputPassword;

		[RelayCommand]
		public async void Login()
		{
			if (IsBusy) return;

			try
			{
				IsBusy = true;

				await _userInfoService.Login(InputUserName, InputPassword);
			}
			catch (Exception ex)
			{
				await _exceptionHandlerService.HandleException(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
