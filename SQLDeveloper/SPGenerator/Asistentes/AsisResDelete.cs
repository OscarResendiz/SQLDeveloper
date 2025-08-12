using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
using SPGenerator.GeneradorCodigo;
using SPGenerator.Objetos;

namespace SPGenerator
{
    public partial class AsisResDelete : AsistBaseSP
    {
        private IMotorDB DB;
        private string Codigo;
        public AsisResDelete(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            TTabla.Text = DatosAsistente.Tabla.Nombre;
            TNomSP.Text = DatosAsistente.NombreSp;
            List<CParametroSP> lista = DatosAsistente.Parametros;
            ListaParametros.Items.Clear();
            foreach (CParametroSP obj in lista)
            {
                ListaParametros.Items.Add(obj);
            }
            TextoSiguiente("Finalizar");
        }
        private void Add(string s)
        {
            Codigo = Codigo + s;
        }
        private void AddLine(string s)
        {
            Add(s + "\n");
        }
        public override void BSiguiente()
        {
            IGeneradorCodigo generador = GeneradorCodigoProvider.DameGenerador(DB);
            Codigo = generador.GeneraCodigo(DatosAsistente);
            CodigoSP(DatosAsistente.NombreSp, Codigo);
            CloseEvent();

//            CodigoSP(DatosAsistente.NombreSp, Codigo);
  //          CloseEvent();
        }

    }
}

