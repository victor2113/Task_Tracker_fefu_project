using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_trecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            string password_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            int i = 4;

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Некорректный логин!";
                textBoxLogin.Foreground = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.Foreground = Brushes.Black;
                i--;
            }
            if (password.Length < 8)
            {
                passBox.ToolTip = "Некорректный пароль!";
                passBox.Foreground = Brushes.Red;
            }
            else
            {
                passBox.ToolTip = null;
                passBox.Foreground = Brushes.Black;
                i--;
            }
            if (password != password_2)
            {
                passBox_2.ToolTip = "Пароли не совпадают!";
                passBox_2.Foreground = Brushes.Red;
            }
            else
            {
                passBox_2.ToolTip = null;
                passBox_2.Foreground = Brushes.Black;
                i--;
            }
            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Некорректный Email!";
                textBoxEmail.Foreground = Brushes.Red;
            }
            else
            {
                textBoxEmail.ToolTip = null;
                textBoxEmail.Foreground = Brushes.Black;
                i--;
            }
            if (i == 0)
            {
                MessageBox.Show("Все круто");
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}
