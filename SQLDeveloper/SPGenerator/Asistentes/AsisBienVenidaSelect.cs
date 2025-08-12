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
    public partial class AsisBienVenidaSelect : AsistBaseSP
    {
        //IGeneradorCodigo GeneradorCodigo;
        IMotorDB DB;
        public AsisBienVenidaSelect(IMotorDB db)//, IGeneradorCodigo generadorCodigo)
        {
            DB = db;
            InitializeComponent();
            EnableAnterior(false);
            EnableSiguiente(true);
            //AsignaValor("Tipo", "Lectura");
            //GeneradorCodigo = generadorCodigo;
        }
        public override void Inicializate()
        {
            base.Inicializate();
            DatosAsistente.TipoSP = Objetos.TIPO_SP.SELECT;
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
        public string NombreTabla
        {
            set
            {
                DatosAsistente.Tabla = DB.DameTabla(value);
                //AsignaValor("Tabla", value);
            }
        }
    }
}

