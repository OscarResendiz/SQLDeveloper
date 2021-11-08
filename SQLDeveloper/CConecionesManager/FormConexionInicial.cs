using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerConnect
{
    public delegate void OnFormConexionInicialEvent(string grupo, CConexion conexion);
    public partial class FormConexionInicial : Form
    {
        private CConexion Conexion;
        public event OnFormConexionInicialEvent OnConexion;
        public FormConexionInicial()
        {
            InitializeComponent();
        }
        private void CargaGrupos()
        {
            List<string> l = ControladorConexiones.GetGrupos();
            ComboGrupo.Items.Clear();
            foreach(string s in l)
            {
                ComboGrupo.Items.Add(s);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormConexionInicial_Load(object sender, EventArgs e)
        {
            bool con = Configuracion.GetBooleanParameter("MostrarDialogConexionInicial");
            if(con==false)
            {
                Close();
                return;
            }
            CargaGrupos();
            string grupo = Configuracion.GetTextParameter("Conexion_Grupo");
            string conexion = Configuracion.GetTextParameter("Conexion_Conexion");
            if (grupo == "" || conexion == "")
                return;
            ComboGrupo.Text = grupo;
            ComboGrupo_SelectedIndexChanged(null, null);
            ComboConexion.Text = conexion;
        }

        private void ComboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGrupo.SelectedIndex == -1)
                return;
            List<CConexion> l = ControladorConexiones.GetConexiones(ComboGrupo.SelectedItem.ToString());
            ComboConexion.Items.Clear();
            foreach(CConexion obj in l)
            {
                ComboConexion.Items.Add(obj);
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if(ComboGrupo.SelectedIndex==-1)
            {
                ok = false;
            }
            if(ComboConexion.SelectedIndex==-1)
            {
                ok = false;
            }
            if (ok == false)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if (OnConexion != null)
                OnConexion(ComboGrupo.SelectedItem.ToString(),(CConexion)ComboConexion.SelectedItem);
            Configuracion.SetTextParameter("Conexion_Grupo", ComboGrupo.Text);
            Configuracion.SetTextParameter("Conexion_Conexion", ComboConexion.Text);
        }
        private void BNuevo_Click(object sender, EventArgs e)
        {
            FormNuevaConexion dlg = new FormNuevaConexion();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Conexion = dlg.Conexion;
            string nombregrupo=dlg.Grupo;
            bool encontrado = false;
            //veo si el grupo ya existe
            foreach(string s in ComboGrupo.Items)
            {
                if(s.ToLower().Trim()==nombregrupo.ToLower().Trim())
                {
                    ComboGrupo.SelectedItem = nombregrupo;
                    encontrado = true;
                    break;
                }
            }
            if(encontrado==false)
            {
                //no esta, por lo que hay que agregarlo
                ControladorConexiones.AddGrupo(nombregrupo);
            }
            //ahora agrego la conexion
            ControladorConexiones.AddConexion(nombregrupo, Conexion.MotorDB, Conexion.Nombre, Conexion.ConecctionString);
            //recargo los grupos
            CargaGrupos();
            ComboGrupo.SelectedItem = nombregrupo;
            //selecciono la conexion
            //ComboGrupo_SelectedIndexChanged(null, null);
            ComboConexion.SelectedItem = Conexion;

            foreach(CConexion con in ComboConexion.Items)
            {
                if(con.Nombre==Conexion.Nombre)
                {
                    ComboConexion.SelectedItem = con;
                }
            }

        }

        private void CHMostrar_CheckedChanged(object sender, EventArgs e)
        {
            Configuracion.SetBooleanParameter("MostrarDialogConexionInicial", !CHMostrar.Checked);
        }
    }
}
