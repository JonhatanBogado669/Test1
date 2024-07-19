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
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Security.Cryptography;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Collections.ObjectModel;
using System.Collections;
using test1.models;
using test1;


namespace test1
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {

     
    
        public Login()
        {
            InitializeComponent();
        }

        /////////////////////////////////Login/////////////////////////////////////
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernametextBox.Text;
            string password = PasswordtextBox.Password;

            if (string.IsNullOrEmpty(UsernametextBox.Text) || string.IsNullOrEmpty(PasswordtextBox.Password))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario y contraseña.", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (LoginU(UsernametextBox.Text, PasswordtextBox.Password))
            {
                // Inicio de sesión exitoso, realizar acciones según el rol del usuario
                string role = GetUserRole(UsernametextBox.Text);
                switch (role)
                {
                    case "Admin":
                        // Lógica para el rol de administrador
                        UsernametextBox.Text = null;
                        PasswordtextBox.Password = null;
                        MainWindow main = new MainWindow();
                        main.Show();
                        Close();
                        MessageBox.Show("¡Inicio de sesión exitoso como administrador!", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case "Usuario":
                        // Lógica para el rol de usuario normal
                        UsernametextBox.Text = null;
                        PasswordtextBox.Password = null;
                        MainWindow main2 = new MainWindow();
                        main2.Show();
                        Close();
                        main2.label1.Visibility = Visibility.Collapsed;
                        main2.label2.Visibility = Visibility.Collapsed;
                        main2.periodotextBox.Visibility = Visibility.Collapsed;
                        main2.vehiculocomboBox.Visibility = Visibility.Collapsed;
                        main2.button2.Visibility = Visibility.Collapsed;
                        main2.button4.Visibility = Visibility.Collapsed;
                        main2.label.Visibility = Visibility.Collapsed;
                        main2.codtextBox.Visibility = Visibility.Collapsed;
                        main2.button.Visibility = Visibility.Collapsed;
                        main2.buttonmody.Visibility = Visibility.Collapsed;
                        main2.buttondelete1.Visibility = Visibility.Collapsed;
                        main2.guardarres.Visibility = Visibility.Collapsed;
                        main2.modificarres.Visibility = Visibility.Collapsed;
                        main2.borrarres.Visibility = Visibility.Collapsed;
                        main2.reg.Visibility = Visibility.Collapsed;
                        MessageBox.Show("¡Inicio de sesión exitoso como usuario!", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        MessageBox.Show("El usuario no tiene un rol válido.", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool LoginU(string username, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);
                ConexionDB.conectar();

                string cadena = "SELECT COUNT(*) FROM users WHERE username = '" + UsernametextBox.Text + "' AND password = '" + PasswordtextBox.Password + "'";
                SQLiteCommand cmd = new SQLiteCommand(cadena, ConexionDB.conectar());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private string GetUserRole(string username)
        {
            try
            {
                ConexionDB.conectar();

                string cadena = "SELECT role FROM users WHERE username = '" + UsernametextBox.Text + "'";
                SQLiteCommand cmd = new SQLiteCommand(cadena, ConexionDB.conectar());
                string role = cmd.ExecuteScalar()?.ToString();
                return role;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el rol del usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /////////////////////////Reseteo de Contraseña/////////////////////////////
        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernametextBox.Text;
            ResetPassword respass = new ResetPassword();
       
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string email = GetEmailByUsername(username);
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("No se encontró ninguna dirección de correo electrónico asociada a ese nombre de usuario.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (username != null && email != null)
            {
                if (respass.Visibility == Visibility.Visible)
                {
                    respass.Focus();
                }
                else
                {
                    respass.Show();
                }

            }
            


        }
        private string GetEmailByUsername(string username)
        {
            try
            {

                string query = "SELECT correo FROM users WHERE username = '" + username + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, ConexionDB.conectar());
                string email = cmd.ExecuteScalar()?.ToString();
                return email;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la dirección de correo electrónico: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

    }
}
