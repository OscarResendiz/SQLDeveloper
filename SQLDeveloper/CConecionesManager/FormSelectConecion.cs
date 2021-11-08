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
    public partial class FormSelectConecion : Form 
    {

        private CConexion Conexion;
        public event OnFormConexionInicialEvent OnConexion;
        public FormSelectConecion()
        {
            InitializeComponent();
        }
        private void ComboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGrupo.SelectedIndex == -1)
                return;
            List<CConexion> l = ControladorConexiones.GetConexiones(ComboGrupo.SelectedItem.ToString());
            ComboConexion.Items.Clear();
            foreach (CConexion obj in l)
            {
                ComboConexion.Items.Add(obj);
            }
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (ComboGrupo.SelectedIndex == -1)
            {
                ok = false;
            }
            if (ComboConexion.SelectedIndex == -1)
            {
                ok = false;
            }
            if (ok == false)
            {
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            if (OnConexion != null)
                OnConexion(ComboGrupo.SelectedItem.ToString(), (CConexion)ComboConexion.SelectedItem);

        }
        private void BNuevo_Click(object sender, EventArgs e)
        {
            FormNuevaConexion dlg = new FormNuevaConexion();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Conexion = dlg.Conexion;
            string nombregrupo = dlg.Grupo;
            bool encontrado = false;
            //veo si el grupo ya existe
            foreach (string s in ComboGrupo.Items)
            {
                if (s.ToLower().Trim() == nombregrupo.ToLower().Trim())
                {
                    ComboGrupo.SelectedItem = nombregrupo;
                    encontrado = true;
                    break;
                }
            }
            if (encontrado == false)
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

            foreach (CConexion con in ComboConexion.Items)
            {
                if (con.Nombre == Conexion.Nombre)
                {
                    ComboConexion.SelectedItem = con;
                }
            }

        }
        private void CargaGrupos()
        {
            List<string> l = ControladorConexiones.GetGrupos();
            ComboGrupo.Items.Clear();
            foreach (string s in l)
            {
                ComboGrupo.Items.Add(s);
            }
        }
        private void FormSelectConecion_Load(object sender, EventArgs e)
        {
            CargaGrupos();
        }

    }
}
