using MotorDB;
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
    public partial class AsisForeigKeys : AsistBaseSP
    {
        private IMotorDB DB;
        public AsisForeigKeys(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
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
            CLLaveForanea obj = (CLLaveForanea)ListaParametros.Items[ListaParametros.SelectedIndex];
            if (DatosAsistente.TipoSP== Objetos.TIPO_SP.INSERT || DatosAsistente.TipoSP == Objetos.TIPO_SP.UPDATE)
            {
                FormForeigKey dlg = new FormForeigKey(DB);
                dlg.Nombre = obj.Nombre;
                dlg.GenerarExcepcion = obj.GenerarExcepcion;
                dlg.Docuemntacion = obj.Comentarios;
                dlg.Excepcion = obj.Mensage;
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;
                obj.Nombre = dlg.Nombre;
                obj.GenerarExcepcion = dlg.GenerarExcepcion;
                obj.Comentarios = dlg.Docuemntacion;
                obj.Mensage = dlg.Excepcion;
            }
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.DELETE)
            {
                FormPropFkDelete dlg2 = new FormPropFkDelete(DB, obj);
                if (dlg2.ShowDialog() == DialogResult.Cancel)
                    return;
            }
        }
        public override void BSiguiente()
        {
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.INSERT)
            {
                if (Siguiente == null)
                {
                    Siguiente = new AsisGenLLave(DB);
                    Siguiente.Anterior = this;
                }
                //guardo mi informacion
            }
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.UPDATE)
            {
                if (Siguiente == null)
                {
                    Siguiente = new AsisResUpdate(DB);
                    Siguiente.Anterior = this;
                }
            }
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.DELETE)
            {
                if (Siguiente == null)
                {
                    Siguiente = new AsisResDelete(DB);
                    Siguiente.Anterior = this;
                }
            }
            List<CLLaveForanea> lista = new List<CLLaveForanea>();
            foreach (CLLaveForanea obj in ListaParametros.Items)
            {
                //CLLaveForanea fk = new CLLaveForanea()
                //{
                //    Nombre = obj.Nombre,
                //    AccionActualizar = obj.AccionActualizar,
                //    AccionBorrar = obj.AccionBorrar,
                //    Campos = obj.Campos,
                //    Comentarios = obj.Comentarios,
                //    GenerarExcepcion = obj.GenerarExcepcion,
                //    Mensage = obj.Mensage,
                //    TablaHija = obj.TablaHija,
                //    TablaPadre = obj.TablaPadre,
                //    Tipo = obj.Tipo
                //};
                lista.Add(obj);
            }
            DatosAsistente.FreignKeys = lista;
            OnInstalame(Siguiente);
        }
        public override void Inicializate()
        {
            //cambio el nombre de la tabla, por lo que actualizo mis listas
            ListaCampos.Items.Clear();
            ListaParametros.Items.Clear();

            //me traigo la lista llaves foraneas de la tabla
            List<CForeignKey> campos =null;
            if(DatosAsistente.TipoSP== TIPO_SP.DELETE)//modo =="Delete")
                campos = DB.DameLLavesForaneasHijas(DatosAsistente.Tabla.Nombre);
            else
                campos = DB.DameLLavesForaneas(DatosAsistente.Tabla.Nombre);
            foreach (CForeignKey obj in campos)
            {
                CLLaveForanea fk = new CLLaveForanea()
                {
                    Nombre = obj.Nombre,
                    AccionActualizar = obj.AccionActualizar,
                    AccionBorrar = obj.AccionBorrar,
                    Campos = obj.Campos,
                    Comentarios = obj.Comentarios,
                    GenerarExcepcion = obj.GenerarExcepcion,
                    Mensage = obj.Mensage,
                    TablaHija = obj.TablaHija,
                    TablaPadre = obj.TablaPadre,
                    Tipo = obj.Tipo
                };
                ListaCampos.Items.Add(fk);
            }
        }
    }
}

