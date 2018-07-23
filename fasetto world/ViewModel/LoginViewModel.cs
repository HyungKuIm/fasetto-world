using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace fasetto_world
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        public async Task Login(object parameter)
        {
            LoginIsRunning = true;
            try
            {
                await Task.Delay(5000);

                var email = this.Email;
                var pass = this.Password;
                MessageBox.Show("login success");
                //var page = (System.Windows.Controls.Page)parameter;
                //Window mainWin = Window.GetWindow(page);
                //WindowViewModel ViewModel = (WindowViewModel)mainWin.DataContext;
                //ViewModel.CurrentPage = ApplicationPage.Chat;
            } finally
            {
                LoginIsRunning = false;
            }
        }
    }
}
