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
//using System.Data.SqlClient;
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
    /// Lógica de interacción para ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
       
        
        public ResetPassword()
        {
            InitializeComponent();
        }
        private void EnviarButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsuariotextBox.Text;
            string email = GetEmailByUsername(username);
            string resetCode = GenerateResetCode();
            if (SendResetCodeByEmail(email, resetCode))
            {
                // Aquí puedes guardar el resetCode en una base de datos o en memoria para su posterior validación
                string guardarcode = "insert into password_reset(username,reset_code)value('" + username + "'," + resetCode + ")";
                SQLiteCommand cmd = new SQLiteCommand(guardarcode, ConexionDB.conectar());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha enviado un código de restablecimiento a su dirección de correo electrónico registrada.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                verifyGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("No se pudo enviar el código de restablecimiento. Por favor, intente nuevamente más tarde.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private string GenerateResetCode()
        {
            const string digits = "0123456789";
            var random = new Random();

            // Genera una cadena de 6 dígitos aleatorios
            string resetCode = new string(Enumerable.Repeat(digits, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return resetCode;
        }
        private bool SendResetCodeByEmail(string email, string resetCode)
        {
            try
            {
                string username = UsuariotextBox.Text;
                string senderEmail = GetEmailByUsername(username);
                string senderPassword = senderPasswordtextBox.Password;
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;

                // Configurar el mensaje de correo electrónico
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(senderEmail));
                message.To.Add(MailboxAddress.Parse(email));
                message.Subject = "Código de restablecimiento de contraseña";
                message.Body = new TextPart("plain")
                {
                    Text = "Su código de restablecimiento de contraseña es: " + resetCode
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                    client.Authenticate(senderEmail, senderPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el código de restablecimiento por correo electrónico: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private void VerificarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string select = "SELECT COUNT(*) FROM password_reset WHERE username = '" + UsuariotextBox.Text + "' AND reset_code = " + resetcodetextBox.Text + "";
                SQLiteCommand cmd = new SQLiteCommand(select, ConexionDB.conectar());

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    resetGrid.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el código de restablecimiento y actualizar la contraseña: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string update = "UPDATE users SET password = '" + updatetextBox.Password + "' WHERE username = '" + UsuariotextBox.Text + "'";
                SQLiteCommand cmd1 = new SQLiteCommand(update, ConexionDB.conectar());
                cmd1.ExecuteNonQuery();

                // Eliminar el registro de reset_code de la tabla password_reset
                string delete = "DELETE FROM password_reset WHERE username = '" + UsuariotextBox.Text + "'";
                SQLiteCommand cmd2 = new SQLiteCommand(delete, ConexionDB.conectar());
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Contraseña actualizada!", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
