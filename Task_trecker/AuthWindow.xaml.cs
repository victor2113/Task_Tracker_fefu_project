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
using System.Windows.Shapes;

namespace Task_trecker
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
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

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            int i = 2;

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
            if (i == 0)
            {
                User user = new(login , password);
                user.Sign_in();
                if (user.user_entry)
                {
                    TestWindow testwindow = new TestWindow();
                    testwindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("1232");
                    textBoxLogin.Foreground = Brushes.Red;
                    passBox.Foreground = Brushes.Red;
                }

            }
        }

        private void Button_Window_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
