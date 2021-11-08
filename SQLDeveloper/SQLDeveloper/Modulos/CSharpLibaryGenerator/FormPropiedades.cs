using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public partial class FormPropiedades : Form
    {
        ModeloNet Modelo;
        public FormPropiedades(ModeloNet modelo)
        {
            Modelo = modelo;
            InitializeComponent();
        }
        public string NombreLibreria
        {
            get
            {
                return Modelo.ProjectName;
            }
            set
            {
                Modelo.ProjectName = value;
            }
        }
        public string RutaDestino
        {
            get
            {
                return Modelo.DirectorioDestino;
            }
            set
            {
                Modelo.DirectorioDestino = value;
            }
        }
        public string TipoLibreria
        {
            get
            {
                return Modelo.TipoLibreria;
            }
            set
            {
                Modelo.TipoLibreria = value;
            }
        }
        private void FormPropiedades_Load(object sender, EventArgs e)
        {
            ComboSalida.Items.Clear();
            List<string> l = Modelo.DameListaGeneradores();
            foreach(string s in l)
            {
                ComboSalida.Items.Add(s);
            }
            TNombre.Text = NombreLibreria;
            TDirectorio.Text = RutaDestino;
            ComboSalida.SelectedItem = TipoLibreria;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            NombreLibreria=TNombre.Text ;
            RutaDestino=TDirectorio.Text ;
            TipoLibreria=ComboSalida.SelectedItem.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BCarpeta_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            TDirectorio.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
