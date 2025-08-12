using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorSP
{
    public partial class AsisOrdenamiento : AsistBaseSP
    {
        public AsisOrdenamiento()
        {
            InitializeComponent();
        }
        public override void Inicializate()
        {
            bool recargar = false;
            List<Objetos.CParametro> lista;
            lista = (List<Objetos.CParametro>)DameValor("Campos");
            //veo si los campos que yo tengo estan en mis listas
            foreach (Objetos.CParametro obj1 in ListaCampos.Items)
            {
                //recorro la lista
                bool encontrado = false;
                foreach (Objetos.CParametro obj2 in lista)
                {
                    if (obj1.nombre == obj2.nombre)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    //significa que cambaron los campos
                    recargar = true;
                    break;
                }
            }
            foreach (Objetos.CParametro obj1 in ListaParametros.Items)
            {
                //recorro la lista
                bool encontrado = false;
                foreach (Objetos.CParametro obj2 in lista)
                {
                    if (obj1.nombre == obj2.nombre)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    //significa que cambaron los campos
                    recargar = true;
                    break;
                }
            }
            if (ListaParametros.Items.Count == 0 && ListaCampos.Items.Count == 0)
                recargar = true;
            if (recargar == false)
                return;//no hago nada
            //cambiaron los datos, por lo que los recargo
            ListaParametros.Items.Clear();
            ListaCampos.Items.Clear();
            foreach (Objetos.CParametro obj1 in lista)
            {
                ListaCampos.Items.Add(obj1);
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

        private void ListaParametros_DoubleClick(object sender, EventArgs e)
        {
            if (ListaParametros.SelectedIndex == -1)
                return;
            Objetos.CParametro obj = (Objetos.CParametro)ListaParametros.Items[ListaParametros.SelectedIndex];
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
        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                Siguiente = new AsisResSelect();
                Siguiente.Anterior = this;
            }
            //guardo mi informacion
            List<Objetos.CParametro> lista = new List<Objetos.CParametro>();
            foreach (Objetos.CParametro obj in ListaParametros.Items)
            {
                lista.Add(obj);
            }
            AsignaValor("CamposOrdenamiento", lista);
            OnInstalame(Siguiente);
        }
    }
}

