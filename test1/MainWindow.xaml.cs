﻿using System;
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
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Collections;
using test1.models;
using test1;

namespace test1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Vehiculo> listvehiculo = new ObservableCollection<Vehiculo>();

        public MainWindow()
        {
            InitializeComponent();
            vehiculocomboBox.ItemsSource = listvehiculo;
            Conexion.conectar();
            Mostrar();
            Carga();
        }
        public void Limpiar()
        {
            codtextBox.Text = "";
            entidadtextBox.Text = "";
            periodotextBox.Text = "";
            vehiculocomboBox.Text = "";
            CItextBox.Text = "";
            nombretextBox.Text = "";
            salidatextBox.Text = "";
            kmsalidatextBox.Text = "";
            destinotextBox.Text = "";
            kmllegadatextBox.Text = "";
            kmrecorridotextBox.Text = "";
            motivotextBox.Text = "";
            ltscargadotextBox.Text = "";
            facturatextBox.Text = "";
            importetextBox.Text = "";


        }
        public void Mostrar()
        {
            string mostrarcombus = "select idplan_combus as código,fecha,ci,nombre,lugar_sal as lugar_salida,km_salida,lugar_dest as lugar_destino,km_llegada,km_recorrido,motivo,lts_carg as litros_cargados, imp_total as importe_total from plan_combus";
            MySqlCommand cmd = new MySqlCommand(mostrarcombus, Conexion.conectar());
            CombustibledataGrid.ItemsSource = cmd.ExecuteReader();
           
        }
        public void Carga()
        {
            string cargar = "select idvehiculo,descripcion, chapa from vehiculo";
            MySqlCommand cmd = new MySqlCommand(cargar, Conexion.conectar());
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Vehiculo v = new Vehiculo();
                v.IdVehiculo = r.GetValue(0).ToString();
                v.Descripcion = r.GetValue(1).ToString();
                v.Chapa = r.GetValue(2).ToString();
                listvehiculo.Add(v);
            }
        }
       
        private void SaveCombus_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Vehiculo v = (Vehiculo)vehiculocomboBox.SelectedValue;
                string guardar = "insert into plan_combus(entidad,periodo,idvehiculo,fecha,ci,nombre,lugar_sal,km_salida,lugar_dest,km_llegada,km_recorrido,motivo,lts_carg,nro_fact,imp_total)values('"+
                entidadtextBox.Text+"','"+periodotextBox.Text+"',"+v.IdVehiculo+",'"+FechaCombus.Text+"','"+CItextBox.Text+"','"+nombretextBox.Text+"','"+salidatextBox.Text+"',"+kmsalidatextBox.Text+",'"+
                destinotextBox.Text+"',"+kmllegadatextBox.Text+","+kmrecorridotextBox.Text+",'"+motivotextBox.Text+"',"+ltscargadotextBox.Text+",'"+facturatextBox.Text+"',"+importetextBox.Text+")";
                MySqlCommand cmd = new MySqlCommand(guardar, Conexion.conectar());
                cmd.ExecuteNonQuery();
                Limpiar();
                Mostrar();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void AgregarVehiculoButton_Click(object sender, RoutedEventArgs e)
        {
            VehiculoWindow v = new VehiculoWindow();
            v.Show();
           
        }

        private void ModifycombusButton_Click(object sender, RoutedEventArgs e)
        {
            Vehiculo v = (Vehiculo)vehiculocomboBox.SelectedValue;
            string modificar = "update plan_combus set entidad='"+entidadtextBox.Text+"',periodo='"+periodotextBox.Text+"', idvehiculo="+v.IdVehiculo+", fecha='"+FechaCombus+"',ci='"+CItextBox.Text+"', nombre='"+
            nombretextBox.Text+"', lugar_sal='"+salidatextBox.Text+"', km_salida="+kmsalidatextBox.Text+", lugar_dest='"+destinotextBox.Text+"', km_llegada="+kmllegadatextBox.Text+", km_recorrido="+kmrecorridotextBox.Text
            +", motivo='"+motivotextBox.Text+"', lts_carg="+ltscargadotextBox.Text+", nro_fact='"+facturatextBox.Text+"', imp_total="+importetextBox.Text+" where idplan_combus="+codtextBox.Text+"";
            MySqlCommand cmd = new MySqlCommand(modificar, Conexion.conectar());
            cmd.ExecuteNonQuery();
            Limpiar();
            Mostrar();
        }

        private void DeletecombusButton_Click(object sender, RoutedEventArgs e)
        {
            string borrar = "delete from plan_combus where idplan_combus="+codtextBox.Text+"";
            MySqlCommand cmd = new MySqlCommand(borrar, Conexion.conectar());
            cmd.ExecuteNonQuery();
            Limpiar();
            Mostrar();
        
        }

        private void SaveResumen_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string guardarserv1040 = "insert into serv1040(cant1040,horaserv,estructural,vehicular,basural,forestal,pastizal,desconocida,premeditada,accidental,findelimpieza,principio,pequena,mediana,grande,emergral,agua,pqsco2,combustible,bombero,tiempototal,ileso,herido,fallecido,rescate,totalkm,nomina)values("+
                cant1040textBox.Text+","+horaserv40textBox.Text+","+estructuraltextBox.Text+","+vehiculartextBox.Text+","+basuraltextBox.Text+","+forestaltextBox.Text+","+pastizaltextBox.Text+","+desconocidastextBox.Text+","+premeditadastextBox.Text+","+accidentalestextBox.Text+","+limpiezatextBox.Text+","+
                principiotextBox.Text+","+pqmagtextBox.Text+","+mdmagtextBox.Text+","+grmagtextBox.Text+","+emergraltextBox.Text+","+aguatextBox.Text+","+pqsco2textBox.Text+","+combustible40textBox.Text+","+bomberostextBox.Text+","+tiempototaltextBox.Text+","+ilesostextBox.Text+","+heridostextBox.Text+","+
                fallecidostextBox.Text+","+rescatestextBox.Text+","+totalkmtextBox.Text+",'"+nomina40textBox.Text+"')";
                MySqlCommand cmd = new MySqlCommand(guardarserv1040, Conexion.conectar());
                cmd.ExecuteNonQuery();
                long idTabla1 = cmd.LastInsertedId;

                string guardarres = "insert into informe(fechaenv,hora,mes,anho,cantcia_est,autor,telefono,lugar,fax,fechacierre,cantserv,idserv1040)values('"+FechaServ.Text+"','"+horatextBox.Text+"','"+MestextBox.Text+"','"+AnhotextBox.Text+"',"+cantciaesttextBox.Text+",'"+autortextBox.Text+"','"+teleftextBox.Text
                +"','"+lugartextBox.Text+"','"+faxtextBox.Text+"','"+FechaCierre.Text+"',"+totalservtextBox.Text+","+idTabla1+")";
                MySqlCommand cmd1 = new MySqlCommand(guardarres, Conexion.conectar());
                cmd1.ExecuteNonQuery();
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
