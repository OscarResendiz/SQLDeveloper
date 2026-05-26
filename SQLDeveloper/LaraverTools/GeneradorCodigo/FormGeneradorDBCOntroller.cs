using Laravel;
using MotorDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaraverTools.GeneradorCodigo
{
    public partial class FormGeneradorDBCOntroller : Form
    {
        GeneradorCodigoDBController controller;
        public string Codigo
        {
            get;
            set;
        }
        public MotorDB.IMotorDB Motor
        {
            get; set; 
        }
        public FormGeneradorDBCOntroller()
        {
            InitializeComponent();
        }
        private void Agrega(string sp)
        {
            foreach (string s in listBox1.Items)
            {
                if (sp.ToUpper().Trim() == s.ToUpper().Trim())
                    return;
            }

            List<CObjeto> lista = Motor.Buscar(sp, EnumTipoObjeto.PROCEDURE);
            if (lista.Count == 0)
            {
                MessageBox.Show("No se encontro el procediiento almacenado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CObjeto obj = lista.First();
            listBox1.Items.Add(obj.Nombre);

        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text.Trim() == "")
            {
                MessageBox.Show("Falta el nombre del SP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] l = textBoxNombre.Text.Split('\t');
            foreach (string s in l)
            {
                Agrega(s);
            }
            textBoxNombre.Text = "";
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;
            if (listBox1.SelectedItem == null)
                return;
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if(Clase.Trim()=="")
            {
                MessageBox.Show("Falta el nombre de la clase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(listBox1.Items.Count==0)
            {
                MessageBox.Show("La lista esta vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            controller = new GeneradorCodigoDBController();
            controller.MotorDB = Motor;
            controller.NombreController = Clase;
            controller.NameSpace = textBoxNameSpace.Text;
            foreach(string s in listBox1.Items)
            {
                controller.Add(s);
            }
            Codigo = controller.GeneraCodigo();
            DialogResult= DialogResult.OK;
            Close();
        }
        public string Clase
        {
            get
            {
                string s = "";
                if (!textBoxClase.Text.Contains("DB"))
                    s = "DB";
                s = s + textBoxClase.Text.Substring(0, 1).ToUpper() + textBoxClase.Text.Substring(1);
                if (!textBoxClase.Text.Contains("Controller"))
                    s =s+ "Controller";
                return s;
            }
        }
    }
}
