using proba_database_wpf.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace proba_database_wpf.Dialogos
{
    /// <summary>
    /// Lógica de interacción para SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        #region Singleton

        private static SignUpWindow _instance;

        public static SignUpWindow getInstance()
        {
            if(_instance == null)
            {
                _instance = new SignUpWindow();
            }

            return _instance;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instance = null;
        }

        #endregion

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string password = new NetworkCredential("", txtPassword.SecurePassword).Password;

            if (txtUsername.Text.Length == 0 || password.Length == 0 || txtMail.Text.Length == 0)
            {
                MessageBox.Show("Todos los campos deben estar llenos", "Error");
                return;
            }
            else
            {
                Conexion.insertNewUser(txtUsername.Text, password, txtMail.Text);
                MessageBox.Show("Usuario registrado", "Éxito", (MessageBoxButtons)MessageBoxButton.OK);

                Close();
                _instance = null;
            }
        }
    }
}
