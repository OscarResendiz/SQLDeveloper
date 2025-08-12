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
using MotorDB.Motores;
namespace GeneradorSP.CrearTablas
{
    public partial class FormCrearTabla : Form
    {
        private bool Creada;
        IMotorDB DB;
        List<Objetos.CParametro> Campos;
        List<Objetos.CRelacion> Relaciones;
        public FormCrearTabla(IMotorDB db)
        {
            DB = db;
            Creada = false;
            Campos = new List<Objetos.CParametro>();
            InitializeComponent();
            Relaciones = new List<Objetos.CRelacion>();
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BAgregarCampo_Click(object sender, EventArgs e)
        {
            FormPropiedadesCampo dlg = new FormPropiedadesCampo();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            //veo si el nombre del campo ya existe
            foreach (Objetos.CParametro obj2 in Campos)
            {
                if (obj2.nombre.ToLower().Trim() == dlg.Nombre.ToLower().Trim())
                {
                    MessageBox.Show("El campo ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Objetos.CParametro obj = new Objetos.CParametro();
            obj.nombre = dlg.Nombre;
            obj.tipo = dlg.Tipo;
            obj.Logitud = dlg.Longitud;
            obj.NULOS = dlg.PermitirNulos;
            obj.ValorFijo = dlg.ValorPorDefault;
            obj.Default = dlg.Default;
            obj.AutoIncremental = dlg.AuntoIncremental;
            obj.iscomputed = dlg.ValorCalculado;
            obj.Valor = dlg.ExprecionCalculado;
            obj.Descripcion = dlg.Docuemntacion;
            obj.Variable = dlg.Variable;

            Campos.Add(obj);
            MuestraCampos();
        }
        private void MuestraCampos()
        {
            cTabla1.Clear();
            foreach (Objetos.CParametro dato in Campos)
            {
                bool nulos = false;
                if (dato.NULOS.ToUpper().Trim() == "SI")
                    nulos = true;
                bool pk = dato.LLavePrimaria;
                bool fk = dato.LLaveForanea;
                cTabla1.Add(dato.nombre, dato.tipo + "(" + dato.Logitud + ")", pk, fk, nulos, dato.Descripcion);
            }
            Height = toolStrip1.Height + panel1.Height + cTabla1.Tamaño + 35;
        }

        private void BEliminarCampos_Click(object sender, EventArgs e)
        {
            FormSeleccionarCampos dlg = new FormSeleccionarCampos(Campos);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            Campos.RemoveAt(dlg.CampoAEliminar);
            MuestraCampos();
        }

        private void BEditarCampo_Click(object sender, EventArgs e)
        {
            FormSeleccionarCampos dlg = new FormSeleccionarCampos(Campos);
            dlg.Text = "Seleccionar campo";
            dlg.Texto = "Campo a editar";
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            FormPropiedadesCampo dlg2 = new FormPropiedadesCampo();
            Objetos.CParametro obj = Campos[dlg.CampoAEliminar];
            dlg2.Nombre = obj.nombre;
            dlg2.Tipo = obj.tipo;
            dlg2.Longitud = obj.Logitud;
            dlg2.PermitirNulos = obj.NULOS;
            dlg2.ValorPorDefault = obj.ValorFijo;
            dlg2.Default = obj.Default;
            dlg2.AuntoIncremental = obj.AutoIncremental;
            dlg2.ValorCalculado = obj.iscomputed;
            dlg2.ExprecionCalculado = obj.Valor;
            dlg2.Docuemntacion = obj.Descripcion;
            if (dlg2.ShowDialog() == DialogResult.Cancel)
                return;
            Campos[dlg.CampoAEliminar].nombre = dlg2.Nombre;
            Campos[dlg.CampoAEliminar].tipo = dlg2.Tipo;
            Campos[dlg.CampoAEliminar].Logitud = dlg2.Longitud;
            Campos[dlg.CampoAEliminar].NULOS = dlg2.PermitirNulos;
            Campos[dlg.CampoAEliminar].ValorFijo = dlg2.ValorPorDefault;
            Campos[dlg.CampoAEliminar].Default = dlg2.Default;
            Campos[dlg.CampoAEliminar].AutoIncremental = dlg2.AuntoIncremental;
            Campos[dlg.CampoAEliminar].iscomputed = dlg2.ValorCalculado;
            Campos[dlg.CampoAEliminar].Valor = dlg2.ExprecionCalculado;
            Campos[dlg.CampoAEliminar].Descripcion = dlg2.Docuemntacion;
            Campos[dlg.CampoAEliminar].Variable = dlg2.Variable;
            MuestraCampos();

        }

        private void BLLavePrimaria_Click(object sender, EventArgs e)
        {
            FormPrimaryKey dlg = new FormPrimaryKey(Campos);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            int i, n;
            n = Campos.Count;
            for (i = 0; i < n; i++)
            {
                Campos[i].LLavePrimaria = dlg.EsLLave(i);
            }
            MuestraCampos();
        }

        private void BAgregarLaveForanea_Click(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            foreach (Objetos.CParametro obj in Campos)
            {
                l.Add(obj.nombre);
            }
            FormRelaciones dlg = new FormRelaciones(l, DB, TTabla.Text);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            Relaciones.Add(dlg.Relacion);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            bool ok2 = true;
            if (TTabla.Text.Trim() == "")
            {
                ok2 = false;
                ok = false;
            }
            BEliminarLLaveForanea.Enabled = ok;
            BGuardar.Enabled = ok;
            ok = true;
            if (Campos.Count == 0)
            {
                ok = false;
                ok2 = false;
            }
            BEliminarCampos.Enabled = ok;
            BEditarCampo.Enabled = ok;
            BLLavePrimaria.Enabled = ok;
            BAgregarLaveForanea.Enabled = ok2;
        }

        private void BEliminarLLaveForanea_Click(object sender, EventArgs e)
        {
            List<Objetos.CParametro> l;
            l = new List<Objetos.CParametro>();
            foreach (Objetos.CRelacion obj in Relaciones)
            {
                Objetos.CParametro p = new Objetos.CParametro();
                p.nombre = obj.Nombre;
                l.Add(p);
            }
            FormSeleccionarCampos dlg = new FormSeleccionarCampos(l);
            dlg.Text = "Eliminar Relación";
            dlg.Texto = "Relacón";
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            Relaciones.RemoveAt(dlg.CampoAEliminar);
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            string s = "";
            //genero la secuencia de comandos para crear la tabla
            s = s + "create table " + TTabla.Text + "(";
            //creo los campos
            bool primero = true;
            foreach (Objetos.CParametro obj in Campos)
            {
                if (primero == false)
                    s = s + ",";
                else
                    primero = false;
                if (obj.iscomputed == 1)

                    s = s + obj.nombre + " as " + obj.Valor;

                else
                    s = s + obj.nombre + " " + obj.tipo;
                if (obj.Variable == true && obj.iscomputed != 1)
                {
                    s = s + " (" + obj.Logitud.ToString() + ")";
                }
                if (obj.AutoIncremental == true)
                {
                    s = s + " identity";
                }
                if (obj.ValorFijo == true)
                {
                    s = s + " default " + obj.Default;
                }
                if (obj.NULOS == "NO")
                {
                    s = s + " NOT NULL";
                }
            }
            //ahora veo si tiene alguna llave primaria
            primero = true;
            foreach (Objetos.CParametro obj in Campos)
            {
                if (obj.FLLavePrimaria == true)
                {
                    if (primero == true)
                    {
                        s = s + ",constraint PK_" + TTabla.Text + " primary key(";
                        primero = false;
                    }
                    else
                        s = s + ",";
                    s = s + obj.nombre;
                }
            }
            if (primero == false)
                s = s + ")";
            //ahora checo si tiene llaves foraneas
            foreach (Objetos.CRelacion obj in Relaciones)
            {
                primero = true;
                foreach (CCampoFK fk in obj.CamposFK)
                {
                    if (primero == true)
                    {
                        s = s + ",constraint " + obj.Nombre + " foreign key(";
                        primero = false;
                    }
                    else
                        s = s + ",";
                    s = s + fk.columnahija;
                }
                s = s + ") references " + obj.TablaPadre + "(";
                primero = true;
                foreach (CCampoFK fk in obj.CamposFK)
                {
                    if (primero == true)
                    {
                        primero = false;
                    }
                    else
                        s = s + ",";
                    s = s + fk.columnaMaestra;
                }
                s = s + ")";
                if (obj.EliminarCascada == true)
                {
                    s = s + " ON DELETE  CASCADE ";
                }
                if (obj.ActualisarCascada == true)
                {
                    s = s + " ON UPDATE  CASCADE ";
                }
            }
            s = s + ")";
            //ejecuto la consulta
            try
            {
                DB.EjecutaQuery(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = DialogResult.None;
                return;
            }
            //ahora aplico la documentacion ala tabla
//            DB.GusrdaDescripcionTabla(TTabla.Text, TDocumentacion.Text);
  //          foreach (Objetos.CParametro obj in Campos)
    //        {
      //          DB.GuardaDescripcionCampo(TTabla.Text, obj.nombre, obj.Descripcion);
        //    }
          //  Creada = true;
            Close();
        }
        public string NombreTabla
        {
            get
            {
                if (Creada == true)
                    return TTabla.Text;
                return "";
            }
        }
    }
}