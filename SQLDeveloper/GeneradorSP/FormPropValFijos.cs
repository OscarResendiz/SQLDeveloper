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
    public partial class FormPropValFijos : Form
    {
        private IMotorDB DB;
        public FormPropValFijos(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
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
        public string Tipo
        {
            get
            {
                return TTipo.Text;
            }
            set
            {
                TTipo.Text = value;
            }
        }
        public bool SelectedValor
        {
            get
            {
                return RBValor.Checked;
            }
            set
            {
                RBValor.Checked = value;
                TValor.Enabled = value;
                TTabla.Enabled = !value;
            }
        }
        public string Valor
        {
            get
            {
                return TValor.Text; 
            }
            set
            {
                TValor.Text = value;
            }
        }
        public bool SelectedRBTabla
        {
            get
            {
                return RBTabla.Checked;
            }
            set
            {
                RBTabla.Checked = value;
                TValor.Enabled = !value;
                TTabla.Enabled = value;
            }
        }
        public string Tabla
        {
            get
            {
                return TTabla.Text;
            }
            set
            {
                TTabla.Text = value;
            }
        }
        public List<Objetos.CParametro> Filtros
        {
            get
            {
                List<Objetos.CParametro> lista = new List<Objetos.CParametro>();
                foreach (Objetos.CParametro obj in ListaFiltros.Items)
                {
                    lista.Add(obj);
                }
                return lista;
            }
            set
            {
                ListaFiltros.Items.Clear();
                if (value != null)
                {
                    List<Objetos.CParametro> lista = value;
                    foreach (object obj in lista)
                    {
                        ListaFiltros.Items.Add(obj);
                    }
                }
            }
        }
        public string Campo
        {
            get
            {
                if (ComboCampo.SelectedIndex == -1)
                    return "";
                Objetos.CParametro obj = (Objetos.CParametro)ComboCampo.Items[ComboCampo.SelectedIndex];
                return obj.nombre;
            }
            set
            {
                //asigno el nombre del campo de la tabla
                if (ComboCampo.Items.Count == 0)
                {
                    MuestraCamposTabla();
                }
                int i, n;
                n = ComboCampo.Items.Count;
                for (i = 0; i < n; i++)
                {
                    Objetos.CParametro obj;
                    obj=(Objetos.CParametro)ComboCampo.Items[i];
                    if (obj.nombre == value)
                    {
                        ComboCampo.SelectedIndex = i;
                        return;
                    }
                }
                ComboCampo.SelectedIndex = -1;
            }
        }
         private void MuestraCamposTabla()
        {
                    //lleno el combo de los campos de la tabla
            ComboCampo.Items.Clear();
            List<CCampo> lista;
            lista = DB.DameCamposTabla(Tabla);
            foreach (CCampo obj in lista)
            {
                ComboCampo.Items.Add(obj);
                ListaCampos.Items.Add(obj);
            }
        }
        public List<Objetos.CParametro> Ordenamientos
        {
            get
            {
                List<Objetos.CParametro> lista;
                lista = new List<Objetos.CParametro>();
                foreach (Objetos.CParametro obj in ListaOrdenar.Items)
                {
                    lista.Add(obj);
                }
                return lista;
            }
            set
            {
                ListaOrdenar.Items.Clear();
                if (value != null)
                {
                    foreach (object obj in value)
                    {
                        ListaOrdenar.Items.Add(obj);
                    }
                }
                MuestraListaCampos2();
            }
        }
        private void MuestraListaCampos2()
        {
            //se trae la lista de campos de la tabla y solo agrega los que no estan en la lista de filtros
            ListaCampo2.Items.Clear();
            List<CCampo> lista = DB.DameCamposTabla(Tabla);
            foreach (CCampo obj in lista)
            {
                bool encontrado=false;
                foreach (Objetos.CParametro obj2 in ListaOrdenar.Items)
                {
                    if (obj.Nombre == obj2.nombre)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                    ListaCampo2.Items.Add(obj);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (RBValor.Checked == true)
            {
                if (TValor.Text.Trim() == "")
                    ok = false;
            }
            if (RBTabla.Checked == true)
            {
                if (TTabla.Text.Trim() == "")
                    ok = false;
                if (ComboCampo.SelectedIndex == -1)
                    ok = false;
            }
            BAceptar.Enabled = ok;
            TValor.Enabled = RBValor.Checked;
            BBuscar.Enabled = RBTabla.Checked;
            BCrear.Enabled = RBTabla.Checked;
            ListaCampos.Enabled = RBTabla.Checked;
            ListaFiltros.Enabled = RBTabla.Checked;
            ok = RBTabla.Checked;
            if (ListaCampos.SelectedIndex == -1)
                ok = false;
            BAgregar.Enabled = ok;
            ok = RBTabla.Checked;
            if (ListaFiltros.SelectedIndex == -1)
                ok = false;
            BQuitar.Enabled = ok;
            ComboCampo.Enabled = RBTabla.Checked;
            ListaCampo2.Enabled = RBTabla.Checked;
            ListaOrdenar.Enabled = RBTabla.Checked;
            ok = RBTabla.Checked;
            if (ListaCampo2.SelectedIndex == -1)
                ok = false;
            BAgregar2.Enabled = ok;
            ok = RBTabla.Checked;
            if (ListaOrdenar.SelectedIndex == -1)
                ok = false;
            BQuitar2.Enabled = ok;
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            ListaFiltros.Items.Add(ListaCampos.Items[ListaCampos.SelectedIndex]);
            ListaCampos.Items.RemoveAt(ListaCampos.SelectedIndex);
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            ListaCampos.Items.Add(ListaFiltros.Items[ListaFiltros.SelectedIndex]);
            ListaFiltros.Items.RemoveAt(ListaFiltros.SelectedIndex);
        }

        private void BAgregar2_Click(object sender, EventArgs e)
        {
            ListaOrdenar.Items.Add(ListaCampo2.Items[ListaCampo2.SelectedIndex]);
            ListaCampo2.Items.RemoveAt(ListaCampo2.SelectedIndex);
        }

        private void BQuitar2_Click(object sender, EventArgs e)
        {
            ListaCampo2.Items.Add(ListaOrdenar.Items[ListaOrdenar.SelectedIndex]);
            ListaOrdenar.Items.RemoveAt(ListaOrdenar.SelectedIndex);
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            FormBuscarTabla dlg = new FormBuscarTabla(DB, EnumTipoObjeto.TABLE);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            TTabla.Text = dlg.Tabla;
            CambioTabla();

        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            CrearTablas.FormCrearTabla dlg = new CrearTablas.FormCrearTabla(DB);
            dlg.ShowDialog();
            TTabla.Text = dlg.NombreTabla;
            CambioTabla();
        }

        private void CambioTabla()
        {
            ListaCampos.Items.Clear();
            ListaFiltros.Items.Clear();
            ComboCampo.Items.Clear();
            ListaCampo2.Items.Clear();
            ListaOrdenar.Items.Clear();
            MuestraCamposTabla();
            MuestraListaCampos2();
        }

        private void ListaFiltros_DoubleClick(object sender, EventArgs e)
        {
            if (ListaFiltros.SelectedIndex == -1)
                return;
            Objetos.CParametro obj = (Objetos.CParametro)ListaFiltros.Items[ListaFiltros.SelectedIndex];
            FormPropFiltro dlg = new FormPropFiltro();
            dlg.Nombre = obj.nombre;
            dlg.Tipo = obj.tipo;
            dlg.Filtro = obj.Filtro;
            dlg.Parametro = obj.Parametro;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            obj.nombre = dlg.Nombre;
            obj.tipo = dlg.Tipo;
            obj.Filtro = dlg.Filtro;
            obj.Parametro = dlg.Parametro;
        }

        private void ListaOrdenar_DoubleClick(object sender, EventArgs e)
        {
            if (ListaOrdenar.SelectedIndex == -1)
                return;
            Objetos.CParametro obj = (Objetos.CParametro)ListaOrdenar.Items[ListaOrdenar.SelectedIndex];
            FormpropOrdenamiento dlg = new FormpropOrdenamiento();
            dlg.Nombre = obj.nombre;
            dlg.Tipo = obj.tipo;
            dlg.Desendente = obj.Descendente;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            obj.nombre = dlg.Nombre;
            obj.tipo = dlg.Tipo;
            obj.Descendente = dlg.Desendente;
        }
    }
}