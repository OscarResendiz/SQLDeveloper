using MotorDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
namespace SPGenerator
{
    public partial class AsisBienVenidaInsert : AsistBaseSP
    {

        IMotorDB DB;
        public AsisBienVenidaInsert(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
            EnableAnterior(false);
            EnableSiguiente(true);
        }
        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                Siguiente = new AsisSelTabla(DB);
                Siguiente.Anterior = this;
            }
            OnInstalame(Siguiente);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            EnableSiguiente(true);
            EnableAnterior(false);
        }
        public CTabla Tabla
        {
            set
            {
                DatosAsistente.Tabla = value;// DB.DameTabla(value);
            }
        }
        public override void Inicializate()
        {
            base.Inicializate();
            DatosAsistente.TipoSP = Objetos.TIPO_SP.INSERT;
        }
    }
}

