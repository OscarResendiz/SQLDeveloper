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
    public partial class AsisBienVenidaDelete : AsistBaseSP
    {
        IMotorDB DB;
        //IGeneradorCodigo GeneradorCodigo;

        public AsisBienVenidaDelete(IMotorDB db)//, IGeneradorCodigo generadorCodigo)
        {
            //GeneradorCodigo=generadorCodigo;
            DB = db;
            InitializeComponent();
            EnableAnterior(false);
            EnableSiguiente(true);
            //AsignaValor("Tipo", "Delete");
        }
        public override void Inicializate()
        {
            base.Inicializate();
            DatosAsistente.TipoSP = Objetos.TIPO_SP.DELETE;
        }

        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                Siguiente = new AsisSelTabla(DB);//, GeneradorCodigo);
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
                //AsignaValor("Tabla", value);
            }
        }
    }
}

