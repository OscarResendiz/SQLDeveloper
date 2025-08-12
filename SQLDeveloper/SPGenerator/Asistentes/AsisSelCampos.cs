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
    public partial class AsisSelCampos : AsistBaseSP
    {
        bool ControlKey;
        private string Tabla;
        private IMotorDB DB;
        public AsisSelCampos(IMotorDB db)
        {
            DB = db;
            Tabla = "";
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            bool ok = true;
            if (ListaParametros.Items.Count == 0)
                ok = false;
            if (CHTop.Checked == true)
            {
                if (TTop.Text.Trim() == "")
                    ok = false;
            }
            EnableAnterior(true);
            EnableSiguiente(ok);
            TTop.ReadOnly = !CHTop.Checked;
        }
        public override void Inicializate()
        {
            string tabla = DatosAsistente.Tabla.Nombre;// (string)DameValor("Tabla");
            if (Tabla == tabla)
            {
                //no nececito actualizar nada
                return;
            }
            Tabla = tabla;
            //cambio el nombre de la tabla, por lo que actualizo mis listas
            ListaCampos.Items.Clear();
            ListaParametros.Items.Clear();
            //me traigo la lista de campos de la tabla
            List<CCampo> campos = DB.DameCamposTabla(Tabla);
            foreach (CCampo obj in campos)
            {
                CParametroSP obj2 = new CParametroSP()
                {
                    Logitud = obj.Longitud,
                    nombre = obj.Nombre,
                    tipo = obj.TipoDato.Nombre
                };
                ListaCampos.Items.Add(obj2);
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

        private void TTop_KeyDown(object sender, KeyEventArgs e)
        {
            ControlKey=e.Control;
        }

        private void TTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ControlKey == true)
                return;
            if (e.KeyChar == '\b')
                return;
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }

        private void ListaParametros_DoubleClick(object sender, EventArgs e)
        {
            if (ListaParametros.SelectedIndex == -1)
                return;
            CParametroSP obj = (CParametroSP)ListaParametros.Items[ListaParametros.SelectedIndex];
            FormPropCampo dlg = new FormPropCampo();
            dlg.Nombre = obj.nombre;
            dlg.Tipo = obj.tipo;
            dlg.Comentario = obj.Descripcion;
            dlg.EnableAlias = obj.EnableAlias;
            dlg.Alias = obj.Alias;
            dlg.Sum = obj.Sum;
            dlg.EnableCase = obj.EnableCase;
            dlg.Casos = obj.Casos;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            obj.nombre = dlg.Nombre;
            obj.tipo=dlg.Tipo;
            obj.Descripcion = dlg.Comentario;
            obj.EnableAlias = dlg.EnableAlias;
            obj.Alias = dlg.Alias;
            obj.Sum = dlg.Sum;
            obj.EnableCase = dlg.EnableCase;
            obj.Casos = dlg.Casos;
        }
        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                Siguiente = new AsisOrdenamiento(DB);
                Siguiente.Anterior = this;
            }
            //guardo mi informacion
            List<CParametroSP> lista = new List<CParametroSP>();
            foreach (CParametroSP obj in ListaParametros.Items)
            {
                lista.Add(obj);
            }
            DatosAsistente.CamposSelect = lista;
            //AsignaValor("Campos", lista);
            DatosAsistente.ActivarDistinct = CHDstinct.Checked;
            //AsignaValor("ActivarDistinct", CHDstinct.Checked);
            DatosAsistente.AtcivarTop = CHTop.Checked;
            //AsignaValor("AtcivarTop", CHTop.Checked);
            DatosAsistente.Top = TTop.Text;
            //AsignaValor("Top", TTop.Text);
            OnInstalame(Siguiente);
            
        }
    }
}

