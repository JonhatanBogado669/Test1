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

            //uso de combustible
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
            //resumen de servicios
            horatextBox.Text = "";
            FechaServ.Text = "";
            MestextBox.Text = "";
            AnhotextBox.Text = "";
            autortextBox.Text = "";
            teleftextBox.Text = "";
            cantciaesttextBox.Text = "";
            lugartextBox.Text = "";
            faxtextBox.Text = "";
            totalservtextBox.Text = "";
            cant1040textBox.Text = "";
            horaserv40textBox.Text = "";
            estructuraltextBox.Text = "";
            vehiculartextBox.Text = "";
            basuraltextBox.Text = "";
            forestaltextBox.Text = "";
            pastizaltextBox.Text = "";
            principiotextBox.Text = "";
            pqmagtextBox.Text = "";
            mdmagtextBox.Text = "";
            grmagtextBox.Text = "";
            emergraltextBox.Text = "";
            ilesostextBox.Text = "";
            heridostextBox.Text = "";
            fallecidostextBox.Text = "";
            rescatestextBox.Text = "";
            desconocidastextBox.Text = "";
            premeditadastextBox.Text = "";
            accidentalestextBox.Text = "";
            cortotextBox.Text = "";
            limpiezatextBox.Text = "";
            aguatextBox.Text = "";
            pqsco2textBox.Text = "";
            combustible40textBox.Text = "";
            bomberostextBox.Text = "";
            tiempototaltextBox.Text = "";
            totalkmtextBox.Text = "";
            nomina40textBox.Text = "";
            cant1041textBox.Text = "";
            horaserv41textBox.Text = "";
            arrollamientotextBox.Text = "";
            choquetextBox.Text = "";
            vuelcotextBox.Text = "";
            caidatextBox.Text = "";
            aeronavetextBox.Text = "";
            dañomattextBox.Text = "";
            conheridostextBox.Text = "";
            conatraptextBox.Text = "";
            coninctextBox.Text = "";
            matpeltextBox.Text = "";
            ilesos41textBox.Text = "";
            heridos41textBox.Text = "";
            fallecidos41textBox.Text = "";
            rescates41textBox.Text = "";
            peatonestextBox.Text = "";
            motostextBox.Text = "";
            vehlivtextBox.Text = "";
            vehpestextBox.Text = "";
            bustextBox.Text = "";
            cintcondtextBox.Text = "";
            cintacomptextBox.Text = "";
            cascondtextBox.Text = "";
            casacomptextBox.Text = "";
            tiempototal41textBox.Text = "";
            nomina41textBox.Text = "";
            combustible41textBox.Text = "";
            bomberos41textBox.Text = "";
            kmrecorrido41textBox.Text = "";
            cant1043textBox.Text = "";
            horaserv43textBox.Text = "";
            rescate43textBox.Text = "";
            recuperaciontextBox.Text = "";
            anialitextBox.Text = "";
            coberturatextBox.Text = "";
            cursotextBox.Text = "";
            viviendatextBox.Text = "";
            profundidadtextBox.Text = "";
            alturatextBox.Text = "";
            derrumbetextBox.Text = "";
            naufragiotextBox.Text = "";
            bombatextBox.Text = "";
            suicidiotextBox.Text = "";
            transportetextBox.Text = "";
            ilesos43textBox.Text = "";
            heridos43textBox.Text = "";
            fallecidos43textBox.Text = "";
            combustible43textBox.Text = "";
            nomina43textBox.Text = "";
            FechaCierre.Text = "";
            codrestextBox.Text = "";


        }
        public void Mostrar()
        {

            string mostrarcombus = "select idplan_combus as código,fecha,ci,nombre,lugar_sal as lugar_salida,km_salida,lugar_dest as lugar_destino,km_llegada,km_recorrido,motivo,lts_carg as litros_cargados, imp_total as importe_total from plan_combus";
            MySqlCommand cmd = new MySqlCommand(mostrarcombus, Conexion.conectar());
            CombustibledataGrid.ItemsSource = cmd.ExecuteReader();

            string mostrarinf = "select*from informe";
            MySqlCommand cmd1 = new MySqlCommand(mostrarinf, Conexion.conectar());
            InfdataGrid.ItemsSource = cmd1.ExecuteReader();
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
                //serv1040
                string guardarserv1040 = "insert into serv1040(cant1040,horaserv,estructural,vehicular,basural,forestal,pastizal,desconocida,premeditada,accidental,findelimpieza,principio,pequena,mediana,grande,emergral,agua,pqsco2,combustible,bombero,tiempototal,ileso,herido,fallecido,rescate,totalkm,nomina)values(" +
                cant1040textBox.Text + "," + horaserv40textBox.Text + "," + estructuraltextBox.Text + "," + vehiculartextBox.Text + "," + basuraltextBox.Text + "," + forestaltextBox.Text + "," + pastizaltextBox.Text + "," + desconocidastextBox.Text + "," + premeditadastextBox.Text + "," + accidentalestextBox.Text + "," + limpiezatextBox.Text + "," +
                principiotextBox.Text + "," + pqmagtextBox.Text + "," + mdmagtextBox.Text + "," + grmagtextBox.Text + "," + emergraltextBox.Text + "," + aguatextBox.Text + "," + pqsco2textBox.Text + "," + combustible40textBox.Text + "," + bomberostextBox.Text + "," + tiempototaltextBox.Text + "," + ilesostextBox.Text + "," + heridostextBox.Text + "," +
                fallecidostextBox.Text + "," + rescatestextBox.Text + "," + totalkmtextBox.Text + ",'" + nomina40textBox.Text + "')";
                MySqlCommand cmd = new MySqlCommand(guardarserv1040, Conexion.conectar());
                cmd.ExecuteNonQuery();
                long idTabla1 = cmd.LastInsertedId;
                //serv1041
                string guardarserv1041 = "insert into serv1041(cant1041,horaserv,arrollamiento,choque,vuelco,caida,aeronave,peaton,moto,vehliviano,vehpesado,bus,danomat,conherido,conatrap,coninc,matpel,cintcond,cintacomp,cascocond,cascoacomp,ileso,herido,fallecido,rescate,combustible,bombero,kmrecorrido,tiempototal,nomina)values(" +
                cant1041textBox.Text + "," + horaserv41textBox.Text + "," + arrollamientotextBox.Text + "," + choquetextBox.Text + "," + vuelcotextBox.Text + "," + caidatextBox.Text + "," + aeronavetextBox.Text + ",'" + peatonestextBox.Text + "','" + motostextBox.Text + "','" + vehlivtextBox.Text + "','" + vehpestextBox.Text + "','" + bustextBox.Text + "','" + dañomattextBox.Text
                + "','" + conheridostextBox.Text + "','" + conatraptextBox.Text + "','" + coninctextBox.Text + "','" + matpeltextBox.Text + "','" + cintcondtextBox.Text + "','" + cintacomptextBox.Text + "','" + cascondtextBox.Text + "','" + casacomptextBox.Text + "'," + ilesos41textBox.Text + "," + heridos41textBox.Text + "," + fallecidos41textBox.Text + "," + rescates41textBox.Text
                + "," + combustible41textBox.Text + "," + bomberos41textBox.Text + "," + kmrecorrido41textBox.Text + "," + tiempototal41textBox.Text + ",'" + nomina41textBox.Text + "')";
                MySqlCommand cmd1 = new MySqlCommand(guardarserv1041, Conexion.conectar());
                cmd1.ExecuteNonQuery();
                long idTabla2 = cmd1.LastInsertedId;
                //serv1043
                string guardarserv1043 = "insert into serv1043(cant1043,horaserv,rescate,recuperacion,aniali,cobertura,curso,vivienda,profundidad,altura,derrumbe,naufragio,bomba,suicidio,ileso,herido,fallecido,combustible,nomina)values(" + cant1043textBox.Text + "," + horaserv43textBox.Text + "," + rescate43textBox.Text + "," + recuperaciontextBox.Text + "," +
                anialitextBox.Text + "," + coberturatextBox.Text + "," + cursotextBox.Text + "," + viviendatextBox.Text + "," + profundidadtextBox.Text + "," + alturatextBox.Text + "," + derrumbetextBox.Text + "," + naufragiotextBox.Text + "," + bombatextBox.Text + "," + suicidiotextBox.Text + "," + ilesos43textBox.Text + "," + heridos43textBox.Text + "," + fallecidos43textBox.Text + "," +
                combustible43textBox.Text + ",'" + nomina43textBox.Text + "')";
                MySqlCommand cmd2 = new MySqlCommand(guardarserv1043, Conexion.conectar());
                cmd2.ExecuteNonQuery();
                long idTabla3 = cmd2.LastInsertedId;
                //informe
                string guardarres = "insert into informe(fechaenv,hora,mes,anho,cantcia_est,autor,telefono,lugar,fax,fechacierre,cantserv,idserv1040,idserv1041,idserv1043)values('" + FechaServ.Text + "','" + horatextBox.Text + "','" + MestextBox.Text + "','" + AnhotextBox.Text + "'," + cantciaesttextBox.Text + ",'" + autortextBox.Text + "','" + teleftextBox.Text
                + "','" + lugartextBox.Text + "','" + faxtextBox.Text + "','" + FechaCierre.Text + "'," + totalservtextBox.Text + "," + idTabla1 + "," + idTabla2 + "," + idTabla3 + ")";
                MySqlCommand cmd3 = new MySqlCommand(guardarres, Conexion.conectar());
                cmd3.ExecuteNonQuery();
                Limpiar();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteresButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string borrarres = "delete from informe where idinforme=" + codrestextBox.Text + "";
                MySqlCommand cmd = new MySqlCommand(borrarres, Conexion.conectar());
                cmd.ExecuteNonQuery();
                Limpiar();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serv40ButtonClick(object sender, RoutedEventArgs e)
        {
            tabla1.Visibility = Visibility.Visible;
            tabla2.Visibility = Visibility.Collapsed;
            tabla3.Visibility = Visibility.Collapsed;
        }

        private void serv41ButtonClick(object sender, RoutedEventArgs e)
        {
            tabla1.Visibility = Visibility.Collapsed;
            tabla2.Visibility = Visibility.Visible;
            tabla3.Visibility = Visibility.Collapsed;
        }

        private void serv43ButtonClick(object sender, RoutedEventArgs e)
        {
            tabla1.Visibility = Visibility.Collapsed;
            tabla2.Visibility = Visibility.Collapsed;
            tabla3.Visibility = Visibility.Visible;
        }
    }
}
