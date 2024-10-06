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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Collections;
using test1.models;
using test1;

namespace test1
{
    /// <summary>
    /// Lógica de interacción para VehiculoWindow.xaml
    /// </summary>
    public partial class VehiculoWindow : Window
    {
        private MainWindow _mainWindow;
        ObservableCollection<Tipocombus> listtipocombus = new ObservableCollection<Tipocombus>();
        public VehiculoWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            TipocomboBox.ItemsSource = listtipocombus;
            ConexionDB.conectar();
            Carga();
            Mostrar();
            
        }
        public void Limpiar()
        {
            CodigovehtextBox.Text = "";
            descripvehtextBox.Text = "";
            chapatextBox.Text = "";
            TipocomboBox.Text = "";
        }
        public void Mostrar()
        {
            string mostrarveh = "select v.idvehiculo as codigo, v.descripcion, v.chapa, t.descripcion as combustible from vehiculo v inner join tipo_combus t where t.idtipo_combus=v.idtipo_combus order by codigo asc";
            SQLiteCommand cmd = new SQLiteCommand(mostrarveh, ConexionDB.conectar());
            VehiculodataGrid.ItemsSource = cmd.ExecuteReader();
        }
       public void Carga()
        {
            string cargar = "select idtipo_combus,descripcion from tipo_combus";
            SQLiteCommand cmd = new SQLiteCommand(cargar, ConexionDB.conectar());
            SQLiteDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Tipocombus t = new Tipocombus();
                t.IdTipoCombus = r.GetValue(0).ToString();
                t.Descripcion = r.GetValue(1).ToString();
                listtipocombus.Add(t);
            }
        }
        private void SaveVehiculoButton_Click(object sender, RoutedEventArgs e)
        {
            Tipocombus tc = (Tipocombus)TipocomboBox.SelectedValue;
            string guardar = "insert into vehiculo(descripcion,chapa,idtipo_combus)values('" + descripvehtextBox.Text + "','" + chapatextBox.Text + "'," + tc.IdTipoCombus + ")";
            SQLiteCommand cmd = new SQLiteCommand(guardar, ConexionDB.conectar());
            cmd.ExecuteNonQuery();

            Mostrar();
            Limpiar();
            _mainWindow.Cargar();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string borrar = "delete from vehiculo where idvehiculo="+CodigovehtextBox.Text+"";
            SQLiteCommand cmd = new SQLiteCommand(borrar, ConexionDB.conectar());
            cmd.ExecuteNonQuery();
            
            Limpiar();
            Mostrar();
            _mainWindow.Cargar();
        }
    }
}
