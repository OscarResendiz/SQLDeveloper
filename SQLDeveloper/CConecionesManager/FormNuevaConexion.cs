using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;

namespace ManagerConnect
{
    public partial class FormNuevaConexion : Form
    {
        public FormNuevaConexion()
        {
            InitializeComponent();
        }

        private void FormNuevaConexion_Load(object sender, EventArgs e)
        {
            List<string> l = ControladorConexiones.GetGrupos();
            ComboGrupo.Items.Clear();
            foreach (string s in l)
            {
                ComboGrupo.Items.Add(s);
            }
            ComboMotor.Items.Add(EnumMotoresDB.SQLSERVER.ToString());
            ComboMotor.Items.Add(EnumMotoresDB.MYSQL.ToString());
            ComboMotor.Items.Add(EnumMotoresDB.POSTGRES.ToString());
        }

        private void ComboMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboMotor.SelectedIndex == -1)
                BConfig.Enabled = false;
            else
                BConfig.Enabled = true;
        }
        public CConexion Conexion
        {
            get;
            set;
        }
        private void BConfig_Click(object sender, EventArgs e)
        {
            EnumMotoresDB tipo=            ControladorConexiones.DameTipoMotor(ComboMotor.SelectedItem.ToString());
            IMotorDB motor=CProviderDataBase.DameMotor(tipo);
            if (motor.ShowDlgConfig() != System.Windows.Forms.DialogResult.OK)
                return;
            Conexion = new CConexion();
            Conexion.Nombre = motor.GetConnectionName();
            Conexion.MotorDB = tipo.ToString();
            Conexion.ConecctionString = motor.GetConecctionString();
            TNombre.Text = Conexion.Nombre;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(ComboGrupo.Text.Trim()=="")
            {
                MessageBox.Show(ComboGrupo.Tag.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if(ComboMotor.SelectedItem==null)
            {
                MessageBox.Show(ComboMotor.Tag.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if(TNombre.Text.Trim()=="")
            {
                MessageBox.Show("Falta configurar la conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
        }
        public string Grupo
        {
            get
            {
                return ComboGrupo.Text;
            }
        }
    }
}
