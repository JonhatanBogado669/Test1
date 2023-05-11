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
        ObservableCollection<Tipocombus> listtipocombus = new ObservableCollection<Tipocombus>();
        public VehiculoWindow()
        {
            InitializeComponent();
            TipocomboBox.ItemsSource = listtipocombus;
            Conexion.conectar();
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
            string mostrarveh = "select v.idvehiculo as codigo, v.descripcion, v.chapa, t.descripcion as tipo_combustible from vehiculo v inner join tipo_combus t where t.idtipo_combus=v.idtipo_combus order by codigo asc";
            MySqlCommand cmd = new MySqlCommand(mostrarveh, Conexion.conectar());
            VehiculodataGrid.ItemsSource = cmd.ExecuteReader();
        }
        public void Carga()
        {
            string cargar = "select idtipo_combus,descripcion from tipo_combus";
            MySqlCommand cmd = new MySqlCommand(cargar, Conexion.conectar());
            MySqlDataReader r = cmd.ExecuteReader();
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
            MySqlCommand cmd = new MySqlCommand(guardar, Conexion.conectar());
            cmd.ExecuteNonQuery();
            Mostrar();
            Limpiar();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string borrar = "delete from vehiculo where idvehiculo="+CodigovehtextBox.Text+"";
            MySqlCommand cmd = new MySqlCommand(borrar, Conexion.conectar());
            cmd.ExecuteNonQuery();
            Limpiar();
            Mostrar();
        }
    }
}
