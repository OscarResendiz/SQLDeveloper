using MotorDB;
using SPGenerator.GeneradorCodigo;
using SPGenerator.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SPGenerator
{
    public partial class AsisResSelect : AsistBaseSP
    {
        private IMotorDB DB;
        private string FCodigo;
        public AsisResSelect(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }
        public override void Inicializate()
        {
            TTabla.Text = DatosAsistente.Tabla.Nombre;
            TNomSP.Text = DatosAsistente.NombreSp;
            List<Objetos.CParametroSP> lista = DatosAsistente.Parametros;
            ListaParametros.Items.Clear();
            foreach (Objetos.CParametroSP obj in lista)
            {
                ListaParametros.Items.Add(obj);
            }
            EnableAnterior(true);
            EnableSiguiente(true);
            TextoSiguiente("Finalizar");
        }

        private void cTextColor1_OnCambiaFoco()
        {
            textBox1.Focus();
        }
        public override void BSiguiente()
        {
            IGeneradorCodigo generador = GeneradorCodigoProvider.DameGenerador(DB);
            FCodigo = generador.GeneraCodigo(DatosAsistente);
            CodigoSP(DatosAsistente.NombreSp, FCodigo);
            CloseEvent();
        }
    }
}

