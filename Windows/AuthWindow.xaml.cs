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
using static GS3ISP9_14.ClassHelper.EFClass;

namespace GS3ISP9_14.Windows
{
    /// <summary>
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegWindow reg = new RegWindow();
            reg.Show();
            this.Close();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var authUser = Context.Guest.ToList().Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).FirstOrDefault();
            if (authUser != null)
            {
                MessageBox.Show("Вход выполнен");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
