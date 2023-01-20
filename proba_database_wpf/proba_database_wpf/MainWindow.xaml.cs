using System;
using proba_database_wpf.Dialogos;
using proba_database_wpf.Controlador;
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
using System.Net;

namespace proba_database_wpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Conexion.Conectar();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int Id_usuario = 0;
            string password = new NetworkCredential("", txtPassword.SecurePassword).Password;

            var lector = Conexion.selectUserId(txtUsername.Text, password);
            while (lector.Read())
            {
                Id_usuario = lector.GetInt32(0);
            }
            DllsWindow ventana = new DllsWindow(Id_usuario, txtUsername.Text);
            ventana.Show();

            Close();
        }

        private void lblSignUp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SignUpWindow dialogo = SignUpWindow.getInstance();
            dialogo.Show();
        }
    }
}
