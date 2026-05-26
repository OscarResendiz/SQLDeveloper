using MotorDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPGenerator
{
    public partial class AsistenteBienVenidaSps : AsistBaseSP
    {
        IMotorDB DB;
        public AsistenteBienVenidaSps(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
            EnableAnterior(false);
            EnableSiguiente(true);
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
        public string NombreTabla
        {
            set
            {
                DatosAsistente.Tabla = DB.DameTabla(value);
            }
        }
    }
}
