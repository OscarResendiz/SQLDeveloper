using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
using System.Linq;
using SPGenerator.Objetos;
namespace SPGenerator
{
    public partial class AsisSelValFijos : AsistBaseSP
    {

        private IMotorDB DB;
        public AsisSelValFijos(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            string tabla = DatosAsistente.Tabla.Nombre; 
            ListaCampos.Items.Clear();
            ListaParametros.Items.Clear();
            MuestraCampos();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            bool ok = true;
            EnableAnterior(true);
            EnableSiguiente(ok);
            ok = true;
            if (ListaCampos.SelectedIndices.Count == 0)
                ok = false;
            BAgregar.Enabled = ok;
            ok = true;
            if (ListaParametros.SelectedIndices.Count == 0)
                ok = false;
            BQuitar.Enabled = ok;

        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            foreach (CCampo c in ListaCampos.SelectedItems)
            {
                CParametroSP p = new CParametroSP()
                {
                    nombre = c.Nombre,
                    Logitud = c.Longitud,
                    tipo = c.TipoDato.ToString()
                };
                ListaParametros.Items.Add(p);

            }
            MuestraCampos();
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            int i, n, pos;
            n = ListaParametros.SelectedIndices.Count;
            //elimino la lista de campos seleccionados
            for (i = n - 1; i >= 0; i--)
            {
                pos = ListaParametros.SelectedIndices[i];
                ListaParametros.Items.RemoveAt(pos);
            }
            MuestraCampos();
        }

        private void ListaParametros_DoubleClick(object sender, EventArgs e)
        {
            if(ListaParametros.SelectedIndex==-1)
                return;
            CParametroSP obj;
            obj=(CParametroSP)ListaParametros.Items[ListaParametros.SelectedIndex];
            FormPropValFijos dlg = new FormPropValFijos(DB,DatosAsistente.Parametros);
            dlg.Nombre = obj.nombre;
            dlg.Tipo = obj.tipo;
            dlg.SelectedValor = obj.SelectedValor;
            dlg.Valor = obj.Valor;
            dlg.SelectedRBTabla = !obj.SelectedValor;
            dlg.Tabla = obj.Tabla;
            dlg.Filtros = obj.Filtros;
            dlg.Campo = obj.Campo;
            dlg.Ordenamientos = obj.Ordenamientos;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            //regreso los valores
            obj.nombre = dlg.Nombre;
            obj.tipo = dlg.Tipo;
            obj.SelectedValor = dlg.SelectedValor;
            obj.Valor = dlg.Valor;
            obj.Tabla = dlg.Tabla;
            obj.Filtros = dlg.Filtros;
            obj.Campo = dlg.Campo;
            obj.Ordenamientos = dlg.Ordenamientos;
        }
        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                Siguiente = new AsisForeigKeys(DB);
                Siguiente.Anterior = this;
            }
            //guardo mis datos
            List<CParametroSP> lista = new List<CParametroSP>();
            foreach (CParametroSP obj in ListaParametros.Items)
            {
                lista.Add(obj);
            }
            DatosAsistente.ValoresFijos = lista;
            OnInstalame(Siguiente);
        }
        private void MuestraCampos()
        {
            ListaCampos.Items.Clear();
            //me traigo la lista de campos de la tabla
            List<CCampo> campos = DatosAsistente.Tabla.Campos;
            List<CParametroSP> parametros = DatosAsistente.Parametros;
            //me traigo los campos que no estan en los parametros
            var l = (from c in campos where !(from p in parametros select p.nombre).Contains(c.Nombre) select c).ToList();
            List<CParametroSP> ValoresFijos = new List<CParametroSP>();
            foreach(CParametroSP obj in ListaParametros.Items)
            {
                ValoresFijos.Add(obj);
            }
            var l2 = (from c in l where !(from p in ValoresFijos select p.nombre).Contains(c.Nombre) select c);

            foreach (var c in l2)
            {
                ListaCampos.Items.Add(c);
            }

        }
    }
}

