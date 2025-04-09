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
    public partial class FormDlgConfigMySql : Form
    {
        private MySqlConnectionStringBuilder ConnectionStringBuilder;
        private MySqlConnection Conexion = null;
        public FormDlgConfigMySql()
        {
            InitializeComponent();
            ConnectionStringBuilder = new MySqlConnectionStringBuilder();
            Conexion = new MySqlConnection();  

        }

        private void ComboBases_DropDown(object sender, EventArgs e)
        {
            //hay que buscar los servidores de sql que esten al alcance
            ConnectionStringBuilder.Server = ComboServidores.Text;
            ConnectionStringBuilder.UserID = TUsuario.Text;
            ConnectionStringBuilder.Password = TPassword.Text;
            Cursor = Cursors.WaitCursor;
            try
            {
                AbreConexion();

                List<string> servidores = GetDataBases();
                ComboBases.Items.Clear();
                foreach (string s in servidores)
                {
                    ComboBases.Items.Add(s);
                }
                Cursor = Cursors.Default;
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }
        private void AbreConexion()
        {
//            if (isExecuting)
  //              return;
            if (Conexion != null)
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
            else
            {
                Conexion = new MySqlConnection();
            }
            Conexion.ConnectionString = ConnectionStringBuilder.ConnectionString;
            Conexion.Open();
        }
        public List<string> GetDataBases()
        {
            //por ahorita no hace nada, pero hay que ver la forma de implementarlo
            List<string> l = new List<string>();
            //regresa la lista de bases de datos que hay en el servidor
            try
            {
                AbreConexion();
                MySqlDataReader data = null;
                MySqlCommand query = new MySqlCommand("show databases", Conexion);
                data = query.ExecuteReader();
                while (data.Read() != false)
                {
                    l.Add(data["Database"].ToString());
                }
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return l;
            }
            Conexion.Close();
            return l;
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
                ComboServidores.Text = csb.Server;
                ComboBases.Text = csb.Database;
                TUsuario.Text = csb.UserID;
                TPassword.Text = csb.Password;
                Conexion.ConnectionString = value;
            }
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

        private void BAceptar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = ComboServidores.Text;
            sb.UserID = TUsuario.Text;
            sb.Password = TPassword.Text;
            sb.Database= ComboBases.Text;
            sb.PersistSecurityInfo = true;
            ConnectionString = sb.ConnectionString;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void BtnVer_Click(object sender, EventArgs e)
        {
            if (TPassword.PasswordChar == '*')
                TPassword.PasswordChar = '\0';
            else
                TPassword.PasswordChar = '*';

        }
    }
}
