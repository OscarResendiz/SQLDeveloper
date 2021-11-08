using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Herramientas.GestorBloques
{
    public partial class FormConfigBloques : Form
    {
        public FormConfigBloques()
        {
            InitializeComponent();
        }
        private DataTable Tabla
        {
            get
            {
                return dataSet1.Tables["Bloques"];
            }
        }
        private void BAgregar_Click(object sender, EventArgs e)
        {
            FormDetalleBloque dlg = new FormDetalleBloque();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            DataRow dr = Tabla.NewRow();
            dr["Nombre"]=dlg.Nombre;
            dr["InicioMatch"]=dlg.InicioMatch;
            dr["FinMatch"]=dlg.FinMatch;
            dr["TextoRemplazo"]=dlg.TextoRemplazo;
            dr["UseTextLine"]=dlg.UseTextLine;
            dr["MinimumLength"]=dlg.MinimumLength;
            dr["ApliaTabulador"] = dlg.ApliaTabulador;
            Tabla.Rows.Add(dr);
        }
        private DataRow SelectedRown
        {
            get
            {
                if (Lista.SelectedIndex == -1)
                    return null;
                return Tabla.Rows[Lista.SelectedIndex];
            }
        }
        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (SelectedRown == null)
                return;
            if (MessageBox.Show("Eliminar el registro seleccionado", "Elminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            Tabla.Rows.Remove(SelectedRown);
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            FormDetalleBloque dlg = new FormDetalleBloque();
            DataRow dr = SelectedRown;
            dlg.Nombre=dr["Nombre"].ToString()  ;
            dlg.InicioMatch = dr["InicioMatch"].ToString();
            dlg.FinMatch = dr["FinMatch"].ToString();
            dlg.TextoRemplazo = dr["TextoRemplazo"].ToString();
            dlg.UseTextLine =bool.Parse( dr["UseTextLine"].ToString());
            dlg.MinimumLength =int.Parse( dr["MinimumLength"].ToString());
            dlg.ApliaTabulador =bool.Parse( dr["ApliaTabulador"].ToString());
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            dr["Nombre"] = dlg.Nombre;
            dr["InicioMatch"] = dlg.InicioMatch;
            dr["FinMatch"] = dlg.FinMatch;
            dr["TextoRemplazo"] = dlg.TextoRemplazo;
            dr["UseTextLine"] = dlg.UseTextLine;
            dr["MinimumLength"] = dlg.MinimumLength;
            dr["ApliaTabulador"] = dlg.ApliaTabulador;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet1.WriteXml(NombreArchivo);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private string NombreArchivo
        {
            get
            {
                return Application.StartupPath + "\\Colores\\bloques.xml";
            }
        }
        private void FormConfigBloques_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(NombreArchivo) == false)
                return;
            dataSet1.ReadXml(NombreArchivo);
        }
    }
}
