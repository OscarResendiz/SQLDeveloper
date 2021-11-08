using ManagerConnect;
using Modelador.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelador.UI
{
    public partial class FormBuscadorTablas : Form
    {
        public ModeloDatos Modelo
        {
            get;
            set;
        }
        private bool MultiSelect;
        List<Modelo.CTabla> Lista;
        public FormBuscadorTablas(bool multiselect=false)
        {
            MultiSelect = multiselect;
            InitializeComponent();
            if (multiselect)
            {
                ListaObjetos.SelectionMode = SelectionMode.MultiExtended;
            }
            else
            {
                ListaObjetos.SelectionMode = SelectionMode.One;
            }
        }

        private void FormBuscadorTablas_Load(object sender, EventArgs e)
        {
            //me traigo todas las tablas de la base de datos
            Lista = Modelo.Get_Tablas();
            MuestraFiltro();
        }
        private void MuestraFiltro()
        {
            //Muestra las tablas que coincidan con el filtro
            ListaObjetos.Items.Clear();
            string filtro = TNombre.Text;
            foreach(Modelo.CTabla obj in Lista)
            {
                if(obj.Nombre.ToUpper().Contains(filtro.ToUpper()))
                {
                    ListaObjetos.Items.Add(obj.Nombre);
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(ListaObjetos.SelectedItems.Count==0)
            {
                MessageBox.Show("No ha seleccionado ninguna tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        public string Tabla
        {
            get
            {
                return ListaObjetos.SelectedItem.ToString();
            }
        }
        public List<string> Tablas
        {
            get
            {
                List<string> l = new List<string>();
                foreach(string s in ListaObjetos.SelectedItems)
                {
                    l.Add(s);
                }
                return l;
            }
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            MuestraFiltro();
        }
    }
}
