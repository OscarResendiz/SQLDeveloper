using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorDB.Motores.SQLServer
{
    public partial class FormDlsMultiConfigSqlServer : Form
    {
        private List<string> LBases;
        private System.Data.SqlClient.SqlConnectionStringBuilder ConnectionStringBuilder;
        private System.Data.SqlClient.SqlConnection Conexion;
        private bool BuscandoServidores;
        private string Servidor;
        private string Usuario;
        private string Password;
        private int Autentication;
        private bool GuardarPassword;
        private bool BuscandoBases;
        private bool Errores;
        public FormDlsMultiConfigSqlServer()
        {
            Conexion = new System.Data.SqlClient.SqlConnection();
            BuscandoServidores = false;
            BuscandoBases = false;
            InitializeComponent();
        }
        public string ConnectionString
        {
            get
            {
                return Conexion.ConnectionString;
            }
            set
            {
                System.Data.SqlClient.SqlConnectionStringBuilder csb;
                csb = new System.Data.SqlClient.SqlConnectionStringBuilder(value);
                ComboServidores.Text = csb.DataSource;
                //ComboBases.Text = csb.InitialCatalog;
                TUsuario.Text = csb.UserID;
                TPassword.Text = csb.Password;
                if (csb.IntegratedSecurity)
                    ComboAutentication.SelectedIndex = 0;
                else
                    ComboAutentication.SelectedIndex = 1;
                if (value != null && value != "")
                    Conexion.ConnectionString = value;
                CHContraseña.Checked = csb.PersistSecurityInfo;
            }
        }

        private void ComboServidores_DropDown(object sender, EventArgs e)
        {
            //mando a buscar servidores
            if (BuscandoServidores == false && ComboServidores.Items.Count == 0)
            {
                Cursor = Cursors.WaitCursor;
                ComboServidores.Items.Clear();
                BuscandoServidores = true;
                BKBUscarServidores.RunWorkerAsync();
            }

        }

        private void BKBUscarServidores_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
            System.Data.DataTable dataTable = instance.GetDataSources();
            foreach (DataRow dr in dataTable.Rows)
            {
                //agrego el servidor a la lista
                BKBUscarServidores.ReportProgress(0, dr["ServerName"].ToString());
            }
        }

        private void BKBUscarServidores_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ComboServidores.Items.Add(e.UserState.ToString());
        }

        private void BKBUscarServidores_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            BuscandoServidores = false;
        }

        private void ComboAutentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboAutentication.SelectedIndex)
            {
                case 0:
                    //es autenticacion de windows
                    TUsuario.Enabled = false;
                    TPassword.Enabled = false;
                    CHContraseña.Enabled = false;
                    label5.Enabled = false;
                    label4.Enabled = false;
                    break;
                case 1:
                    //es autenticacion de sql
                    TUsuario.Enabled = true;
                    TPassword.Enabled = true;
                    CHContraseña.Enabled = true;
                    label5.Enabled = true;
                    label4.Enabled = true;
                    break;
            }
        }

        private void BVerBases_Click(object sender, EventArgs e)
        {
            if (BuscandoBases == false)
            {
                Servidor = ComboServidores.Text;
                Usuario = TUsuario.Text;
                Password = TPassword.Text;
                Autentication = ComboAutentication.SelectedIndex;
                GuardarPassword = CHContraseña.Checked;
                ListaBases.Items.Clear();
                ListaBases.Items.Add("Seleccionar todas");
                Cursor = Cursors.WaitCursor;
                BuscandoBases = true;
                BKBuscarBases.RunWorkerAsync();
            }

        }
        private void AbreConexion()
        {
            if (Conexion == null)
            {
                Conexion = new System.Data.SqlClient.SqlConnection(ConnectionStringBuilder.ConnectionString);
            }
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            Conexion.ConnectionString = ConnectionStringBuilder.ConnectionString;
            Conexion.Open();
        }

        private System.Data.SqlClient.SqlDataReader ExecuteReader(string comando)
        {
            AbreConexion();
            System.Data.SqlClient.SqlDataReader dr = null;
            System.Data.SqlClient.SqlCommand SqlCommand1;
            SqlCommand1 = new System.Data.SqlClient.SqlCommand();
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

        private void BKBuscarBases_DoWork(object sender, DoWorkEventArgs e)
        {
            //hay que traer la lista de bases de datos que hay en el servidor
            ConnectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            ConnectionStringBuilder.DataSource = Servidor;
            ConnectionStringBuilder.UserID = Usuario;
            ConnectionStringBuilder.Password = Password;
            ConnectionStringBuilder.PersistSecurityInfo = GuardarPassword;
            if (Autentication == 0)
                ConnectionStringBuilder.IntegratedSecurity = true;
            else
                ConnectionStringBuilder.IntegratedSecurity = false;
            try
            {

                List<string> bases = new List<string>();
                //creo la consulta
                ConnectionStringBuilder.InitialCatalog = "master";
                System.Data.SqlClient.SqlDataReader dr;
                dr = ExecuteReader("SELECT name FROM sysdatabases");
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
            System.Data.SqlClient.SqlConnection con = null;
            try
            {
                System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder();
                sb.DataSource = Servidor;
                sb.UserID = Usuario;
                sb.Password = Password;
                sb.PersistSecurityInfo = GuardarPassword;
                if (Autentication == 0)
                    sb.IntegratedSecurity = true;
                else
                    sb.IntegratedSecurity = false;
                sb.InitialCatalog = nombre;
                string ConnectionString = sb.ConnectionString;
                con = new System.Data.SqlClient.SqlConnection(ConnectionString);
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

        private void BAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        public List<string> GetConnexciones()
        {
            List<string> lista = new List<string>();

            foreach (object obj in ListaBases.CheckedItems)
            {
                string nombre = obj.ToString();
                if (nombre!= "Seleccionar todas")
                {
                    System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder();
                    sb.DataSource = Servidor;
                    sb.UserID = Usuario;
                    sb.Password = Password;
                    sb.PersistSecurityInfo = GuardarPassword;
                    if (Autentication == 0)
                        sb.IntegratedSecurity = true;
                    else
                        sb.IntegratedSecurity = false;
                    sb.InitialCatalog = nombre;
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
   