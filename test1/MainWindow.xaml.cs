using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Data.SQLite;
//using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Win32;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LiveCharts;
using LiveCharts.Wpf;
//using Firebase.Database;
//using Firebase.Database.Query;
//using Firebase.Auth;
using MaterialDesignThemes.Wpf;
using MaterialDesign.Colors;

using System.Collections.ObjectModel;
using System.Collections;
using test1.models;
using test1;
using System.Windows.Controls.Primitives;


namespace test1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Vehiculo> listvehiculo = new ObservableCollection<Vehiculo>();
        ObservableCollection<Mes> listmes = new ObservableCollection<Mes>();
        //private Logger logger;
        string username = UserSession.Username;
        //private FirebaseClient firebaseClient;
        // public string Username { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            // Username = username;
            
            
            vehiculocomboBox.ItemsSource = listvehiculo;
            MescomboBox.ItemsSource = listmes;
            ConexionDB.conectar();
            //logger = new Logger();
            Mostrar();
            Cargar();
            //Auditoria();
        }
        public void Auditoria()
        {
            try
            {
                if (button.ClickMode==ClickMode.Release)
                {
                    string name = username;
                    string accion = "Guardado de resumen";
                    string horafecha = DateTime.Now.ToString("o");
                    string iduser = "select id from users where username='" + name + "' ";
                    SQLiteCommand cm = new SQLiteCommand(iduser, ConexionDB.conectar());
                    object id =cm.ExecuteScalar();
                    Convert.ToInt32(id);
                    string registrar = "insert into auditoria(idusuario,acceso,accion)values(" + id + ",'" + horafecha + "','" + accion + "')";
                    SQLiteCommand cmd = new SQLiteCommand(registrar, ConexionDB.conectar());
                    cmd.ExecuteNonQuery();
                    return;
                }  
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            public void LimpiarCombus()
        {
            //uso de combustible
            codtextBox.Text = "";
            periodotextBox.Text = "";
            vehiculocomboBox.Text = "";
           
        }
        public void Limpiar()
        {
            //uso de combustible
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
            ///registro usuarios///
            UsuariotextBox.Text = "";
            UserpasstextBox.Password = "";
            RoltextBox.Text = "";
            UsercitextBox.Text = "";
            UsercorreotextBox.Text = "";
            UserteleftextBox.Text = "";
        }
        public void Mostrar()
        {
            try
            {
                string mostrarcombus = "select p.idplan_combus as código,p.periodo,v.descripcion as vehiculo,p.fecha,p.ci,p.nombre,p.lugar_sal as lugar_salida,p.km_salida,p.lugar_dest as lugar_destino,p.km_llegada,p.km_recorrido,p.motivo,p.lts_carg as litros_cargados,p.nro_fact as factura, p.imp_total as importe_total from plan_combus p inner join vehiculo v where p.idvehiculo= v.idvehiculo group by código";
                SQLiteCommand cmd = new SQLiteCommand(mostrarcombus, ConexionDB.conectar());
                CombustibledataGrid.ItemsSource = cmd.ExecuteReader();

                string mostrarinf = "SELECT i.idinforme AS código,i.fechaenv,i.hora,m.descripcion as mes,i.anho AS año,i.cantcia_est,i.autor,i.telefono,i.lugar,i.fax,i.fechacierre,i.cantserv,s.cant1040,ss.cant1041,sss.cant1043 FROM informe  i INNER JOIN mes m, serv1040 s, serv1041 ss, serv1043 sss WHERE i.mes=m.idmes AND i.idserv1040=s.idserv1040 AND i.idserv1041=ss.idserv1041 AND i.idserv1043=sss.idserv1043";
                //string mostrarinf = "select * from informe";
                SQLiteCommand cmd1 = new SQLiteCommand(mostrarinf, ConexionDB.conectar());
                InfdataGrid.ItemsSource = cmd1.ExecuteReader();

                string mostrarusers = "SELECT u.id as codigo, u.username as usuario,u.role as rol,u.CI,u.correo,u.phone as telef FROM users u";
                SQLiteCommand cmd2 = new SQLiteCommand(mostrarusers, ConexionDB.conectar());
                UserdataGrid.ItemsSource = cmd2.ExecuteReader();

                string mostraraudi = "SELECT a.id as codigo, u.username as usuario,u.role as rol, a.acceso,a.accion FROM auditoria a inner join users u where u.id=a.idusuario";
                SQLiteCommand cmd3 = new SQLiteCommand(mostraraudi, ConexionDB.conectar());
                AudidataGrid.ItemsSource = cmd3.ExecuteReader();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Cargar()
        {
            listvehiculo.Clear();
            listmes.Clear();
            string cargar = "select v.idvehiculo,v.descripcion, v.chapa, t.descripcion from vehiculo v, tipo_combus t where t.idtipo_combus=v.idtipo_combus";
            SQLiteCommand cmd = new SQLiteCommand(cargar, ConexionDB.conectar());
            SQLiteDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Vehiculo v = new Vehiculo();
                v.IdVehiculo = r.GetValue(0).ToString();
                v.Descripcion = r.GetValue(1).ToString();
                v.Chapa = r.GetValue(2).ToString();
                v.IdTipoCombus = r.GetValue(3).ToString();
                
                listvehiculo.Add(v);
            }
            string mes = "select idmes, descripcion from mes";
            SQLiteCommand cmd1 = new SQLiteCommand(mes, ConexionDB.conectar());
            SQLiteDataReader r1 = cmd1.ExecuteReader();
            while (r1.Read())
            {
                Mes m = new Mes();
                m.IdMes = r1.GetValue(0).ToString();
                m.Descripcion = r1.GetValue(1).ToString();
                listmes.Add(m);
            }
        }
        private void LimpiarCombusButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCombus();
        }
        /*private async Task<string> LoginWithPredefinedCredentials()
        {
            string predefinedEmail = "jonhatanbogado@gmail.com";
            string predefinedPassword = "";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBmUEbcJgYBDy-lbg7qRuXMNS7xINQhp0c"));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(predefinedEmail, predefinedPassword);
                return auth.FirebaseToken;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión con las credenciales predefinidas: " + ex.Message);
                throw;
            }
        }*/

        private void SaveCombus_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = new Login().UsernametextBox.Text;
                Vehiculo v = (Vehiculo)vehiculocomboBox.SelectedValue;
                string guardar = "insert into plan_combus(periodo,idvehiculo,fecha,ci,nombre,lugar_sal,km_salida,lugar_dest,km_llegada,km_recorrido,motivo,lts_carg,nro_fact,imp_total)values('" +
                periodotextBox.Text + "'," + v.IdVehiculo + ",'" + FechaCombus.Text + "','" + CItextBox.Text + "','" + nombretextBox.Text + "','" + salidatextBox.Text + "'," + kmsalidatextBox.Text + ",'" +
                destinotextBox.Text + "'," + kmllegadatextBox.Text + "," + kmrecorridotextBox.Text + ",'" + motivotextBox.Text + "'," + ltscargadotextBox.Text + ",'" + facturatextBox.Text + "'," + importetextBox.Text + ")";
                SQLiteCommand cmd = new SQLiteCommand(guardar, ConexionDB.conectar());
                cmd.ExecuteNonQuery();
                //logger.Log(username,"Guardó un registro de combustible");
                Auditoria();
                MessageBox.Show("Datos guardados exitosamente");
                Limpiar();
                Mostrar();
                return;
                //MessageBox.Show("Datos guardados en la nube con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar datos: " + ex.Message);
            }
        }

        private void AgregarVehiculoButton_Click(object sender, RoutedEventArgs e)
        {
            VehiculoWindow v = new VehiculoWindow(this);
            v.ShowDialog();

        }

        private void ModifycombusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vehiculo v = (Vehiculo)vehiculocomboBox.SelectedValue;
                string modificar = "update plan_combus set periodo='" + periodotextBox.Text + "', idvehiculo=" + v.IdVehiculo + ", fecha='" + FechaCombus + "',ci='" + CItextBox.Text + "', nombre='" +
                nombretextBox.Text + "', lugar_sal='" + salidatextBox.Text + "', km_salida=" + kmsalidatextBox.Text + ", lugar_dest='" + destinotextBox.Text + "', km_llegada=" + kmllegadatextBox.Text + ", km_recorrido=" + kmrecorridotextBox.Text
                + ", motivo='" + motivotextBox.Text + "', lts_carg=" + ltscargadotextBox.Text + ", nro_fact='" + facturatextBox.Text + "', imp_total=" + importetextBox.Text + " where idplan_combus=" + codtextBox.Text + "";
                SQLiteCommand cmd = new SQLiteCommand(modificar, ConexionDB.conectar());
                cmd.ExecuteNonQuery();
                Limpiar();
                LimpiarCombus();
                Mostrar();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void DeletecombusButton_Click(object sender, RoutedEventArgs e)
        {
            string borrar = "delete from plan_combus where idplan_combus=" + codtextBox.Text + "";
            SQLiteCommand cmd = new SQLiteCommand(borrar, ConexionDB.conectar());
            cmd.ExecuteNonQuery();
            Limpiar();
            LimpiarCombus();
            Mostrar();

        }

        ////////////////////////////////////////////////////////////////////////Resumen de Servicios///////////////////////////////////////////////////////////////////////////////

        private void SaveResumen_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string guardarserv1040 = "insert into serv1040(cant1040,horaserv,estructural,vehicular,basural,forestal,pastizal,desconocida,premeditada,accidental,corto,findelimpieza,principio,pequena,mediana,grande,emergral,agua,pqsco2,combustible,bombero,tiempototal,ileso,herido,fallecido,rescate,totalkm,nomina)values(" +
                cant1040textBox.Text + "," + horaserv40textBox.Text + "," + estructuraltextBox.Text + "," + vehiculartextBox.Text + "," + basuraltextBox.Text + "," + forestaltextBox.Text + "," + pastizaltextBox.Text + "," + desconocidastextBox.Text + "," + premeditadastextBox.Text + "," + accidentalestextBox.Text + "," + cortotextBox.Text + "," +
                limpiezatextBox.Text + "," + principiotextBox.Text + "," + pqmagtextBox.Text + "," + mdmagtextBox.Text + "," + grmagtextBox.Text + "," + emergraltextBox.Text + "," + aguatextBox.Text + "," + pqsco2textBox.Text + "," + combustible40textBox.Text + "," + bomberostextBox.Text + "," + tiempototaltextBox.Text + "," +
                ilesostextBox.Text + "," + heridostextBox.Text + "," + fallecidostextBox.Text + "," + rescatestextBox.Text + "," + totalkmtextBox.Text + ",'" + nomina40textBox.Text + "')";
                SQLiteCommand cmd = new SQLiteCommand(guardarserv1040, ConexionDB.conectar());
                cmd.ExecuteNonQuery();

                string guardarserv1041 = "insert into serv1041(cant1041,horaserv,arrollamiento,choque,vuelco,caida,aeronave,peaton,moto,vehliviano,vehpesado,bus,danomat,conherido,conatrap,coninc,matpel,cintcond,cintacomp,cascocond,cascoacomp,ileso,herido,fallecido,rescate,combustible,bombero,kmrecorrido,tiempototal,nomina)values(" +
                cant1041textBox.Text + "," + horaserv41textBox.Text + "," + arrollamientotextBox.Text + "," + choquetextBox.Text + "," + vuelcotextBox.Text + "," + caidatextBox.Text + "," + aeronavetextBox.Text + ",'" + peatonestextBox.Text + "','" + motostextBox.Text + "','" + vehlivtextBox.Text + "','" + vehpestextBox.Text + "','" +
                bustextBox.Text + "','" + dañomattextBox.Text + "','" + conheridostextBox.Text + "','" + conatraptextBox.Text + "','" + coninctextBox.Text + "','" + matpeltextBox.Text + "','" + cintcondtextBox.Text + "','" + cintacomptextBox.Text + "','" + cascondtextBox.Text + "','" + casacomptextBox.Text + "'," + ilesos41textBox.Text + "," +
                heridos41textBox.Text + "," + fallecidos41textBox.Text + "," + rescates41textBox.Text + "," + combustible41textBox.Text + "," + bomberos41textBox.Text + "," + kmrecorrido41textBox.Text + "," + tiempototal41textBox.Text + ",'" + nomina41textBox.Text + "')";
                SQLiteCommand cmd1 = new SQLiteCommand(guardarserv1041, ConexionDB.conectar());
                cmd1.ExecuteNonQuery();

               
                string guardarserv1043 = "insert into serv1043(cant1043,horaserv,rescate,recuperacion,aniali,cobertura,curso,transporte,vivienda,profundidad,altura,derrumbe,naufragio,bomba,suicidio,ileso,herido,fallecido,combustible,nomina)values(" + cant1043textBox.Text + "," + horaserv43textBox.Text + "," + rescate43textBox.Text + "," + recuperaciontextBox.Text + "," +
                anialitextBox.Text + "," + coberturatextBox.Text + "," + cursotextBox.Text + "," + transportetextBox.Text + "," + viviendatextBox.Text + "," + profundidadtextBox.Text + "," + alturatextBox.Text + "," + derrumbetextBox.Text + "," + naufragiotextBox.Text + "," + bombatextBox.Text + "," + suicidiotextBox.Text + "," + ilesos43textBox.Text + "," + heridos43textBox.Text + "," + fallecidos43textBox.Text + "," +
                combustible43textBox.Text + ",'" + nomina43textBox.Text + "')";
                SQLiteCommand cmd2 = new SQLiteCommand(guardarserv1043, ConexionDB.conectar());
                cmd2.ExecuteNonQuery();


                if (guardarserv1040 != null)
                {
                    
                    int idTabla1=0;
                    int idTabla2=0;
                    int idTabla3=0;


                    string consulta = "SELECT MAX(idserv1040) FROM serv1040";
                    using (SQLiteCommand cmmd = new SQLiteCommand(consulta, ConexionDB.conectar()))
                    {
                        object result = cmmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            idTabla1 = Convert.ToInt32(result);
                        }
                    }

                    string consulta2 = "SELECT MAX(idserv1041) FROM serv1041";
                    using (SQLiteCommand cmmd1 = new SQLiteCommand(consulta2, ConexionDB.conectar()))
                    {
                        object result = cmmd1.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            idTabla2 = Convert.ToInt32(result);
                        }
                    }

                    string consulta3 = "SELECT MAX(idserv1043) FROM serv1043";
                    using (SQLiteCommand cmmd2 = new SQLiteCommand(consulta3, ConexionDB.conectar()))
                    {
                        object result = cmmd2.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            idTabla3 = Convert.ToInt32(result);
                        }
                    }

                    Mes m = (Mes)MescomboBox.SelectedValue;
                    string guardarres = "insert into informe(fechaenv,hora,mes,anho,cantcia_est,autor,telefono,lugar,fax,fechacierre,cantserv,idserv1040,idserv1041,idserv1043)values('" + FechaServ.Text + "','" + horatextBox.Text + "'," + m.IdMes + ",'" + AnhotextBox.Text + "'," + cantciaesttextBox.Text + ",'" + autortextBox.Text + "','" + teleftextBox.Text
                    + "','" + lugartextBox.Text + "','" + faxtextBox.Text + "','" + FechaCierre.Text + "'," + totalservtextBox.Text + "," + idTabla1 + "," + idTabla2 + "," + idTabla3 + ")";
                    SQLiteCommand cmd3 = new SQLiteCommand(guardarres, ConexionDB.conectar());
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
                SQLiteCommand cm = new SQLiteCommand(id1040, ConexionDB.conectar());
                using (SQLiteDataReader reader = cm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id40 = reader.GetInt32(0);
                        string mod = "update serv1040 set cant1040=" + cant1040textBox.Text + ", horaserv=" + horaserv40textBox.Text + ", estructural=" + estructuraltextBox.Text + ", vehicular=" +
                        vehiculartextBox.Text + ", basural=" + basuraltextBox.Text + ", forestal=" + forestaltextBox.Text + ", pastizal=" + pastizaltextBox.Text + ", desconocida=" +
                        desconocidastextBox.Text + ", premeditada=" + premeditadastextBox.Text + ", accidental=" + accidentalestextBox.Text + ",corto=" + cortotextBox.Text + ", findelimpieza=" + limpiezatextBox.Text + ", principio=" +
                        principiotextBox.Text + ", pequena=" + pqmagtextBox.Text + ", mediana=" + mdmagtextBox.Text + ", grande=" + grmagtextBox.Text + ", emergral=" + emergraltextBox.Text + ", agua=" +
                        aguatextBox.Text + ", pqsco2=" + pqsco2textBox.Text + ", combustible=" + combustible40textBox.Text + ", bombero=" + bomberostextBox.Text + ", tiempototal=" +
                        tiempototaltextBox.Text + ", ileso=" + ilesostextBox.Text + ", herido=" + heridostextBox.Text + ", fallecido=" + fallecidostextBox.Text + ", rescate=" +
                        rescatestextBox.Text + ", totalkm=" + totalkmtextBox.Text + ", nomina='" + nomina40textBox.Text + "' where idserv1040 = " + id40 + "";
                        SQLiteCommand cmd = new SQLiteCommand(mod, ConexionDB.conectar());
                        cmd.ExecuteNonQuery();
                    }
                }

                //serv1041
                string id1041 = "select i.idserv1041 from informe i where i.idinforme=" + codrestextBox.Text + "";
                SQLiteCommand cm1 = new SQLiteCommand(id1041, ConexionDB.conectar());
                using (SQLiteDataReader reader = cm1.ExecuteReader())
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
                        SQLiteCommand cmd = new SQLiteCommand(mod, ConexionDB.conectar());
                        cmd.ExecuteNonQuery();
                    }
                }

                //serv1043
                string id1043 = "select i.idserv1043 from informe i where i.idinforme=" + codrestextBox.Text + "";
                SQLiteCommand cm2 = new SQLiteCommand(id1043, ConexionDB.conectar());
                using (SQLiteDataReader reader = cm2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id43 = reader.GetInt32(0);
                        string mod = "update serv1043 set cant1043=" + cant1043textBox.Text + ", horaserv=" + horaserv43textBox.Text + ", rescate=" + rescate43textBox.Text + ", recuperacion=" +
                        recuperaciontextBox.Text + ", aniali=" + anialitextBox.Text + ", cobertura=" + coberturatextBox.Text + ", curso=" + cursotextBox.Text + ",transporte=" + transportetextBox.Text + ", vivienda=" + viviendatextBox.Text + ", profundidad=" +
                        profundidadtextBox.Text + ", altura=" + alturatextBox.Text + ", derrumbe=" + derrumbetextBox.Text + ", naufragio=" + naufragiotextBox.Text + ", bomba=" + bombatextBox.Text + ", suicidio=" +
                        suicidiotextBox.Text + ", ileso=" + ilesos43textBox.Text + ", herido=" + heridos43textBox.Text + ", fallecido=" + fallecidos43textBox.Text + ", combustible=" + combustible43textBox.Text + ", nomina='" +
                        nomina43textBox.Text + "' where idserv1043=" + id43 + "";
                        SQLiteCommand cmd = new SQLiteCommand(mod, ConexionDB.conectar());
                        cmd.ExecuteNonQuery();
                    }
                }

                //informe
                Mes m = (Mes)MescomboBox.SelectedValue;
                string mod1 = "update informe set fechaenv='" + FechaServ.Text + "', hora='" + horatextBox.Text + "', mes=" + m.IdMes + ", anho=" + AnhotextBox.Text + ", cantcia_est=" + cantciaesttextBox.Text + ", autor='" +
                autortextBox.Text + "', telefono='" + teleftextBox.Text + "', lugar='" + lugartextBox.Text + "', fax='" + faxtextBox.Text + "', fechacierre='" + FechaCierre.Text + "', cantserv=" + totalservtextBox.Text + " where idinforme=" +
                codrestextBox.Text + "";
                SQLiteCommand cmd1 = new SQLiteCommand(mod1, ConexionDB.conectar());
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
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
                SQLiteCommand cmd = new SQLiteCommand(borrarres, ConexionDB.conectar());
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
                MescomboBox.Text = mes;
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
        private void LogOutButton_Clikc(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Quieres cerrar sesión?", "Cierre de sesión", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Login log = new Login();
                log.Show();
                Close();
            }

        }
        /////////////Generar PDF//////////////
        private void GenerarWordButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos filtrados de la base de datos
            string periodo = "";
            string vehiculo = "";
            string chapa = "";
            string tipo = "";
            string header = "select pc.periodo, v.descripcion as vehiculo, v.chapa, tc.descripcion as tipo from plan_combus pc, vehiculo v, tipo_combus tc where  tc.idtipo_combus=v.idtipo_combus and v.idvehiculo=pc.idvehiculo and pc.periodo like '%" + filtrotextBox.Text + "%'";
            SQLiteCommand cmd = new SQLiteCommand(header, ConexionDB.conectar());
            using (SQLiteDataReader r = cmd.ExecuteReader())
            {
                if (r.Read())
                {
                    periodo = r["periodo"].ToString();
                    vehiculo = r["vehiculo"].ToString();
                    chapa = r["chapa"].ToString();
                    tipo = r["tipo"].ToString();
                }
            }

            try
            {
                string filePath = "../Documento.docx";

                using (WordprocessingDocument doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    // Configurar la orientación y el tamaño de página
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    SectionProperties sectionProperties = new SectionProperties();
                    PageSize pageSize = new PageSize()
                    {
                        Width = 21590U,
                        Height = 35560U,
                        Orient = PageOrientationValues.Landscape
                    };
                    sectionProperties.Append(pageSize);
                    body.AppendChild(sectionProperties);


                    // Agregar los primeros dos párrafos
                    AddParagraphCombus(body, "PLANILLA DE USO DE COMBUSTIBLE", JustificationValues.Center, 28, true);
                    AddParagraphCombus(body, "CUERPO DE BOMBEROS VOLUNTARIOS DE CORONEL BOGADO", JustificationValues.Center, 28, true);
                    AddParagraphCombus(body, "Entidad: CUERPO DE BOMBEROS VOLUNTARIOS DE CORONEL BOGADO", JustificationValues.Left, 22, true);
                    AddParagraphCombus(body, "Periodo y Ejercicio: " + periodo + "", JustificationValues.Left, 22, true);
                    AddParagraphCombus(body, "Vehículo: vehiculo    Chapa: <chapa>    Tipo de combustible: <tipo>", JustificationValues.Left, 22, true);
                    AddParagraphCombus(body, "PLANILLA DE USO DE COMBUSTIBLE", JustificationValues.Center, 22, true);


                    // Buscar y reemplazar los valores en el documento
                    foreach (var text in doc.MainDocumentPart.Document.Descendants<Text>())
                    {
                        if (text.Text.Contains("<periodo>"))
                            text.Text = text.Text.Replace("<periodo>", periodo);
                        if (text.Text.Contains("vehiculo"))
                            text.Text = text.Text.Replace("vehiculo", vehiculo);
                        if (text.Text.Contains("<chapa>"))
                            text.Text = text.Text.Replace("<chapa>", chapa);
                        if (text.Text.Contains("<tipo>"))
                            text.Text = text.Text.Replace("<tipo>", tipo);
                    }

                    string consulta = "select p.fecha,p.ci,p.nombre,p.lugar_sal as lugar_salida,p.km_salida,p.lugar_dest as lugar_destino,p.km_llegada,p.km_recorrido,p.motivo,p.lts_carg as litros_cargados,p.nro_fact as factura, p.imp_total as importe_total from plan_combus p inner join vehiculo v where p.idvehiculo= v.idvehiculo and p.periodo like '%" + filtrotextBox.Text + "%'";
                    SQLiteCommand command = new SQLiteCommand(consulta, ConexionDB.conectar());
                    SQLiteDataReader reader = command.ExecuteReader();

                    // Agregar una tabla al documento
                    Table wordTable = body.AppendChild(new Table());
                    TableRow headerRow = new TableRow();
                    // Agregar bordes a la tabla
                    TableProperties tableProperties = new TableProperties(
                    new TableBorders(
                         new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "000000" },
                         new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "000000" },
                         new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "000000" },
                         new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "000000" },
                         new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "000000" },
                         new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Color = "000000" }
                        )
                    );
                    TableCellProperties cellProperties = new TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "10" });
                    wordTable.AppendChild(tableProperties);
                    wordTable.AppendChild(cellProperties);

                    headerRow.AppendChild(CreateTableCell("Fecha", true));
                    headerRow.AppendChild(CreateTableCell("CI", true));
                    headerRow.AppendChild(CreateTableCell("Nombre", true));
                    headerRow.AppendChild(CreateTableCell("Lugar Salida", true));
                    headerRow.AppendChild(CreateTableCell("Km Salida", true));
                    headerRow.AppendChild(CreateTableCell("Lugar Destino", true));
                    headerRow.AppendChild(CreateTableCell("Km Llegada", true));
                    headerRow.AppendChild(CreateTableCell("Km Recorrido", true));
                    headerRow.AppendChild(CreateTableCell("Motivo", true));
                    headerRow.AppendChild(CreateTableCell("Litros Cargados", true));
                    headerRow.AppendChild(CreateTableCell("Factura", true));
                    headerRow.AppendChild(CreateTableCell("Importe Total", true));
                    wordTable.AppendChild(headerRow);


                    // Leer los resultados de la consulta y agregarlos a la tabla
                    while (reader.Read())
                    {
                        string fecha = reader.GetString(0);
                        string ci = reader.GetString(1);
                        string nombre = reader.GetString(2);
                        string lugarsalida = reader.GetString(3);
                        string kmsalida = reader.GetInt32(4).ToString();
                        string lugardestino = reader.GetString(5);
                        string kmllegada = reader.GetInt32(6).ToString();
                        string kmrecorrido = reader.GetInt32(7).ToString();
                        string motivo = reader.GetString(8);
                        string litros = reader.GetInt32(9).ToString();
                        string factura = reader.GetString(10);
                        string importe = reader.GetInt32(11).ToString();

                        TableRow dataRow = new TableRow();
                        dataRow.AppendChild(CreateTableCell(fecha, false));
                        dataRow.AppendChild(CreateTableCell(ci, false));
                        dataRow.AppendChild(CreateTableCell(nombre, false));
                        dataRow.AppendChild(CreateTableCell(lugarsalida, false));
                        dataRow.AppendChild(CreateTableCell(kmsalida, false));
                        dataRow.AppendChild(CreateTableCell(lugardestino, false));
                        dataRow.AppendChild(CreateTableCell(kmllegada, false));
                        dataRow.AppendChild(CreateTableCell(kmrecorrido, false));
                        dataRow.AppendChild(CreateTableCell(motivo, false));
                        dataRow.AppendChild(CreateTableCell(litros, false));
                        dataRow.AppendChild(CreateTableCell(factura, false));
                        dataRow.AppendChild(CreateTableCell(importe, false));
                        wordTable.AppendChild(dataRow);
                    }

                    //doc.MainDocumentPart.Document.Save();
                    mainPart.Document.Save();

                }
                // Abrir un cuadro de diálogo para guardar el archivo modificado
                SaveFileDialog dialogoGuardar = new SaveFileDialog();
                dialogoGuardar.Filter = "Archivos Word (*.docx)|*.docx";
                dialogoGuardar.DefaultExt = "docx";

                if (dialogoGuardar.ShowDialog() == true)
                {
                    string rutaArchivo = dialogoGuardar.FileName;
                    File.Move(filePath, rutaArchivo);
                    MessageBox.Show("Documento guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}
        private void AddParagraphCombus(Body body, string text, JustificationValues justification, int fontSize, bool isBold)
        {
            Paragraph paragraph = body.AppendChild(new Paragraph());
            Run run = paragraph.AppendChild(new Run());
            run.AppendChild(new Text(text));
            run.RunProperties = new RunProperties();
            run.RunProperties.FontSize = new FontSize() { Val = fontSize.ToString() };
            if (isBold)
            {
                run.RunProperties.Bold = new Bold();
            }
            paragraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = justification });
        }
        private void AddParagraph(Body body, string text, JustificationValues justification, int fontSize, bool isBold, bool isSpacingNull)
        {
            Paragraph paragraph = body.AppendChild(new Paragraph());
            Run run = paragraph.AppendChild(new Run());
            run.AppendChild(new Text(text));
            run.RunProperties = new RunProperties();
            run.RunProperties.FontSize = new FontSize() { Val = fontSize.ToString() };
            if (isBold)
            {
                run.RunProperties.Bold = new Bold();
            }
            paragraph.ParagraphProperties = new ParagraphProperties(new Justification() { Val = justification });
            ParagraphProperties paragraphProperties = new ParagraphProperties(new SpacingBetweenLines() { Before = isSpacingNull ? "0" : "240", After = isSpacingNull ? "0" : "240" });
            paragraph.ParagraphProperties = paragraphProperties;
        }
        private TableCell CreateTableCell(string text, bool isBold)
        {
            TableCell cell = new TableCell();
            Paragraph paragraph = new Paragraph();
            Run run = new Run(new Text(text));
            run.RunProperties = new RunProperties();
            if (isBold)
            {
                run.RunProperties.Bold = new Bold();
            }
            paragraph.Append(run);
            cell.Append(paragraph);
            return cell;
        }
        private void FiltrarperiodoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filtrado = "select p.idplan_combus as código,p.periodo,v.descripcion as vehiculo,p.fecha,p.ci,p.nombre,p.lugar_sal as lugar_salida,p.km_salida,p.lugar_dest as lugar_destino,p.km_llegada,p.km_recorrido,p.motivo,p.lts_carg as litros_cargados,p.nro_fact as factura, p.imp_total as importe_total from plan_combus p inner join vehiculo v where p.idvehiculo= v.idvehiculo and p.periodo like '%" + filtrotextBox.Text + "%'";
                SQLiteCommand cmd = new SQLiteCommand(filtrado, ConexionDB.conectar());
                CombustibledataGrid.ItemsSource = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddHeader(Body body, string text)
        {
            Paragraph paragraph = body.AppendChild(new Paragraph());
            Run run = paragraph.AppendChild(new Run());
            run.AppendChild(new Text(text));

            // Configurar las propiedades del párrafo
            ParagraphProperties paragraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center },
                new SpacingBetweenLines() { Before = "0", After = "0" }
            );
            paragraph.ParagraphProperties = paragraphProperties;

            // Configurar las propiedades del run (texto)
            RunProperties runProperties = new RunProperties(
                new Bold(),
                new FontSize() { Val = "24" }
            );
            run.RunProperties = runProperties;
        }
        private void GenerarWordServButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string header = "SELECT i.fechaenv,i.hora,i.mes,i.anho AS año,i.cantcia_est,i.autor,i.telefono,i.lugar,i.fax,i.fechacierre,i.cantserv, s.cant1040, s.horaserv AS hserv40,s.estructural,s.vehicular,s.basural,s.forestal,s.pastizal,s.desconocida,s.premeditada,s.accidental,s.corto,s.findelimpieza,s.principio,s.pequena,s.mediana,s.grande,s.emergral,s.agua,s.pqsco2,s.combustible AS combus40,s.bombero AS bomber40,s.tiempototal AS tt40,s.ileso AS ileso40,s.herido AS herido40,s.fallecido AS fallecido40,s.rescate AS rescate40,s.totalkm,s.nomina AS nomina40,ss.cant1041,ss.horaserv AS hserv41,ss.arrollamiento,ss.choque,ss.vuelco,ss.caida,ss.aeronave,ss.peaton,ss.moto,ss.vehliviano,ss.vehpesado,ss.bus,ss.danomat,ss.conherido,ss.conatrap,ss.coninc,ss.matpel,ss.cintcond,ss.cintacomp,ss.cascocond,ss.cascoacomp,ss.ileso AS ileso41,ss.herido AS herido41,ss.fallecido AS fallecido41,ss.rescate AS rescate41,ss.combustible AS combus41,ss.bombero AS bomber41,ss.kmrecorrido,ss.tiempototal AS tt41,ss.nomina AS nomina41, sss.cant1043, sss.horaserv AS hserv43, sss.rescate,sss.recuperacion, sss.aniali,sss.cobertura,sss.curso,sss.transporte,sss.vivienda,sss.profundidad,sss.altura,sss.derrumbe,sss.naufragio,sss.bomba,sss.suicidio,sss.ileso AS ileso43,sss.herido AS herido43,sss.fallecido AS fallecido43,sss.combustible AS combus43,sss.nomina AS nomina43 FROM informe  i, serv1040 s,serv1041 ss, serv1043 sss WHERE i.idserv1040=s.idserv1040 AND i.idserv1041=ss.idserv1041 AND i.idserv1043=sss.idserv1043 AND i.idinforme= " + codrestextBox.Text + "";
                SQLiteCommand cmd = new SQLiteCommand(header, ConexionDB.conectar());
                using (SQLiteDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        string fechaenv = r["fechaenv"].ToString();
                        string hora = r["hora"].ToString();
                        string mes = r["mes"].ToString();
                        string año = r["año"].ToString();
                        string cantest = r["cantcia_est"].ToString();
                        string autor = r["autor"].ToString();
                        string telf = r["telefono"].ToString();
                        string lugar = r["lugar"].ToString();
                        string fax = r["fax"].ToString();
                        string fechacierre = r["fechacierre"].ToString();
                        string cantserv = r["cantserv"].ToString();

                        string cant40 = r["cant1040"].ToString();
                        string hs40 = r["hserv40"].ToString();
                        string estructural = r["estructural"].ToString();
                        string vehicular = r["vehicular"].ToString();
                        string basural = r["basural"].ToString();
                        string forestal = r["forestal"].ToString();
                        string pastizal = r["pastizal"].ToString();
                        string desconocidas = r["desconocida"].ToString();
                        string premeditadas = r["premeditada"].ToString();
                        string accidental = r["accidental"].ToString();
                        string corto = r["corto"].ToString();
                        string limpieza = r["findelimpieza"].ToString();
                        string principio = r["principio"].ToString();
                        string pequena = r["pequena"].ToString();
                        string mediana = r["mediana"].ToString();
                        string grande = r["grande"].ToString();
                        string emergral = r["emergral"].ToString();
                        string agua = r["agua"].ToString();
                        string pqsco2 = r["pqsco2"].ToString();
                        string combus40 = r["combus40"].ToString();
                        string bomber40 = r["bomber40"].ToString();
                        string tt40 = r["tt40"].ToString();
                        string ileso40 = r["ileso40"].ToString();
                        string herido40 = r["herido40"].ToString();
                        string fallecido40 = r["fallecido40"].ToString();
                        string rescate40 = r["rescate40"].ToString();
                        string totalkm = r["totalkm"].ToString();
                        string nomina40 = r["nomina40"].ToString();

                        string cant41 = r["cant1041"].ToString();
                        string hs41 = r["hserv41"].ToString();
                        string arrollamiento = r["arrollamiento"].ToString();
                        string choque = r["choque"].ToString();
                        string vuelco = r["vuelco"].ToString();
                        string caida = r["caida"].ToString();
                        string aeronave = r["aeronave"].ToString();
                        string peaton = r["peaton"].ToString();
                        string moto = r["moto"].ToString();
                        string vehliviano = r["vehliviano"].ToString();
                        string vehpesado = r["vehpesado"].ToString();
                        string bus = r["bus"].ToString();
                        string danomat = r["danomat"].ToString();
                        string conherido = r["conherido"].ToString();
                        string conatrap = r["conatrap"].ToString();
                        string coninc = r["coninc"].ToString();
                        string matpel = r["matpel"].ToString();
                        string cintcond = r["cintcond"].ToString();
                        string cintacomp = r["cintacomp"].ToString();
                        string cascocond = r["cascocond"].ToString();
                        string cascoacomp = r["cascoacomp"].ToString();
                        string ileso41 = r["ileso41"].ToString();
                        string herido41 = r["herido41"].ToString();
                        string fallecido41 = r["fallecido41"].ToString();
                        string rescate41 = r["rescate41"].ToString();
                        string combus41 = r["combus41"].ToString();
                        string bomber41 = r["bomber41"].ToString();
                        string kmrecorrido = r["kmrecorrido"].ToString();
                        string tt41 = r["tt41"].ToString();
                        string nomina41 = r["nomina41"].ToString();

                        string cant43 = r["cant1043"].ToString();
                        string hs43 = r["hserv43"].ToString();
                        string rescate = r["rescate"].ToString();
                        string recuperacion = r["recuperacion"].ToString();
                        string aniali = r["aniali"].ToString();
                        string cobertura = r["cobertura"].ToString();
                        string curso = r["curso"].ToString();
                        string transporte = r["transporte"].ToString();
                        string vivienda = r["vivienda"].ToString();
                        string profundidad = r["profundidad"].ToString();
                        string altura = r["altura"].ToString();
                        string derrumbe = r["derrumbe"].ToString();
                        string naufragio = r["naufragio"].ToString();
                        string bomba = r["bomba"].ToString();
                        string suicidio = r["suicidio"].ToString();
                        string ileso43 = r["ileso43"].ToString();
                        string herido43 = r["herido43"].ToString();
                        string fallecido43 = r["fallecido43"].ToString();
                        string combus43 = r["combus43"].ToString();
                        string nomina43 = r["nomina43"].ToString();

                        string filePath = "../DocumentoServ.docx";
                        using (WordprocessingDocument doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                        {
                            MainDocumentPart mainPart = doc.AddMainDocumentPart();
                            mainPart.Document = new Document();
                            Body body = mainPart.Document.AppendChild(new Body());


                            // Agregar los primeros dos párrafos
                            AddHeader(body, "JUNTA NACIONAL DE CUERPOS DE BOMBEROS VOLUNTARIOS DEL PARAGUAY");
                            AddHeader(body, "COMANDANCIA NACIONAL");
                            AddHeader(body, "INFORME MENSUAL DE SERVICIOS");
                            AddHeader(body, "CBV de CORONEL BOGADO");
                            AddParagraph(body, "Fecha de Envió: " + fechaenv + "", JustificationValues.Left, 22, true, true);
                            AddParagraph(body, "Hora: " + hora + "                            Mes: " + mes + "                              Año: " + año + "", JustificationValues.Left, 22, true, true);
                            AddParagraph(body, "CBV de Cnel. José Félix Bogado                                             Cantidad Cía. /Estaciones: " + cantest + "", JustificationValues.Left, 22, true, true);
                            AddParagraph(body, "Elaborado por: " + autor + "                                                     Tel.: " + telf + "", JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "Enviado desde: Cuerpo de Bomberos Voluntarios de Cnel. Bogado", JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "Fax habilitado (para posible reenvío): " + fax + "		     Fecha de cierre del informe: " + fechacierre + "", JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "CANTIDAD TOTAL DE SERVICIO: " + cantserv + "", JustificationValues.Left, 22, true, true);
                            AddParagraph(body, "10.40", JustificationValues.Left, 24, true, true);
                            AddParagraph(body, "10.40", JustificationValues.Center, 20, true, true);
                            AddParagraph(body, "CANTIDAD GLOBAL DE 10.40: " + cant40 + "     Horas en servicios: " + hs40, JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "Servicio 10.40.                                      Magnitudes.                                Cantidad de 10.44/10.45", JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "1-Estructural: " + estructural + "                                    1-Principio: " + principio + "                                1-Ileso/s: " + ileso40 + "", JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "2-Vehicular: " + vehicular + "                                       2-Pequeña Magnitud: " + pequena + "             2-Herido/s: " + herido40, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "3-Basural: " + basural + "                                           3-Mediana Magnitud: " + mediana + "          3-Fallecidos/s: " + fallecido40, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "4-Forestal: " + forestal + "                                          4-Gran Magnitud: " + grande + "                 4-Rescate/s: " + rescate40, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "5-Pastizal: " + pastizal + "                                           5-Emergencia Gral.: " + emergral, JustificationValues.Left, 20, false, true);

                            AddParagraph(body, "Causas Posibles                                    Recursos Utilizados                   Móviles/Km.", JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "1-Desconocidas: " + desconocidas + "                              1-Agua: " + agua + "                                   1-Total km.: " + totalkm, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "2-Premeditadas: " + premeditadas + "                              2-PQS/CO2: " + pqsco2 + "                           2-Nomina: " + nomina40, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "3-Accidentales: " + accidental + "                                3-Combustible: " + combus40, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "4-Corto Circuito: " + corto + "                                  4-Bomberos: " + bomber40, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "5-Fin de Limpieza: " + limpieza + "                           5-Tiempo total: " + tt40, JustificationValues.Left, 20, false, true);


                            AddParagraph(body, "", JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "10.41", JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "CANTIDAD GLOBAL DE 10.41: " + cant41 + "                                                             Horas en servicios: " + hs41, JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "Servicio 10.41.                                     Magnitudes.                               Cantidad de 10.44/10.45", JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "1- Arrollamientos: " + arrollamiento + "                           1- Daños Materiales: " + danomat + "               1-Ileso/s: " + danomat, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "2- Choque: " + choque + "                                         2- Con Heridos.: " + conherido + "                      2-Herido/s: " + herido41, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "3- Vuelcos: " + vuelco + "                                         3- Con Heridos Atrap.: " + conatrap + "         3-Fallecido/s: " + fallecido41, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "4- Caída: " + caida + "                                             4- Con Incendio.: " + coninc + "                  4-Rescate/s: " + rescate41, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "5- Aeronave: " + aeronave + "                                      5- Con Mat-Pel.: " + matpel, JustificationValues.Left, 20, false, true);

                            AddParagraph(body, "Elementos Involucrados                 Seguridad de Involucrados          Recursos Usados.", JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "1-Peatones: " + peaton + "                                      1-Cinturón Conductor: " + cintcond + "         1-Combustible: " + combus41, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "2-Moto: " + moto + "                                             2-Cinturón Acomp.: " + cintacomp + "              2-Bomberos: " + bomber41, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "3-Veh. Livianos: " + vehliviano + "                               3-Casco Conductor: " + cascocond + "               3-Km. recorrido: " + kmrecorrido, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "4-Veh. Pesados: " + vehpesado + "                               4-Casco Acompan.: " + cascoacomp + "               4-Tiempo Total: " + tt41, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "5-Buses: " + bus, JustificationValues.Left, 20, false, true);


                            AddParagraph(body, "", JustificationValues.Left, 10, true, true);
                            AddParagraph(body, "10.43", JustificationValues.Left, 24, true, true);
                            AddParagraph(body, "CANTIDAD GLOBAL DE 10.43: " + cant43 + "                                                          Horas en servicios: " + hs43, JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "Servicio 10.43.                                 Tipo de Rescate.                          Cantidad de 10.44/10.45", JustificationValues.Left, 20, true, true);
                            AddParagraph(body, "1-Rescate: " + rescate + "                                     1-En Vivienda: " + vivienda + "                             1-Ileso/s: " + ileso43, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "2-Recuperación: " + recuperacion + "                          2-Profundidad: " + profundidad + "                          2-Herido/s: " + herido43, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "3-Animales/Alimañas: " + aniali + "                3-Altura: " + altura + "                                     3-Fallecidos/s: " + fallecido43, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "4-Cobertura: " + cobertura + "                                4-Derrumbe: " + derrumbe, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "5-Curso/Charla: " + curso + "                           5-Raudal/naufragio: " + naufragio + "                 4-Combustible: " + combus43, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "6-Transporte: " + transporte + "                              6-Amenaza Bomba: " + bomba + "                   5-Nomina:" + nomina43, JustificationValues.Left, 20, false, true);
                            AddParagraph(body, "                                                             7-Intento de suicidio: " + suicidio, JustificationValues.Left, 20, false, true);


                        }



                        SaveFileDialog dialogoGuardar = new SaveFileDialog();
                        dialogoGuardar.Filter = "Archivos Word (*.docx)|*.docx";
                        dialogoGuardar.DefaultExt = "docx";

                        if (dialogoGuardar.ShowDialog() == true)
                        {
                            string rutaArchivo = dialogoGuardar.FileName;
                            File.Move(filePath, rutaArchivo);
                            MessageBox.Show("Documento guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string esquema = "select m.descripcion, sum(sss.cobertura) as cobertura, sum(ss.cant1041) as accidentes, sum(s.estructural) as estructural,sum(s.vehicular) as vehicular,sum(s.pastizal) as pastizal,sum(sss.rescate) as rescate,sum(sss.aniali) as animales_alimañas from informe i inner join mes m, serv1040 s, serv1041 ss, serv1043 sss where i.mes=m.idmes and i.idserv1040=s.idserv1040 and i.idserv1041=ss.idserv1041 and i.idserv1043=sss.idserv1043 and i.anho=" + filtroañotextBox.Text+" group by m.descripcion";
                SQLiteCommand cmd = new SQLiteCommand(esquema, ConexionDB.conectar());
                esquemadataGrid.ItemsSource = cmd.ExecuteReader();
                string pie = "select sum(sss.cobertura) as cobertura, sum(ss.cant1041) as accidentes, sum(s.estructural) as estructural,sum(s.vehicular) as vehicular,sum(s.pastizal) as pastizal,sum(sss.rescate) as rescate,sum(sss.aniali) as animales_alimañas from informe i inner join serv1040 s, serv1041 ss, serv1043 sss where i.idserv1040=s.idserv1040 and i.idserv1041=ss.idserv1041 and i.idserv1043=sss.idserv1043 and i.anho=" + filtroañotextBox.Text + "";
                SQLiteCommand cm = new SQLiteCommand(pie, ConexionDB.conectar());
                SQLiteDataReader r = cm.ExecuteReader();
                var pieSeriesCollection = new SeriesCollection();

                while (r.Read())
                {
                    // Leer los valores globales por año
                    double cobertura = Convert.ToDouble(r["cobertura"]);
                    double accidentes = Convert.ToDouble(r["accidentes"]);
                    double estructural = Convert.ToDouble(r["estructural"]);
                    double vehicular = Convert.ToDouble(r["vehicular"]);
                    double pastizal = Convert.ToDouble(r["pastizal"]);
                    double rescate = Convert.ToDouble(r["rescate"]);
                    double animalesAlimanas = Convert.ToDouble(r["animales_alimañas"]);

                    // Añadir series a la colección
                    pieSeriesCollection.Add(new PieSeries
                    {
                        Title = "Cobertura",
                        Values = new ChartValues<double> { cobertura },
                        Fill = Brushes.DeepSkyBlue,
                        DataLabels = true
                    });

                    pieSeriesCollection.Add(new PieSeries
                    {
                        Title = "Accidentes",
                        Values = new ChartValues<double> { accidentes },
                        Fill = Brushes.Orange,
                        DataLabels = true
                    });

                    pieSeriesCollection.Add(new PieSeries
                    {
                        Title = "Estructural",
                        Values = new ChartValues<double> { estructural },
                        Fill = Brushes.Blue,
                        DataLabels = true
                    });

                    pieSeriesCollection.Add(new PieSeries
                    {
                        Title = "Vehicular",
                        Values = new ChartValues<double> { vehicular },
                        Fill = Brushes.Red,
                        DataLabels = true
                    });

                    pieSeriesCollection.Add(new PieSeries
                    {
                        Title = "Pastizal",
                        Values = new ChartValues<double> { pastizal },
                        Fill = Brushes.Green,
                        DataLabels = true
                    });

                    pieSeriesCollection.Add(new PieSeries
                    {
                        Title = "Rescate",
                        Values = new ChartValues<double> { rescate },
                        Fill = Brushes.DarkViolet,
                        DataLabels = true
                    });

                    pieSeriesCollection.Add(new PieSeries
                    {
                        Title = "Animales/Alimañas",
                        Values = new ChartValues<double> { animalesAlimanas },
                        Fill = Brushes.DeepSkyBlue,
                        DataLabels = true
                    });
                }

                    // Reemplazar las series iniciales con la nueva colección
                    if (pieChart != null)
                    {
                        pieChart.Series.Clear(); // Elimina las series iniciales de marcador de posición
                        pieChart.Series = pieSeriesCollection; // Asigna la nueva colección de series
                    }
                    else
                    {
                        MessageBox.Show("El gráfico de pastel no está inicializado.");
                    }
                
            }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
        private void SaveUsers_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string saveuser = "insert into users(username, password, role, CI, correo ,phone)values('" + UsuariotextBox.Text + "','" + UserpasstextBox.Password + "','" + RoltextBox.Text + "'," + UsercitextBox.Text + ",'" + UsercorreotextBox.Text + "','" + UserteleftextBox.Text + "')";
                SQLiteCommand cmd = new SQLiteCommand(saveuser, ConexionDB.conectar());
                cmd.ExecuteNonQuery();
                Limpiar();
                Mostrar();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void ModifyUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 string modifyuser = "update users set username='" + UsuariotextBox.Text + "', password='" + UserpasstextBox.Password + "', role='" + RoltextBox.Text + "', CI=" + UsercitextBox.Text + ", correo='" + UsercorreotextBox.Text + "', phone='" + UserteleftextBox.Text + "' where id=" + codusertextBox.Text + "";
                 SQLiteCommand cmd = new SQLiteCommand(modifyuser, ConexionDB.conectar());
                 cmd.ExecuteNonQuery();
                 Limpiar();
                 Mostrar();
                    
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string deleteuser = "delete from users where id=" + codusertextBox.Text + "";
                SQLiteCommand cmd = new SQLiteCommand(deleteuser, ConexionDB.conectar());
                cmd.ExecuteNonQuery();
                Limpiar();
                Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

