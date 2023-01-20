using System;
using proba_database_wpf.Controlador;
using proba_database_wpf.Dialogos.AcciónsDllsWindow;
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
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace proba_database_wpf.Dialogos
{
    /// <summary>
    /// Lógica de interacción para DllsWindow.xaml
    /// </summary>
    public partial class DllsWindow : Window
    {
        public class Dll
        {
            public int Id { get; set; }
            public string Nomedll { get; set; }
            public string Descripcion { get; set; }

            public Dll(int id, string nomedll, string descripcion)
            {
                Id = id;
                Nomedll = nomedll;
                Descripcion = descripcion;
            }
        }

        private static int id_usuario;
        public DllsWindow(int id, string nomeusuario)
        {
            InitializeComponent();
            Conexion.Conectar();
            id_usuario = id;
            lblUser.Content = $"User: {nomeusuario}";
            
            llenarLista();
        }

        private void llenarLista()
        {
            List<Dll> listaDlls = new List<Dll>();
            var lector = Conexion.selectUserDlls(id_usuario);
            while (lector.Read())
            {
                listaDlls.Add(new Dll(lector.GetInt32(0), lector.GetString(1), lector.GetString(2)));
            }
            dgUserDlls.ItemsSource = listaDlls;
        }

        private void btnAddNewDll_Click(object sender, RoutedEventArgs e)
        {
            var Ventana = AddNewDllWindow.getInstance(id_usuario);
            Ventana.Show();
        }

        private void btnUpdateSelectedDll_Click(object sender, RoutedEventArgs e)
        {
            String[] datos_dll = new string[2];

           // var lector = Conexion.selectValuesForUpdate()

            var Ventana = UpdateDll.getInstance();
            Ventana.Show();
        }

        private void btnRemoveSelectedDll_Click(object sender, RoutedEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Desea borrar la dll seleccionada", "Advertencia", (MessageBoxButtons)MessageBoxButton.YesNoCancel);
            if(respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                //Conexion.deleteUserDll(dgUserDlls.SelectedIndex);
                //MessageBox.Show("Dll eliminada", "Éxito");
            }
            else
            {
                return;
            }
        }

        private void btnShowReport_Click(object sender, RoutedEventArgs e)
        {
            var lector = Conexion.selectUserDlls(id_usuario);
            StringBuilder sb = new StringBuilder();
            while (lector.Read())
            {
                sb.Append(lector.GetInt32(0)).Append(" | ").Append(lector.GetString(1)).Append(" - ").Append(lector.GetString(2)).Append("\n\n");
            }
            MessageBox.Show(sb.ToString(), "Informe");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Conexion.Desconectar();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            llenarLista();
        }
    }
}
