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

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async () => await Login());
        }

        public async Task Login()
        {
            await Task.Delay(5000);

            var email = this.Email;
            var pass = this.Password;
            MessageBox.Show("login success");
        }
    }
}
