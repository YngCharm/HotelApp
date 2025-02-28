using HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace HotelApp.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Page
    {
        Database database = new Database();
        Hash hash = new Hash();
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrationSuccess())
            {
                NavigationService.GoBack();
            }
            else { MessageBox.Show("Ошибка"); }
        }

        private bool RegistrationSuccess()
        {
            var firstname = Firstname.Text;
            var lastname = Lastname.Text;
            var login = Login.Text;
            var password = Password.Password;

            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен быть не менее 8 символов");
                    return false;
            }
            string hashedPassword = hash.HashPassword(password);
            return (insertUser(firstname, lastname, login, hashedPassword));
        }

        private bool insertUser(string firstname, string lastname, string login, string hashedPassword)
        {
            string checkQuery = "SELECT COUNT(*) FROM Guest WHERE Login = @Login";

            try
            {
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, database.GetConnection()))
                {
                    checkCommand.Parameters.AddWithValue("@Login", login);
                    database.OpenConnection();

                    int userCount = (int)checkCommand.ExecuteScalar();

                    if(userCount > 1)
                    {
                        MessageBox.Show("Логин уже занят");
                        return false;
                    }
                }
                string query = "INSERT INTO Guest (Login, Firstname, Lastname, Hashpassword
            }
        }
    }
}
