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
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
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
            Cargar();
        }
        public void Limpiar()
        {

            //uso de combustible
            codtextBox.Text = "";
            periodotextBox.Text = "";
            vehiculocomboBox.Text = ""; 
            FechaCombus.Text = "";
            CItextBox.Text = "0";
            nombretextBox.Text = "";
            salidatextBox.Text = "";
            kmsalidatextBox.Text = "0";
            destinotextBox.Text = "";
            kmllegadatextBox.Text = "0";
            kmrecorridotextBox.Text = "0";
            motivotextBox.Text = "";
            ltscargadotextBox.Text = "0";
            facturatextBox.Text = "";
            importetextBox.Text = "0";
            //resumen de servicios
            horatextBox.Text = "";
            FechaServ.Text = "";
            MestextBox.Text = "";
            AnhotextBox.Text = "";
            autortextBox.Text = "";
            teleftextBox.Text = "";
            cantciaesttextBox.Text = "0";
            lugartextBox.Text = "";
            faxtextBox.Text = "";
            totalservtextBox.Text = "0";
            cant1040textBox.Text = "0";
            horaserv40textBox.Text = "0";
            estructuraltextBox.Text = "0";
            vehiculartextBox.Text = "0";
            basuraltextBox.Text = "0";
            forestaltextBox.Text = "0";
            pastizaltextBox.Text = "0";
            principiotextBox.Text = "0";
            pqmagtextBox.Text = "0";
            mdmagtextBox.Text = "0";
            grmagtextBox.Text = "0";
            emergraltextBox.Text = "0";
            ilesostextBox.Text = "0";
            heridostextBox.Text = "0";
            fallecidostextBox.Text = "0";
            rescatestextBox.Text = "0";
            desconocidastextBox.Text = "0";
            premeditadastextBox.Text = "0";
            accidentalestextBox.Text = "0";
            cortotextBox.Text = "0";
            limpiezatextBox.Text = "0";
            aguatextBox.Text = "0";
            pqsco2textBox.Text = "0";
            combustible40textBox.Text = "0";
            bomberostextBox.Text = "0";
            tiempototaltextBox.Text = "0";
            totalkmtextBox.Text = "0";
            nomina40textBox.Text = "";
            cant1041textBox.Text = "0";
            horaserv41textBox.Text = "0";
            arrollamientotextBox.Text = "0";
            choquetextBox.Text = "0";
            vuelcotextBox.Text = "0";
            caidatextBox.Text = "0";
            aeronavetextBox.Text = "0";
            dañomattextBox.Text = "";
            conheridostextBox.Text = "";
            conatraptextBox.Text = "";
            coninctextBox.Text = "";
            matpeltextBox.Text = "";
            ilesos41textBox.Text = "0";
            heridos41textBox.Text = "0";
            fallecidos41textBox.Text = "0";
            rescates41textBox.Text = "0";
            peatonestextBox.Text = "";
            motostextBox.Text = "";
            vehlivtextBox.Text = "";
            vehpestextBox.Text = "";
            bustextBox.Text = "";
            cintcondtextBox.Text = "";
            cintacomptextBox.Text = "";
            cascondtextBox.Text = "";
            casacomptextBox.Text = "";
            tiempototal41textBox.Text = "0";
            nomina41textBox.Text = "";
            combustible41textBox.Text = "0";
            bomberos41textBox.Text = "0";
            kmrecorrido41textBox.Text = "0";
            cant1043textBox.Text = "0";
            horaserv43textBox.Text = "0";
            rescate43textBox.Text = "0";
            recuperaciontextBox.Text = "0";
            anialitextBox.Text = "0";
            coberturatextBox.Text = "0";
            cursotextBox.Text = "0";
            viviendatextBox.Text = "0";
            profundidadtextBox.Text = "0";
            alturatextBox.Text = "0";
            derrumbetextBox.Text = "0";
            naufragiotextBox.Text = "0";
            bombatextBox.Text = "0";
            suicidiotextBox.Text = "0";
            transportetextBox.Text = "0";
            ilesos43textBox.Text = "0";
            heridos43textBox.Text = "0";
            fallecidos43textBox.Text = "0";
            combustible43textBox.Text = "0";
            nomina43textBox.Text = "";
            FechaCierre.Text = "";
            codrestextBox.Text = "";
        }
        public void Mostrar()
        {

            string mostrarcombus = "select p.idplan_combus as código,p.periodo,v.descripcion as vehiculo,p.fecha,p.ci,p.nombre,p.lugar_sal as lugar_salida,p.km_salida,p.lugar_dest as lugar_destino,p.km_llegada,p.km_recorrido,p.motivo,p.lts_carg as litros_cargados,p.nro_fact as factura, p.imp_total as importe_total from plan_combus p inner join vehiculo v where p.idvehiculo= v.idvehiculo group by código";
            MySqlCommand cmd = new MySqlCommand(mostrarcombus, Conexion.conectar());
            CombustibledataGrid.ItemsSource = cmd.ExecuteReader();

            string mostrarinf = "SELECT i.idinforme AS código,i.fechaenv,i.hora,i.mes,i.anho AS año,i.cantcia_est,i.autor,i.telefono,i.lugar,i.fax,i.fechacierre,i.cantserv,s.cant1040,ss.cant1041,sss.cant1043 FROM informe  i INNER JOIN serv1040 s, serv1041 ss, serv1043 sss WHERE i.idserv1040=s.idserv1040 AND i.idserv1041=ss.idserv1041 AND i.idserv1043=sss.idserv1043";
            MySqlCommand cmd1 = new MySqlCommand(mostrarinf, Conexion.conectar());
            InfdataGrid.ItemsSource = cmd1.ExecuteReader();
        }
        public void Cargar()
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
                string guardar = "insert into plan_combus(periodo,idvehiculo,fecha,ci,nombre,lugar_sal,km_salida,lugar_dest,km_llegada,km_recorrido,motivo,lts_carg,nro_fact,imp_total)values('"+
                periodotextBox.Text+"',"+v.IdVehiculo+",'"+FechaCombus.Text+"','"+CItextBox.Text+"','"+nombretextBox.Text+"','"+salidatextBox.Text+"',"+kmsalidatextBox.Text+",'"+
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
            string modificar = "update plan_combus set periodo='"+periodotextBox.Text+"', idvehiculo="+v.IdVehiculo+", fecha='"+FechaCombus+"',ci='"+CItextBox.Text+"', nombre='"+
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

        ////////////////////////////////////////////////////////////////////////Resumen de Servicios///////////////////////////////////////////////////////////////////////////////

        private void SaveResumen_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //serv1040
                //if (cant1040textBox.Text != null)
                //{
                    string guardarserv1040 = "insert into serv1040(cant1040,horaserv,estructural,vehicular,basural,forestal,pastizal,desconocida,premeditada,accidental,findelimpieza,principio,pequena,mediana,grande,emergral,agua,pqsco2,combustible,bombero,tiempototal,ileso,herido,fallecido,rescate,totalkm,nomina)values(" +
                    cant1040textBox.Text + "," + horaserv40textBox.Text + "," + estructuraltextBox.Text + "," + vehiculartextBox.Text + "," + basuraltextBox.Text + "," + forestaltextBox.Text + "," + pastizaltextBox.Text + "," + desconocidastextBox.Text + "," + premeditadastextBox.Text + "," + accidentalestextBox.Text + "," +
                    limpiezatextBox.Text + "," + principiotextBox.Text + "," + pqmagtextBox.Text + "," + mdmagtextBox.Text + "," + grmagtextBox.Text + "," + emergraltextBox.Text + "," + aguatextBox.Text + "," + pqsco2textBox.Text + "," + combustible40textBox.Text + "," + bomberostextBox.Text + "," + tiempototaltextBox.Text + "," +
                    ilesostextBox.Text + "," + heridostextBox.Text + "," + fallecidostextBox.Text + "," + rescatestextBox.Text + "," + totalkmtextBox.Text + ",'" + nomina40textBox.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(guardarserv1040, Conexion.conectar());
                    cmd.ExecuteNonQuery();

                   
                //}
                //serv1041
                //if (cant1041textBox.Text != null)
                /*{
                    string guardarserv1041 = "insert into serv1041(cant1041,horaserv,arrollamiento,choque,vuelco,caida,aeronave,peaton,moto,vehliviano,vehpesado,bus,danomat,conherido,conatrap,coninc,matpel,cintcond,cintacomp,cascocond,cascoacomp,ileso,herido,fallecido,rescate,combustible,bombero,kmrecorrido,tiempototal,nomina)values(" +
                    cant1041textBox.Text + "," + horaserv41textBox.Text + "," + arrollamientotextBox.Text + "," + choquetextBox.Text + "," + vuelcotextBox.Text + "," + caidatextBox.Text + "," + aeronavetextBox.Text + ",'" + peatonestextBox.Text + "','" + motostextBox.Text + "','" + vehlivtextBox.Text + "','" + vehpestextBox.Text + "','" +
                    bustextBox.Text + "','" + dañomattextBox.Text + "','" + conheridostextBox.Text + "','" + conatraptextBox.Text + "','" + coninctextBox.Text + "','" + matpeltextBox.Text + "','" + cintcondtextBox.Text + "','" + cintacomptextBox.Text + "','" + cascondtextBox.Text + "','" + casacomptextBox.Text + "'," + ilesos41textBox.Text + "," +
                    heridos41textBox.Text + "," + fallecidos41textBox.Text + "," + rescates41textBox.Text + "," + combustible41textBox.Text + "," + bomberos41textBox.Text + "," + kmrecorrido41textBox.Text + "," + tiempototal41textBox.Text + ",'" + nomina41textBox.Text + "')";
                    MySqlCommand cmd1 = new MySqlCommand(guardarserv1041, Conexion.conectar());
                    cmd1.ExecuteNonQuery();
                    long idTabla2 = cmd1.LastInsertedId;
                //}
                //serv1043
                //if (cant1043textBox.Text != null)
                //{
                    string guardarserv1043 = "insert into serv1043(cant1043,horaserv,rescate,recuperacion,aniali,cobertura,curso,vivienda,profundidad,altura,derrumbe,naufragio,bomba,suicidio,ileso,herido,fallecido,combustible,nomina)values(" + cant1043textBox.Text + "," + horaserv43textBox.Text + "," + rescate43textBox.Text + "," + recuperaciontextBox.Text + "," +
                    anialitextBox.Text + "," + coberturatextBox.Text + "," + cursotextBox.Text + "," + viviendatextBox.Text + "," + profundidadtextBox.Text + "," + alturatextBox.Text + "," + derrumbetextBox.Text + "," + naufragiotextBox.Text + "," + bombatextBox.Text + "," + suicidiotextBox.Text + "," + ilesos43textBox.Text + "," + heridos43textBox.Text + "," + fallecidos43textBox.Text + "," +
                    combustible43textBox.Text + ",'" + nomina43textBox.Text + "')";
                    MySqlCommand cmd2 = new MySqlCommand(guardarserv1043, Conexion.conectar());
                    cmd2.ExecuteNonQuery();
                    long idTabla3 = cmd2.LastInsertedId;
                //}*/
                //informe
                if (guardarserv1040 != null)
                {
                    long idTabla1 = cmd.LastInsertedId;
                    string guardarres = "insert into informe(fechaenv,hora,mes,anho,cantcia_est,autor,telefono,lugar,fax,fechacierre,cantserv,idserv1040)values('" + FechaServ.Text + "','" + horatextBox.Text + "','" + MestextBox.Text + "','" + AnhotextBox.Text + "'," + cantciaesttextBox.Text + ",'" + autortextBox.Text + "','" + teleftextBox.Text
                    + "','" + lugartextBox.Text + "','" + faxtextBox.Text + "','" + FechaCierre.Text + "'," + totalservtextBox.Text + "," + idTabla1 + ")";
                    MySqlCommand cmd3 = new MySqlCommand(guardarres, Conexion.conectar());
                    cmd3.ExecuteNonQuery();
                    Limpiar();
                    Mostrar();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ModifyresButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //serv1040
                string id1040 = "select i.idserv1040 from informe i where i.idinforme=" + codrestextBox.Text + "";
                MySqlCommand cm = new MySqlCommand(id1040, Conexion.conectar());
                using (MySqlDataReader reader = cm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id40 = reader.GetInt32(0);
                        string mod = "update serv1040 set cant1040=" + cant1040textBox.Text + ", horaserv=" + horaserv40textBox.Text + ", estructural=" + estructuraltextBox.Text + ", vehicular=" + 
                        vehiculartextBox.Text + ", basural=" + basuraltextBox.Text + ", forestal=" + forestaltextBox.Text + ", pastizal=" + pastizaltextBox.Text + ", desconocida=" +
                        desconocidastextBox.Text + ", premeditada=" + premeditadastextBox.Text + ", accidental=" + accidentalestextBox.Text + ", findelimpieza=" + limpiezatextBox.Text + ", principio=" +
                        principiotextBox.Text + ", pequena=" + pqmagtextBox.Text + ", mediana=" + mdmagtextBox.Text + ", grande=" + grmagtextBox.Text + ", emergral=" + emergraltextBox.Text + ", agua=" +
                        aguatextBox.Text + ", pqsco2=" + pqsco2textBox.Text + ", combustible=" + combustible40textBox.Text + ", bombero=" + bomberostextBox.Text + ", tiempototal=" +
                        tiempototaltextBox.Text + ", ileso=" + ilesostextBox.Text + ", herido=" + heridostextBox.Text + ", fallecido=" + fallecidostextBox.Text + ", rescate=" +
                        rescatestextBox.Text + ", totalkm=" + totalkmtextBox.Text + ", nomina='" + nomina40textBox.Text + "' where idserv1040 = " + id40 + "";
                        MySqlCommand cmd = new MySqlCommand(mod, Conexion.conectar());
                        cmd.ExecuteNonQuery();
                    }
                }

                //serv1041
                string id1041 = "select i.idserv1041 from informe i where i.idinforme=" + codrestextBox.Text + "";
                MySqlCommand cm1 = new MySqlCommand(id1041, Conexion.conectar());
                using(MySqlDataReader reader = cm1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id41 = reader.GetInt32(0);
                        string mod = "update serv1041 set cant1041=" + cant1041textBox.Text + ", horaserv=" + horaserv41textBox.Text + ", arrollamiento=" + arrollamientotextBox.Text + ", choque=" +
                        choquetextBox.Text + ", vuelco=" + vuelcotextBox.Text + ", caida=" + caidatextBox.Text + ", aeronave=" + aeronavetextBox.Text + ", peaton='" + peatonestextBox.Text + "', moto='" +
                        motostextBox.Text + "', vehliviano='" + vehlivtextBox.Text + "', vehpesado='" + vehpestextBox.Text + "', bus='" + bustextBox.Text + "', danomat='" + dañomattextBox.Text + "', conherido='" +
                        conheridostextBox.Text + "', conatrap='" + conatraptextBox.Text + "', coninc='" + coninctextBox.Text + "', matpel='" + matpeltextBox.Text + "', cintcond='" + cintcondtextBox.Text + "', cintacomp='" +
                        cintacomptextBox.Text + "', cascocond='" + cascondtextBox.Text + "', cascoacomp='" + casacomptextBox.Text + "', ileso=" + ilesos41textBox.Text + ", herido=" + heridos41textBox.Text + ", fallecido=" +
                        fallecidos41textBox.Text + ", rescate=" + rescates41textBox.Text + ", combustible=" + combustible41textBox.Text + ", bombero=" + bomberos41textBox.Text + ", kmrecorrido=" +
                        kmrecorrido41textBox.Text + ", tiempototal=" + tiempototal41textBox.Text + ", nomina='" + nomina41textBox.Text + "' where idserv1041=" + id41 + "";
                        MySqlCommand cmd = new MySqlCommand(mod, Conexion.conectar());
                        cmd.ExecuteNonQuery();
                    }
                }

                //serv1043
                string id1043 = "select i.idserv1043 from informe i where i.idinforme=" + codrestextBox.Text + "";
                MySqlCommand cm2 = new MySqlCommand(id1043, Conexion.conectar());
                using (MySqlDataReader reader = cm2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id43 = reader.GetInt32(0);
                        string mod = "update serv1043 set cant1043=" + cant1043textBox.Text + ", horaserv=" + horaserv43textBox.Text + ", rescate=" + rescate43textBox.Text + ", recuperacion=" + 
                        recuperaciontextBox.Text + ", aniali=" + anialitextBox.Text + ", cobertura=" + coberturatextBox.Text + ", curso=" + cursotextBox.Text + ", vivienda=" + viviendatextBox.Text + ", profundidad=" +
                        profundidadtextBox.Text + ", altura=" + alturatextBox.Text + ", derrumbe=" + derrumbetextBox.Text  + ", naufragio=" + naufragiotextBox.Text + ", bomba=" + bombatextBox.Text + ", suicidio=" + 
                        suicidiotextBox.Text + ", ileso=" + ilesos43textBox.Text + ", herido=" + heridos43textBox.Text + ", fallecido=" + fallecidos43textBox.Text + ", combustible=" + combustible43textBox.Text + ", nomina='" +
                        nomina43textBox.Text + "' where idserv1043="+id43+"";
                        MySqlCommand cmd = new MySqlCommand(mod, Conexion.conectar());
                        cmd.ExecuteNonQuery();
                    }
                }
                
                //informe
                string mod1 = "update informe set fechaenv='" + FechaServ.Text + "', hora='" + horatextBox.Text + "', mes='" + MestextBox.Text + "', anho=" + AnhotextBox.Text + ", cantcia_est=" + cantciaesttextBox.Text + ", autor='" +
                autortextBox.Text + "', telefono='" + teleftextBox.Text + "', lugar='" + lugartextBox.Text + "', fax='" + faxtextBox.Text + "', fechacierre='" + FechaCierre.Text + "', cantserv=" + totalservtextBox.Text + " where idinforme=" + 
                codrestextBox.Text + "";
                MySqlCommand cmd1 = new MySqlCommand(mod1, Conexion.conectar());
                cmd1.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Limpiar();
            Mostrar();
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

        private void InfdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InfdataGrid.SelectedItem != null)
            {
                // Obtener la fila seleccionada
                dynamic selectedRow = InfdataGrid.SelectedItem;

                // Obtener los datos de las columnas
                int idinforme = Convert.ToInt32(selectedRow["código"]);
                string fechaenv = selectedRow["fechaenv"].ToString();
                string hora = selectedRow["hora"].ToString();
                string mes = selectedRow["mes"].ToString();
                string anho = selectedRow["año"].ToString();
                int cantcia_est = Convert.ToInt32(selectedRow["cantcia_est"]);
                string autor = selectedRow["autor"].ToString();
                string telefono = selectedRow["telefono"].ToString();
                string lugar = selectedRow["lugar"].ToString();
                string fax = selectedRow["fax"].ToString();
                string fechacierre = selectedRow["fechacierre"].ToString();
                int cantserv = Convert.ToInt32(selectedRow["cantserv"]);
                //int cant1040 = Convert.ToInt32(selectedRow["cant1040"]);
                //int cant1041 = Convert.ToInt32(selectedRow["cant1041"]);
                //int cant1043 = Convert.ToInt32(selectedRow["cant1043"]);
                // Llenar los TextBox correspondientes con los datos obtenidos
                codrestextBox.Text = idinforme.ToString();
                FechaServ.Text = fechaenv;
                horatextBox.Text = hora;
                MestextBox.Text = mes;
                AnhotextBox.Text = anho;
                cantciaesttextBox.Text = cantcia_est.ToString();
                autortextBox.Text = autor;
                teleftextBox.Text = telefono;
                lugartextBox.Text = lugar;
                faxtextBox.Text = fax;
                FechaCierre.Text = fechacierre;
                totalservtextBox.Text = cantserv.ToString();
                //cant1040textBox.Text = cant1040.ToString();
                //cant1041textBox.Text = cant1041.ToString();
                //cant1043textBox.Text = cant1043.ToString();
            }
        }

        private void CombusdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CombustibledataGrid.SelectedItem != null)
            {
                dynamic selectedRow = CombustibledataGrid.SelectedItem;

                int id = Convert.ToInt32(selectedRow["código"]);
                string periodo = selectedRow["periodo"].ToString();
                string fecha = selectedRow["fecha"].ToString();
                string ci = selectedRow["ci"].ToString();
                string nombre = selectedRow["nombre"].ToString();
                string lugarsal = selectedRow["lugar_salida"].ToString();
                int kmsalida = Convert.ToInt32(selectedRow["km_salida"]);
                string lugardes = selectedRow["lugar_destino"].ToString();
                int kmllegada = Convert.ToInt32(selectedRow["km_llegada"]);
                int kmrecorrido = Convert.ToInt32(selectedRow["km_recorrido"]);
                string motivo = selectedRow["motivo"].ToString();
                int ltscarg = Convert.ToInt32(selectedRow["litros_cargados"]);
                string factura = selectedRow["factura"].ToString();
                int imptotal = Convert.ToInt32(selectedRow["importe_total"]);
                

                codtextBox.Text = id.ToString();
                periodotextBox.Text = periodo;
                FechaCombus.Text = fecha;
                CItextBox.Text = ci;
                nombretextBox.Text = nombre;
                salidatextBox.Text = lugarsal;
                kmsalidatextBox.Text = kmsalida.ToString();
                destinotextBox.Text = lugardes;
                kmllegadatextBox.Text = kmllegada.ToString();
                kmrecorridotextBox.Text = kmrecorrido.ToString();
                motivotextBox.Text = motivo;
                ltscargadotextBox.Text = ltscarg.ToString();
                facturatextBox.Text = factura;
                importetextBox.Text = imptotal.ToString();
            }
        }
        /////////////////////////////////Login/////////////////////////////////////
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernametextBox.Text;
            string password = PasswordtextBox.Password;

            if (string.IsNullOrEmpty(UsernametextBox.Text) || string.IsNullOrEmpty(PasswordtextBox.Password))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario y contraseña.", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Login(UsernametextBox.Text, PasswordtextBox.Password))
            {
                // Inicio de sesión exitoso, realizar acciones según el rol del usuario
                string role = GetUserRole(UsernametextBox.Text);
                switch (role)
                {
                    case "Admin":
                        // Lógica para el rol de administrador
                        UsernametextBox.Text = null;
                        PasswordtextBox.Password = null;
                        LoginGrid.Visibility = Visibility.Collapsed;
                        MessageBox.Show("¡Inicio de sesión exitoso como administrador!", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case "Usuario":
                        // Lógica para el rol de usuario normal
                        MessageBox.Show("¡Inicio de sesión exitoso como usuario!", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        MessageBox.Show("El usuario no tiene un rol válido.", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool Login(string username, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);
                Conexion.conectar();

                string cadena = "SELECT COUNT(*) FROM users WHERE username = '"+UsernametextBox.Text+"' AND password = '"+PasswordtextBox.Password+"'";
                MySqlCommand cmd = new MySqlCommand(cadena, Conexion.conectar());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private string GetUserRole(string username)
        {
            try
            {
                Conexion.conectar();

                string cadena = "SELECT role FROM users WHERE username = '"+UsernametextBox.Text+"'";
                MySqlCommand cmd = new MySqlCommand(cadena, Conexion.conectar());
                string role = cmd.ExecuteScalar()?.ToString();
                return role;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el rol del usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private void LogOutButton_Clikc(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =  MessageBox.Show("Quieres cerrar sesión?", "Cierre de sesión", MessageBoxButton.YesNo , MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                LoginGrid.Visibility = Visibility.Visible;
            }
            
        }
        /////////////////////////Reseteo de Contraseña///////////////////////////
        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernametextBox.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Por favor, ingrese su nombre de usuario.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string email = GetEmailByUsername(username);
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("No se encontró ninguna dirección de correo electrónico asociada a ese nombre de usuario.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (username != null && email != null)
            {
                LoginGrid.Visibility = Visibility.Collapsed;
                tabControl.Visibility = Visibility.Collapsed;
                Correoview();
            }
        }
        private string GetEmailByUsername(string username)
        {
            try
            {
               
                string query = "SELECT correo FROM users WHERE username = '"+username+"'";
                MySqlCommand cmd = new MySqlCommand(query, Conexion.conectar());
                string email = cmd.ExecuteScalar()?.ToString();
                return email;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la dirección de correo electrónico: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void Correoview()
        {
            string username = UsernametextBox.Text;
            string email = GetEmailByUsername(username);
            labelcorreo.Content = email;
        }
        private void EnviarButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernametextBox.Text;
            string email = GetEmailByUsername(username);
            string resetCode = GenerateResetCode();
            if (SendResetCodeByEmail(email, resetCode))
            {
                // Aquí puedes guardar el resetCode en una base de datos o en memoria para su posterior validación
                string guardarcode = "insert into password_reset(username,reset_code)value('" + username + "'," + resetCode + ")";
                MySqlCommand cmd = new MySqlCommand(guardarcode, Conexion.conectar());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha enviado un código de restablecimiento a su dirección de correo electrónico registrada.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                verifyGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("No se pudo enviar el código de restablecimiento. Por favor, intente nuevamente más tarde.", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
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
                string username = UsernametextBox.Text;
                string senderEmail = GetEmailByUsername(username);
                string senderPassword = senderPasswordtextBox.Password;
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;

                // Configurar la información del correo electrónico
                MailMessage mailMessage = new MailMessage(senderEmail, email);
                mailMessage.Subject = "Código de restablecimiento de contraseña";
                mailMessage.Body = "Su código de restablecimiento de contraseña es: " + resetCode;

                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                // Enviar el correo electrónico
                smtpClient.Send(mailMessage);

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
                string username = UsernametextBox.Text;
                string select = "SELECT COUNT(*) FROM password_reset WHERE username = '" + username + "' AND reset_code = " + resetcodetextBox.Text + "";
                MySqlCommand cmd = new MySqlCommand(select, Conexion.conectar());

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
                string username = UsernametextBox.Text;
                string update = "UPDATE users SET password = '" + updatetextBox.Password + "' WHERE username = '" + username + "'";
                MySqlCommand cmd1 = new MySqlCommand(update, Conexion.conectar());
                cmd1.ExecuteNonQuery();

                // Eliminar el registro de reset_code de la tabla password_reset
                string delete = "DELETE FROM password_reset WHERE username = '" + username + "'";
                MySqlCommand cmd2 = new MySqlCommand(delete, Conexion.conectar());
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Contraseña actualizada!", "Restablecimiento de contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
