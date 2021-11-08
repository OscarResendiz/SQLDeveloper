using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MotorDB.Motores.MySql
{
    public partial class FormDlsMultiConfigMySql : Form
    {
        private List<string> LBases;
        private MySqlConnectionStringBuilder ConnectionStringBuilder;
        private MySqlConnection Conexion;
        private bool BuscandoServidores;
        private string Servidor;
        private string Usuario;
        private string Password;
        private bool BuscandoBases;
        private bool Errores;
        public FormDlsMultiConfigMySql()
        {
            InitializeComponent();
        }

        private void BVerBases_Click(object sender, EventArgs e)
        {
            if (BuscandoBases == false)
            {
                Servidor = ComboServidores.Text;
                Usuario = TUsuario.Text;
                Password = TPassword.Text;
                ListaBases.Items.Clear();
                ListaBases.Items.Add("Seleccionar todas");
                Cursor = Cursors.WaitCursor;
                BuscandoBases = true;
                BKBuscarBases.RunWorkerAsync();
            }

        }

        private void ListaBases_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                bool estado = e.NewValue == CheckState.Checked;
                for (int i = 1; i < ListaBases.Items.Count; i++)
                {
                    ListaBases.SetItemChecked(i, estado);
                }
            }
        }

        private void BProbar_Click(object sender, EventArgs e)
        {
            if (LBases == null)
                LBases = new List<string>();
            LBases.Clear();
            foreach (object obj in ListaBases.CheckedItems)
            {
                if (obj.ToString() != "Seleccionar todas")
                    LBases.Add(obj.ToString());
            }
            BProbar.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Maximum = LBases.Count();
            TxtMensaje.Text = "";
            ListaBases.BackColor = Color.White;
            Errores = false;
            BkTestConeccion.RunWorkerAsync();
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BkTestConeccion_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < LBases.Count(); i++)
            {
                string nombre = LBases[i];
                Mensaje("probando conexion: " + nombre, i);
                if (PruebaConexcion(nombre) == false)
                    Errores = true;
            }
        }
        private bool PruebaConexcion(string nombre)
        {
            MySqlConnection con = null;
            try
            {
                MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                sb.Server = Servidor;
                sb.UserID = Usuario;
                sb.Password = Password;
                sb.Database= nombre;
                string ConnectionString = sb.ConnectionString;
                con = new MySqlConnection(ConnectionString);
                con.Open();
                con.Close();
            }
            catch (System.Exception ex)
            {
                Mensaje(ex.Message);
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();
                return false;
            }
            return true;
        }

        private void Mensaje(string msg, int progreso = -1)
        {
            BkTestConeccion.ReportProgress(progreso, msg);
        }

        private void BkTestConeccion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtMensaje.AppendText(e.UserState.ToString() + "\r\n");
            if (e.ProgressPercentage != -1)
            {
                progressBar1.Value = (int)e.ProgressPercentage;
            }
        }

        private void BkTestConeccion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BProbar.Enabled = true;
            if (Errores)
            {
                ListaBases.BackColor = Color.Red;
            }
            else
            {
                ListaBases.BackColor = Color.GreenYellow;

            }
        }

        private void BKBuscarBases_DoWork(object sender, DoWorkEventArgs e)
        {
            //hay que traer la lista de bases de datos que hay en el servidor
            ConnectionStringBuilder = new MySqlConnectionStringBuilder();
            ConnectionStringBuilder.Server = Servidor;
            ConnectionStringBuilder.UserID = Usuario;
            ConnectionStringBuilder.Password = Password;
            try
            {

                List<string> bases = new List<string>();
                //creo la consulta
                ConnectionStringBuilder.Database = "information_schema";
                MySqlDataReader dr;
                dr = ExecuteReader("select schema_name as name from INFORMATION_SCHEMA.SCHEMATA");
                while (dr.Read())
                {
                    BKBuscarBases.ReportProgress(0, dr["name"].ToString());
                }
                Conexion.Close();
            }
            catch (System.Exception ex)
            {
                BKBuscarBases.ReportProgress(-1, ex.Message);
            }

        }

        private void BKBuscarBases_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                MessageBox.Show(e.UserState.ToString(), "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListaBases.Items.Add(e.UserState.ToString());
        }

        private void BKBuscarBases_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            BuscandoBases = false;

        }
        private MySqlDataReader ExecuteReader(string comando)
        {
            AbreConexion();
            MySqlDataReader dr = null;
            MySqlCommand SqlCommand1;
            SqlCommand1 = new MySqlCommand();
            SqlCommand1.CommandType = System.Data.CommandType.Text;
            SqlCommand1.Connection = this.Conexion;//remplzar por el componente de conexion adecuado
            SqlCommand1.CommandText = comando;
            if (SqlCommand1.Connection.State == ConnectionState.Open)
                SqlCommand1.Connection.Close();
            SqlCommand1.Connection.Open();
            //RECUPERANDO DATOS
            dr = SqlCommand1.ExecuteReader();
            return dr;
        }
        private void AbreConexion()
        {
            if (Conexion == null)
            {
                Conexion = new MySqlConnection(ConnectionStringBuilder.ConnectionString);
            }
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            Conexion.ConnectionString = ConnectionStringBuilder.ConnectionString;
            Conexion.Open();
        }

        public string ConnectionString
        {
            get
            {
                return Conexion.ConnectionString;
            }
            set
            {
                MySqlConnectionStringBuilder csb;
                csb = new MySqlConnectionStringBuilder(value);
                ComboServidores.Text = csb.Database;
                //ComboBases.Text = csb.InitialCatalog;
                TUsuario.Text = csb.UserID;
                TPassword.Text = csb.Password;
                if (value != null && value != "")
                    Conexion.ConnectionString = value;
            }
        }
        public List<string> GetConnexciones()
        {
            List<string> lista = new List<string>();

            foreach (object obj in ListaBases.CheckedItems)
            {
                string nombre = obj.ToString();
                if (nombre != "Seleccionar todas")
                {
                    MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                    sb.Server = Servidor;
                    sb.UserID = Usuario;
                    sb.Password = Password;
                    sb.Database = nombre;
                    lista.Add(sb.ConnectionString);

                }
            }
            return lista;
        }
        public List<string> getNombres()
        {
            List<string> lista = new List<string>();

            foreach (object obj in ListaBases.CheckedItems)
            {
                string nombre = obj.ToString();
                if (nombre != "Seleccionar todas")
                {
                    lista.Add(nombre);
                }
            }
            return lista;

        }

    }
}
