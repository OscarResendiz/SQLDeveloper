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
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class FormEditorRegla : Form
    {
        CTabla Tabla;
        string NombreTabla;
        public FormEditorRegla(CTabla tabla)            
        {
            Tabla = tabla;
            NombreTabla = tabla.Nombre;
            InitializeComponent();
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            FormEditorCondicion dlg = new FormEditorCondicion(Tabla);
            if (ListaCondiciones.Items.Count == 0)
                dlg.Primero = true;
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            ListaCondiciones.Items.Add(dlg.Resultado);
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            if(ListaCondiciones.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione el lemento a eliminar","Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListaCondiciones.Items.RemoveAt(ListaCondiciones.SelectedIndex);
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(ListaCondiciones.Items.Count==0)
            {
                MessageBox.Show("No hay condiciones agregadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;

            }
        }
        public string CadenaResult
        {
            get
            {
                string s = "";
                foreach(string s2 in ListaCondiciones.Items)
                {
                    s += " " + s2;
                }
                return s;
            }
        }
    }
}
