using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    public partial class FormPropiedades : Form
    {
        private bool HayErrores = false;
        ManagerConnect.CNodoRaiz NodoRaiz;
        ObjetosModelo.AppModel Modelo;
        ObjetosModelo.CConfiguracion nombre, ruta;
        bool NoAfterCheck = false;
        List<ManagerConnect.CConexion> ConexionesSeleccionadas;
        public FormPropiedades(ObjetosModelo.AppModel modelo)
        {
            Modelo = modelo;
            InitializeComponent();
        }

        private void FormPropiedades_Load(object sender, EventArgs e)
        {
            nombre = Modelo.GetConfiguracion("Nombre");
            ruta = Modelo.GetConfiguracion("Ruta");
            TNombre.Text = nombre.Valor;
            TRuta.Text = ruta.Valor;
            foreach (ObjetosModelo.CExtencion obj in Modelo.GetExtenciones())
            {
                LExtenciones.Items.Add(obj.Extencion);
            }
            CargaConexiones();

        }
        private void CargaConexiones()
        {
            NoAfterCheck = true;
            NodoRaiz = new ManagerConnect.CNodoRaiz();
            LConexiones.Nodes.Add(NodoRaiz);
            NodoRaiz.CargaGrupos();
            List<ObjetosModelo.CServidor> l = Modelo.GetServidores();
            foreach (ObjetosModelo.CServidor obj in l)
            {
                List<ObjetosModelo.CConexion> conexiones = obj.getConexiones();
                foreach (ObjetosModelo.CConexion conexion in conexiones)
                {
                    ManagerConnect.CConexion conecion2 = ManagerConnect.ControladorConexiones.GetConexion(obj.Nombre, conexion.Nombre);
                    MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(conecion2);
                    NodoRaiz.MarcaMotor(motor);
                }
            }
            NoAfterCheck = false;

        }

        private void BRuta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            TRuta.Text = folderBrowserDialog1.SelectedPath;
        }

        private void BAgregarExtencion_Click(object sender, EventArgs e)
        {
            if (TExtencion.Text.Trim() == "")
                return;
            foreach (string s in LExtenciones.Items)
            {
                if (s.ToUpper().Trim() == TExtencion.Text.ToUpper().Trim())
                    return;
            }
            LExtenciones.Items.Add(TExtencion.Text.Trim());
        }

        private void BEliminarExtencion_Click(object sender, EventArgs e)
        {
            if (LExtenciones.SelectedIndex == -1)
                return;
            LExtenciones.Items.RemoveAt(LExtenciones.SelectedIndex);
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nombre.Valor != TNombre.Text)
                {
                    nombre.Valor = TNombre.Text;
                    nombre.update();
                }
                if (ruta.Valor != TRuta.Text)
                {
                    ruta.Valor = TRuta.Text;
                    ruta.update();
                }
                #region  actulizo las conexiones
                //primero quito las que ya no estan
                List<ObjetosModelo.CServidor> servidortes = Modelo.GetServidores();
                foreach (ObjetosModelo.CServidor servidor in servidortes)
                {
                    List<ObjetosModelo.CConexion> conexiones = servidor.getConexiones();
                    for (int i = conexiones.Count - 1; i >= 0; i--)
                    {
                        ObjetosModelo.CConexion conexion = conexiones[i];
                        if (NodoRaiz.EstaSeleccionado(servidor.Nombre, conexion.Nombre) == false)
                        {
                            //no esta seleccionado, por lo que hay que quitarlo
                            conexion.deleteCascade();
                        }
                    }
                }
                //ahoraagrego las nuevas
                foreach (ManagerConnect.CConexion con in NodoRaiz.DameConexionesSeleccionadas())
                {
                    bool grupoencontrado = false;
                    foreach (ObjetosModelo.CServidor servidor in Modelo.GetServidores())
                    {
                        if (con.GrupoName == servidor.Nombre)
                        {
                            grupoencontrado = true;
                            bool conexionencontrada = false;
                            foreach (ObjetosModelo.CConexion conexion in servidor.getConexiones())
                            {
                                if (conexion.Nombre == con.Nombre)
                                {
                                    conexionencontrada = true;
                                    break;
                                }
                            }
                            if (conexionencontrada == false)
                            {
                                //no se encuentra, por lo que la agrego
                                servidor.createConexion(con.Nombre, con.ConecctionString, con.MotorDB);
                                break;
                            }
                        }
                    }
                    if (grupoencontrado == false)
                    {
                        //no esta el el servidor, por lo que hay que agregarlo junto con la conexion
                        int id_servidor = Modelo.InsertServidor(con.GrupoName);
                        ObjetosModelo.CServidor serv = Modelo.GetServidor(id_servidor);
                        serv.createConexion(con.Nombre, con.ConecctionString, con.MotorDB);

                    }
                }
                #endregion
                #region Actualizo las extenciones
                List<ObjetosModelo.CExtencion> extenciones = Modelo.GetExtenciones();
                foreach (ObjetosModelo.CExtencion extencion in extenciones)
                {
                    bool extencontrada = false;
                    foreach (string s in LExtenciones.Items)
                    {
                        if (s.ToUpper().Trim() == extencion.Extencion.ToUpper().Trim())
                        {
                            extencontrada = true;
                            break;
                        }
                    }
                    if (extencontrada == false)
                    {
                        //hay que quitarla
                        extencion.delete();
                    }
                }
                //ahora reviso las nuevas
                extenciones = Modelo.GetExtenciones();
                foreach (string s in LExtenciones.Items)
                {
                    bool extencontrada = false;
                    foreach (ObjetosModelo.CExtencion extencion in extenciones)
                    {
                        if (s.ToUpper().Trim() == extencion.Extencion.ToUpper().Trim())
                        {
                            extencontrada = true;
                            break;
                        }

                    }
                    if (extencontrada == false)
                    {
                        //hay que quitarla
                        Modelo.InsertExtenciones(s);
                    }
                }

                #endregion
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        private void LConexiones_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (NoAfterCheck == true)
                return;
            ManagerConnect.CNodoBase nodo = (ManagerConnect.CNodoBase)e.Node;
            nodo.AfterCheck();

        }

        private void BProbarConexiones_Click(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.GreenYellow; ;
            TStatus.BackColor = Color.Black;
            HayErrores = false;
            TStatus.Text = "";
            ConexionesSeleccionadas = NodoRaiz.DameConexionesSeleccionadas();
            progressBar1.Maximum = ConexionesSeleccionadas.Count;
            BProbarConexiones.Enabled = false;
            BAceptar.Enabled = false;
            BCancelar.Enabled = false;
            BackConexiones.RunWorkerAsync();
        }

        private void BackConexiones_DoWork(object sender, DoWorkEventArgs e)
        {
            int pos = 1;
            foreach (ManagerConnect.CConexion obj in ConexionesSeleccionadas)
            {
                PruebaConexion(obj, pos);
                pos++;

            }
            BackConexiones.ReportProgress(pos, "Proceso terminado\r\n");

        }
        private void PruebaConexion(ManagerConnect.CConexion obj,int pos)
        {
            
            //ObjetosModelo.CServidor servidor=            Modelo.GetServidor(obj.ID_Grupo);
            
            BackConexiones.ReportProgress(pos, "Probando: " +obj.GrupoName+"->"+ obj.Nombre + "\r\n");
            //me traigo el motor de base de datos
            MotorDB.EnumMotoresDB tipoDB = ManagerConnect.ControladorConexiones.DameTipoMotor(obj.MotorDB);
            MotorDB.IMotorDB m = MotorDB.CProviderDataBase.DameMotor(tipoDB);
            m.SetConnectionName(obj.Nombre);
            m.SetConnectionString(obj.ConecctionString);
            try
            {
                if (m.Conectar() == false)
                {
                    HayErrores = true;
                    BackConexiones.ReportProgress(pos, "No se puede conectar a la base de datos: " + obj.Nombre + ": " + m.GetStringError() + "\r\n");
                }
                else
                {
                    m.Desconectar();
                    BackConexiones.ReportProgress(pos, "Prueba OK\r\n");
                }
            }
            catch (System.Exception ex)
            {
                HayErrores = true;
                BackConexiones.ReportProgress(pos, "No se puede conectar a la base de datos: " + obj.Nombre + ": " + ex.Message + "\r\n");
            }

        }
        private void BackConexiones_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (progressBar1.Maximum >= e.ProgressPercentage)
                {
                    progressBar1.Value = e.ProgressPercentage;
                }
                TStatus.AppendText(e.UserState.ToString() );
                if (HayErrores)
                {
                    TStatus.BackColor = Color.DarkRed;
                    progressBar1.ForeColor = Color.Red;
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

        private void BackConexiones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BAceptar.Enabled = true;
            BCancelar.Enabled = true;
            BProbarConexiones.Enabled = true;
            if(HayErrores )
            {
                TStatus.BackColor = Color.DarkRed;
            }
        }

        private void LConexiones_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            if (NoAfterCheck == false)
            {
                ManagerConnect.CNodoBase nodo = (ManagerConnect.CNodoBase)e.Node;
                nodo.AfterCheck();
            }
        }
    }
}
   