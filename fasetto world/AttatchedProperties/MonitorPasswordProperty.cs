
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace fasetto_world
{
    public class MonitorPasswordProperty : BaseAttatchedProperty<MonitorPasswordProperty, bool>
    {

        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        { 
            //Get the caller
            var passwordBox = d as PasswordBox;

            //Make sure it is a password box
            if (passwordBox == null)
                return;

            // Remove any previous events
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // If the caller set MonitorPassword to true
            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private  void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //HasCorrectTextProperty.SetValue((PasswordBox)sender);
            var passwordBox = (PasswordBox)sender;
            //if (passwordBox.SecurePassword.Length > 0)
            //MessageBox.Show(passwordBox.SecurePassword.ToString());
            var stackPanel = passwordBox.Parent;
            Button nextButton = FindVisualChildByName<Button>(stackPanel, "btnNext");
            if (Regex.IsMatch(passwordBox.Password, "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$"))
            {
                passwordBox.Background = new SolidColorBrush(Colors.Green);
                
               
                nextButton.IsEnabled = true;
                //HasCorrectTextProperty.SetValue((PasswordBox)sender, true);
            } else
            {
                passwordBox.Background = new SolidColorBrush(Colors.Red);
                nextButton.IsEnabled = false;
                //HasCorrectTextProperty.SetValue((PasswordBox)sender, false);
            }
        }

        public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
    }

    public class HasCorrectTextProperty : BaseAttatchedProperty<HasCorrectTextProperty, bool>
    {
        //public static void SetValue(DependencyObject sender)
        //{
        //    SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        //}
    }
}
