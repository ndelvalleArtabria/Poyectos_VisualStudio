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
    /// Lógica de interacción para UpdateDll.xaml
    /// </summary>
    public partial class UpdateDll : Window
    {
        #region Singleton

        private static UpdateDll _instancia;

        public static UpdateDll getInstance()
        {
            if(_instancia == null)
            {
                _instancia = new UpdateDll(Id_dll);
            }
            return _instancia;
        }

        #endregion

        private static int Id_dll;
        public UpdateDll(int id)
        {
            InitializeComponent();
            Id_dll = id;
        }

        private void btnUpdateDll_Click(object sender, RoutedEventArgs e)
        {
            Conexion.updateUserDll(txtDllName.Text, txtDescription.Text, Id_dll);
            MessageBox.Show("Dll actualizada", "Éxito");
            Close();
        }
    }
}
