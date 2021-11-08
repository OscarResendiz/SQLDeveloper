using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorDB
{
     partial class FormDlgConfigSqlServer : Form
    {
        private System.Data.SqlClient.SqlConnectionStringBuilder ConnectionStringBuilder;
        private bool BuscandoServidores;
        private bool BuscandoBases;
        private System.Data.SqlClient.SqlConnection Conexion;

        private string Servidor;
        private string Usuario;
        private string Password;
        private int Autentication;
        private bool GuardarPassword;


        public FormDlgConfigSqlServer()
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
                ComboBases.Text = csb.InitialCatalog;
                TUsuario.Text = csb.UserID;
                TPassword.Text = csb.Password;
                if (csb.IntegratedSecurity)
                    ComboAutentication.SelectedIndex = 0;
                else
                    ComboAutentication.SelectedIndex = 1;
                Conexion.ConnectionString = value;
                CHContraseña.Checked = csb.PersistSecurityInfo;
            }
        }

        private void ComboServidores_DropDown(object sender, EventArgs e)
        {
            //mando a buscar servidores
            if (BuscandoServidores == false && ComboServidores.Items.Count==0)
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
        public string ConnectioName
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text = value;
            }
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

        private void ComboBases_DropDown(object sender, EventArgs e)
        {
            if (BuscandoBases == false)
            {
                Servidor = ComboServidores.Text;
                Usuario = TUsuario.Text;
                Password = TPassword.Text;
                Autentication = ComboAutentication.SelectedIndex;
                GuardarPassword = CHContraseña.Checked;
                ComboBases.Items.Clear();
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
            ConnectionStringBuilder.Password= Password;
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
            if(e.ProgressPercentage==-1)
            {
                MessageBox.Show(e.UserState.ToString(), "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ComboBases.Items.Add(e.UserState.ToString());
        }

        private void BKBuscarBases_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            BuscandoBases = false;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sb = new System.Data.SqlClient.SqlConnectionStringBuilder();
            sb.DataSource = ComboServidores.Text;
            sb.UserID = TUsuario.Text;
            sb.Password = TPassword.Text;
            sb.PersistSecurityInfo = CHContraseña.Checked;
            if (ComboAutentication.SelectedIndex == 0)
                sb.IntegratedSecurity = true;
            else
                sb.IntegratedSecurity = false;
            sb.InitialCatalog = ComboBases.Text;
            ConnectionString = sb.ConnectionString;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormDlgConfigSqlServer_Load(object sender, EventArgs e)
        {
        }

        private void TimerValidador_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (TNombre.Text.Trim() == "")
            {
                ok = false;
            }
            if (ComboServidores.Text.Trim() == "")
            {
                ok = false;
            }
            if (ComboAutentication.SelectedIndex == 1)
            {
                if (TUsuario.Text.Trim() == "")
                {
                    ok = false;
                }
                if (TPassword.Text.Trim() == "")
                {
                    ok = false;
                }
            }
            if (ComboBases.Text.Trim() == "")
            {
                ok = false;
            }
            BAceptar.Enabled = ok;
        }

        private void ComboBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBases.SelectedIndex == -1)
                return;
            if (TNombre.Text.Trim() != "")
                return;
            TNombre.Text = ComboBases.Items[ComboBases.SelectedIndex].ToString();
        }
    }
}
