using System;
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
using System.Windows.Shapes;

namespace proba_database_wpf.Dialogos.AcciónsDllsWindow
{
    /// <summary>
    /// Lógica de interacción para AddNewDllWindow.xaml
    /// </summary>
    public partial class AddNewDllWindow : Window
    {

        #region Singleton

        private static AddNewDllWindow _instancia;

        public static AddNewDllWindow getInstance(int id)
        {
            if(_instancia == null)
            {
                _instancia = new AddNewDllWindow(id);
            }

            return _instancia;
        }

        #endregion

        private static int Id_usuario;
        public AddNewDllWindow(int id)
        {
            InitializeComponent();
            Id_usuario = id;
        }

        private void btnAddDll_Click(object sender, RoutedEventArgs e)
        {
            if(txtDllName.Text.Length == 0 || txtDescription.Text.Length == 0)
            {
                MessageBox.Show("Todos los campos deben estar cubiertos", "Error");
                return;
            } else
            {
                Conexion.insertNewDll(txtDllName.Text, txtDescription.Text, Id_usuario);
                MessageBox.Show("Dll añadida a la biblioteca", "Éxito");
                Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _instancia = null;
        }
    }
}
