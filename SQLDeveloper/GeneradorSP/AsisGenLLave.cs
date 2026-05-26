using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
namespace GeneradorSP
{
    public partial class AsisGenLLave : AsistBaseSP
    {
        CPrimaryKey PK;
        //List<Objetos.CParametro> LLaves;
         IMotorDB DB;
        private string Tabla;
        public AsisGenLLave(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            string tabla = (string)DameValor("Tabla");
            //if (Tabla == tabla)
            //{
            //    //no nececito actualizar nada
            //    return;
            //}
            Tabla = tabla;
            //me traiog los campos de la llave primaria
            PK = DB.DameLLavePrimaria(Tabla);
            //si no tiene llaves desactivo el checbox
            if (PK.Campos.Count == 0)
            {
                CHGenLLave.Enabled = false;
                CHGenLLave.Checked = false;
                return;
            }
            //ahora me traigo los parametros para ver si alguna llave esta dentro de ellos
            List<Objetos.CParametro> parametros;
            parametros = (List<Objetos.CParametro>)DameValor("ListaParametros");
            List<CCampoBase> libres = new List<CCampoBase>();
            foreach (CCampoBase llave in PK.Campos)
            {
                bool encontrado = false;
                foreach (Objetos.CParametro parametro in parametros)
                {
                    if (llave.Nombre== parametro.nombre)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    libres.Add(llave);
                }
            }
            // si no me quedo ninguna,desactivo el chec
            if (libres.Count == 1)
            {
                CHGenLLave.Enabled = true;
                CHGenLLave.Checked = true;
                AsignaValor("CampoLLave", libres[0]);
                return;
            }
            CHGenLLave.Enabled = false;
            CHGenLLave.Checked = false;
        }
        public override void BSiguiente()
        {
            string tipo = (string)DameValor("Tipo");
            if (Siguiente == null)
            {
                Siguiente = new AsisResInsert(DB);
                Siguiente.Anterior = this;
            }
            //guardo mis datos
            AsignaValor("AsisGenLLave", CHGenLLave.Checked);
            OnInstalame(Siguiente);
        }
    }
}

