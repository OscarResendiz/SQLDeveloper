using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
using SPGenerator.Objetos;
namespace SPGenerator
{
    public partial class FormPropFkDelete : Form
    {
        IMotorDB DB;
        CLLaveForanea FK;
        public FormPropFkDelete(IMotorDB db, CLLaveForanea fk)
        {
            DB = db;
            FK= fk;
            InitializeComponent();          
        }

        private void FormPropFkDelete_Load(object sender, EventArgs e)
        {
            //cargo los datos para mostralos
            TNombre.Text = FK.Nombre;
            //RBEliminar.Checked = FK.Eliminar;
            TBExcepcion.Checked = FK.GenerarExcepcion;            
            TError.Text = FK.Mensage;
            //System.Collections.Generic.List<CCampoFK> lista = DB.DameCamposFK(FK.name);
            TTablaPadre.Text = FK.TablaHija;// lista[0].hija;
            FK.TablaPadre = TTablaPadre.Text;
            if (FK.Hijas != null)
            {
                //muestro las llaves foraneas hijas
                foreach (CLLaveForanea obj in FK.Hijas)
                {
                    ListaParametros.Items.Add(obj);
                }
            }
            //me traigo la lista de llaves foraneas hijas
            List<CForeignKey> lista2 = DB.DameLLavesForaneasHijas(TTablaPadre.Text);
            foreach (CForeignKey obj in lista2)
            {
                bool encontrado = false;
                foreach (CForeignKey obj2 in ListaParametros.Items)
                {
                    if (obj.Nombre == obj2.Nombre)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    CLLaveForanea obj2 = new CLLaveForanea()
                    {
                        TablaHija = obj.TablaHija,
                        AccionActualizar = obj.AccionActualizar,
                        AccionBorrar = obj.AccionBorrar,
                        Campos = obj.Campos,
                        Comentarios = obj.Comentarios,
                        GenerarExcepcion = obj.GenerarExcepcion,
                        Mensage = obj.Mensage,
                        Nombre = obj.Nombre,
                        TablaPadre = obj.TablaPadre,
                        Tipo = obj.Tipo

                    };
                    ListaCampos.Items.Add(obj2);
                }
            }
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            int i, n, pos;
            n = ListaCampos.SelectedIndices.Count;
            //agrego los campos ala lista de parametros
            for (i = 0; i < n; i++)
            {
                pos = ListaCampos.SelectedIndices[i];
                ListaParametros.Items.Add(ListaCampos.Items[pos]);
            }
            //elimino la lista de campos seleccionados
            for (i = n - 1; i >= 0; i--)
            {
                pos = ListaCampos.SelectedIndices[i];
                ListaCampos.Items.RemoveAt(pos);
            }

        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            int i, n, pos;
            n = ListaParametros.SelectedIndices.Count;
            //agrego los campos ala lista de parametros
            for (i = 0; i < n; i++)
            {
                pos = ListaParametros.SelectedIndices[i];
                ListaCampos.Items.Add(ListaParametros.Items[pos]);
            }
            //elimino la lista de campos seleccionados
            for (i = n - 1; i >= 0; i--)
            {
                pos = ListaParametros.SelectedIndices[i];
                ListaParametros.Items.RemoveAt(pos);
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            //asigno las llaves foraneas hijas a la principal
            FK.Hijas = new List<CLLaveForanea>();
            foreach(CLLaveForanea obj in ListaParametros.Items)
            {
                FK.Hijas.Add(obj);
            }
            FK.Eliminar = RBEliminar.Checked;
            FK.GenerarExcepcion = TBExcepcion.Checked;
            FK.Mensage = TError.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok=true;
            if (TBExcepcion.Checked == true)
            {
                TError.Enabled = true;
                if (TError.Text.Trim() == "")
                {
                    ok = false;
                }
            }
            else
            {
                TError.Enabled = false;
            }
            BAceptar.Enabled = ok;
            ok = true;
            if (ListaCampos.SelectedIndex == -1)
            {
                ok = false;
            }
            if (TBExcepcion.Checked == true)
                ok = false;
            BAgregar.Enabled = ok;
            ok = true;
            if (ListaParametros.SelectedIndex == -1)
            {
                ok = false;
            }
            BQuitar.Enabled = ok;
        }

        private void ListaParametros_DoubleClick(object sender, EventArgs e)
        {
            if (ListaParametros.SelectedIndex == -1)
                return;
            CLLaveForanea obj = (CLLaveForanea)ListaParametros.Items[ListaParametros.SelectedIndex];
            FormPropFkDelete dlg2 = new FormPropFkDelete(DB, obj);
            if (dlg2.ShowDialog() == DialogResult.Cancel)
                return;
        }
    }
}