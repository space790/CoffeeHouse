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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource = Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "Gender1";
        }

        private void TextBlock_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            AccountWindow auth = new AccountWindow();
            auth.Show();            
            this.Close();
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть введен");
                return;
            }

            var authUser = Context.Guest.ToList().Where(i => i.Login == TbLogin.Text ).FirstOrDefault();
            if (authUser != null )
            {
                MessageBox.Show("Данные введены не верно");

            }
            else if (TbEMail.Text != "" && TbFirstName.Text != "" && TbPhone.Text != "" && PbPassword.Password == PbPasswordSecond.Password && PbPassword.Password != "")
            {
                
                DB.Guest guest = new DB.Guest();
                guest.Login = TbLogin.Text;
                guest.Name = TbFirstName.Text;
                guest.Email = TbEMail.Text;
                guest.Phone = TbPhone.Text;
                guest.IDGender = (CmbGender.SelectedItem as DB.Gender).IDGender;
                guest.Birthday = CBirthDate.SelectedDate.Value;
                guest.Password = PbPassword.Password;
                Context.Guest.Add(guest);

                MessageBox.Show("регистрация выполнена");
                Context.SaveChanges();
            }

           

        }
    }
}
