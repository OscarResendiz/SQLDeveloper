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
    public partial class FormPropiedadesScript : Form
    {
        ObjetosModelo.AppModel Modelo;
        public FormPropiedadesScript(ObjetosModelo.AppModel modelo)
        {
            Modelo = modelo;
            InitializeComponent();
            CargaGrupos();
        }
        private void CargaGrupos()
        {

            List<ObjetosModelo.CServidor> l = Modelo.GetServidores();
            ComboGrupo.Items.Clear();
            foreach (ObjetosModelo.CServidor s in l)
            {
                ComboGrupo.Items.Add(s);
            }
        }

        private void ComboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGrupo.SelectedIndex == -1)
                return;
            ObjetosModelo.CServidor servidor = (ObjetosModelo.CServidor)ComboGrupo.SelectedItem;
            List<ObjetosModelo.CConexion> l = Modelo.GetConexiones(servidor.ID_Servidor);
            ComboConexion.Items.Clear();
            foreach (ObjetosModelo.CConexion obj in l)
            {
                ComboConexion.Items.Add(obj);
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if(TNombre.Text.Trim()=="")
            {
                ok = false;
            }
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
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        public ObjetosModelo.CConexion Conexion
        {
            get
            {
                return (ObjetosModelo.CConexion)ComboConexion.SelectedItem;
            }
            set
            {
                foreach(ObjetosModelo.CServidor obj in ComboGrupo.Items)
                {
                    if(obj.ID_Servidor==value.ID_Servidor)
                    {
                        ComboGrupo.SelectedItem = obj;
                        break;
                    }
                }
                foreach(ObjetosModelo.CConexion con in ComboConexion.Items)
                {
                    if(con.ID_Conexion==value.ID_Conexion)
                    {
                        ComboConexion.SelectedItem = con;
                        break;
                    }
                }
                
            }
        }
        public string Nombre
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
    }
}
   