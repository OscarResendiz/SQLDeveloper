using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
using MotorDB;
namespace SPGenerator
{
    public partial class AsisSelTabla : AsistBaseSP
    {
        private IMotorDB DB;

        public AsisSelTabla(IMotorDB db)
        {
            DB = db;
            InitializeComponent(); 
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            FormBuscarTabla dlg = new FormBuscarTabla(DB, EnumTipoObjeto.TABLE);
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            TTabla.Text = dlg.Tabla;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ok = true;
            if (Visible == false)
                return;
            if (TTabla.Text.Trim() == "")
                ok = false;
            EnableSiguiente(ok);
            EnableAnterior(true);
        }

        private void BCrear_Click(object sender, EventArgs e)
        {
            CrearTablas.FormCrearTabla dlg = new CrearTablas.FormCrearTabla(DB);
            dlg.ShowDialog();
            TTabla.Text = dlg.NombreTabla;
        }
        public override void BSiguiente()
        {
            //agrego elnombre
            if(DatosAsistente.Tabla.Nombre!= TTabla.Text)
                DatosAsistente.Tabla = DB.DameTabla(TTabla.Text);
            if (Siguiente == null)
            {
                Siguiente = new AsisNombreSP(DB);
                Siguiente.Anterior = this;
            }
            OnInstalame(Siguiente);
        }
        public override void Inicializate()
        {
            string s;
            try
            {
                s = DatosAsistente.Tabla.Nombre;
            }
            catch (System.Exception)
            {
                return;
            }
            TTabla.Text = s;
        }
    }
}


