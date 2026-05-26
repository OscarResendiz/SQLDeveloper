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
    public partial class AsisSelParametros : AsistBaseSP
    {
        private string Tabla;

        private IMotorDB DB;
        public AsisSelParametros(IMotorDB db)
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
            if ( DatosAsistente.TipoSP!= TIPO_SP.SELECT)
            {
                if (ListaParametros.Items.Count == 0)
                    ok = false;
            }
            if (CHExcepcion.Checked == true)
            {
                if (TExcepcion.Text.Trim() == "")
                    ok = false;
            }
            EnableAnterior(true);
            EnableSiguiente(ok);
            ok = true;
            if (ListaCampos.SelectedIndices.Count == 0)
                ok = false;
            BAgregar.Enabled = ok;
            ok = true;
            if (ListaParametros.SelectedIndices.Count == 0)
                ok = false;
            if (DatosAsistente.TipoSP== TIPO_SP.DELETE)
                ok = false;
            BQuitar.Enabled = ok;
            TExcepcion.Enabled = CHExcepcion.Checked;
            TComentarios.Enabled = CHExcepcion.Checked;
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
            CParametroSP obj = (CParametroSP)ListaParametros.Items[ListaParametros.SelectedIndex];
            if (DatosAsistente.TipoSP== TIPO_SP.SELECT)
            {
                FormPropParametro dlg = new FormPropParametro();
                dlg.Nombre = obj.nombre;
                dlg.Tipo = obj.tipo;
                dlg.Filtro = obj.Filtro;
                dlg.Comentario = obj.Descripcion;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                obj.Filtro = dlg.Filtro;
                obj.Descripcion = dlg.Comentario;
            }
            else if (DatosAsistente.TipoSP == TIPO_SP.INSERT || DatosAsistente.TipoSP == TIPO_SP.UPDATE)
            {
                FormPropParametro2 dlg = new FormPropParametro2();
                dlg.Nombre = obj.nombre;
                dlg.Tipo = obj.tipo;
                dlg.NoRepetibles = obj.ValidarUnicidad;
                dlg.Comentario = obj.Descripcion;
                dlg.Vacios = obj.Vacios;
                dlg.ExcepcionNoRepetibles = obj.ExcepcionNoRepetibles;
                dlg.ExcepcionVacios = obj.ExcepcionVacios;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                obj.Descripcion = dlg.Comentario;
                obj.ValidarUnicidad = dlg.NoRepetibles;
                obj.Descripcion = dlg.Comentario;
                obj.Vacios = dlg.Vacios;
                obj.ExcepcionNoRepetibles = dlg.ExcepcionNoRepetibles;
                obj.ExcepcionVacios = dlg.ExcepcionVacios;
            }
        }
        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                if (DatosAsistente.TipoSP == TIPO_SP.SELECT)
                {
                    Siguiente = new AsisSelCampos(DB);
                }
                else if (DatosAsistente.TipoSP == TIPO_SP.INSERT || DatosAsistente.TipoSP == TIPO_SP.UPDATE)
                {
                    Siguiente = new AsisSelValFijos(DB);
                }
                else if (DatosAsistente.TipoSP == TIPO_SP.DELETE)
                {
                    Siguiente = new AsisForeigKeys(DB);
                }
                Siguiente.Anterior = this;
            }
            //guardo mis datos
            List<CParametroSP> lista = new List<CParametroSP>();
            foreach (CParametroSP obj in ListaParametros.Items)
            {
                lista.Add(obj);
            }
            DatosAsistente.Parametros= lista;
            DatosAsistente.CHExcepcionParametros = CHExcepcion.Checked;
            DatosAsistente.ExcepcionParametros = TExcepcion.Text;
            DatosAsistente.ComentariosParametros = TComentarios.Text;
            OnInstalame(Siguiente);
        }
        public override void Inicializate()
        {
            if (DatosAsistente.TipoSP == TIPO_SP.SELECT)
            {
                CHExcepcion.Visible = true;
                label3.Visible = true;
                TExcepcion.Visible = true;
                label5.Visible = true;
                TComentarios.Visible = true;
            }
            else
            {
                CHExcepcion.Visible = false;
                label3.Visible = false;
                TExcepcion.Visible = false;
                label5.Visible = false;
                TComentarios.Visible = false;
            }

            string tabla = DatosAsistente.Tabla.Nombre;
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
            List<CCampo> campos = DatosAsistente.Tabla.Campos;
            CPrimaryKey pk = DatosAsistente.Tabla.PrimaryKey;
            if (pk != null)
            {
                foreach (CCampo obj in campos)
                {
                    CParametroSP parametro = new CParametroSP() {

                        Logitud = obj.Longitud,
                           nombre=obj.Nombre,
                           tipo=obj.TipoDato.Nombre
                    };

                    if (pk.ContieneCampo(obj) == true && (DatosAsistente.TipoSP == TIPO_SP.UPDATE || DatosAsistente.TipoSP == TIPO_SP.DELETE))
                        ListaParametros.Items.Add(parametro);
                    else
                        ListaCampos.Items.Add(parametro);
                }
            }
            if (DatosAsistente.TipoSP == TIPO_SP.DELETE)
            {
                //es de borrado, por loque desactivo unos botones
                ListaCampos.Enabled = false;
            }

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNuevoCampo dlg = new FormNuevoCampo(DB);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            ListaParametros.Items.Add(dlg.Parametro);
        }

        private void ListaCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DlstPropiedades.Items.Clear();
            if (ListaCampos.SelectedIndex == -1)
                return;
            CParametroSP obj;
            obj = (CParametroSP)ListaCampos.Items[ListaCampos.SelectedIndex];
            CCampo campo = DatosAsistente.Tabla.GetCampo(obj.nombre);
            DlstPropiedades.Items.Add("nombre="+campo.Nombre);
            DlstPropiedades.Items.Add("Tipo="+campo.TipoDato);
            DlstPropiedades.Items.Add("Longitud="+campo.Longitud.ToString());
            DlstPropiedades.Items.Add("Identidad=" + DatosAsistente.Tabla.EsIdentidad(campo));
        }
    }
}

