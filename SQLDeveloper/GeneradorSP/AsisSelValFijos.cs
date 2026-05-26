using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
namespace GeneradorSP
{
    public partial class AsisSelValFijos : AsistBaseSP
    {
        IGeneradorCodigo GeneradorCodigo;

        private string Tabla;
        private IMotorDB DB;
        public AsisSelValFijos(IMotorDB db, IGeneradorCodigo generadorCodigo)
        {
            DB = db;
            InitializeComponent();
            GeneradorCodigo = generadorCodigo;
        }
        public override void Inicializate()
        {
            string tabla = (string)DameValor("Tabla");
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
            List<Objetos.CParametro> lista = (List<Objetos.CParametro>)DameValor("ListaParametros");
            foreach (CCampo obj in campos)
            {
                bool encontrado=false;
                //veo si el campo esta en la lista de parametros
                foreach (Objetos.CParametro p in lista)
                {
                    if (obj.Nombre == p.nombre)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if(encontrado==false)
                    ListaCampos.Items.Add(obj);
            }
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

        private void ListaParametros_DoubleClick(object sender, EventArgs e)
        {
            if(ListaParametros.SelectedIndex==-1)
                return;
            Objetos.CParametro obj;
            obj=(Objetos.CParametro )ListaParametros.Items[ListaParametros.SelectedIndex];
            FormPropValFijos dlg = new FormPropValFijos(DB);
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
                Siguiente = new AsisForeigKeys(DB, GeneradorCodigo);
                Siguiente.Anterior = this;
            }
            //guardo mis datos
            List<Objetos.CParametro> lista = new List<Objetos.CParametro>();
            foreach (Objetos.CParametro obj in ListaParametros.Items)
            {
                lista.Add(obj);
            }

            AsignaValor("AsisSelValFijos", lista);
            OnInstalame(Siguiente);
        }
    }
}

