using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace MotorDB.Motores.PostgreSql
{
    public partial class FormDlgConfigPostgress : Form
    {
        private NpgsqlConnectionStringBuilder ConnectionStringBuilder;
        private NpgsqlConnection Conexion = null;

        public FormDlgConfigPostgress()
        {
            InitializeComponent();
            ConnectionStringBuilder = new NpgsqlConnectionStringBuilder();
            Conexion = new NpgsqlConnection();
        }
        private void AbreConexion()
        {
            if (Conexion != null)
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
            else
            {
                Conexion = new NpgsqlConnection();
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
                NpgsqlDataReader data = null;
                NpgsqlCommand query = new NpgsqlCommand("SELECT datname FROM pg_database", Conexion);
                data = query.ExecuteReader();
                while (data.Read() != false)
                {
                    l.Add(data["datname"].ToString());
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
                NpgsqlConnectionStringBuilder csb;
                csb = new NpgsqlConnectionStringBuilder(value);
                ComboServidores.Text = csb.Host;
                ComboBases.Text = csb.Database;
                TUsuario.Text = csb.Username;
                TPassword.Text = csb.Password;
                if(value!="")
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
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = ComboServidores.Text;
            sb.Username = TUsuario.Text;
            sb.Password = TPassword.Text;
            sb.Database = ComboBases.Text;
            sb.PersistSecurityInfo = true;
            ConnectionString = sb.ConnectionString;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void ComboBases_DropDown(object sender, EventArgs e)
        {
            try
            {
                //hay que buscar los servidores de sql que esten al alcance
                ConnectionStringBuilder.Host = ComboServidores.Text;
                ConnectionStringBuilder.Username = TUsuario.Text;
                ConnectionStringBuilder.Password = TPassword.Text;
                Cursor = Cursors.WaitCursor;
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

        private void ComboBases_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
