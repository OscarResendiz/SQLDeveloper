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
    public partial class AsisGenLLave : AsistBaseSP
    {
         IMotorDB DB;
        public AsisGenLLave(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            //si no tiene llaves desactivo el checbox
            if (DatosAsistente.Tabla.PrimaryKey == null) 
            {
                CHGenLLave.Enabled = false;
                CHGenLLave.Checked = false;
                return;
            }
            //ahora me traigo los parametros para ver si alguna llave esta dentro de ellos
            List<CParametroSP> parametros;
            parametros = DatosAsistente.Parametros;
            List<CParametroSP> libres = new List<CParametroSP>();
            foreach (CParametroSP parametro in parametros)
            {
                if (DatosAsistente.Tabla.PrimaryKey.ContieneCampo(parametro.nombre) == false)
                {
                    libres.Add(parametro);
                }

            }
            // si no me quedo ninguna,desactivo el chec
            if (libres.Count == 1)
            {
                CHGenLLave.Enabled = true;
                CHGenLLave.Checked = true;
                DatosAsistente.CampoLLave = libres[0];
                //AsignaValor("CampoLLave", libres[0]);
                return;
            }
            CHGenLLave.Enabled = false;
            CHGenLLave.Checked = false;
        }
        public override void BSiguiente()
        {
            if (Siguiente == null)
            {
                Siguiente = new AsisResInsert(DB);
                Siguiente.Anterior = this;
            }
            //guardo mis datos
            DatosAsistente.AsisGenLLave=CHGenLLave.Checked;
            OnInstalame(Siguiente);
        }
    }
}

