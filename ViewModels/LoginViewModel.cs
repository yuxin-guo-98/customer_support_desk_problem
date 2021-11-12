using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

//not completed
//
//


/*

namespace customersupport.ViewModels
{
	public class LoginViewModel
	{
		private string _username = "Admin_1_QWERTY";
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		#region Input validations & Error management
		//cannot have empty/invalid field
		/// <summary>
		///need to create more commands for login, 
		///& develop authenticator for checking login details - i.e. some try catch for invalid user/passwords
		///& navigator for switching from login UI to entering customer details UI
		/// </summary>
		public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
		
		public MessageViewModel ErrorMessageViewModel { get; }

		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}

		public ICommand LoginCommand { get; }

		public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator)
		{
			ErrorMessageViewModel = new MessageViewModel();

			LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
		}

		//disposing error message
		public override void Dispose()
		{
			ErrorMessageViewModel.Dispose();

			base.Dispose();
		}
        #endregion
    }
}
*/