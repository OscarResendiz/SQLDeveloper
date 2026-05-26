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
    public partial class AsisResInsert : AsistBaseSP
    {
        private IMotorDB DB;
        private string Codigo;

        public AsisResInsert(IMotorDB db)
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
            CHGenLLavePrimaria.Checked = DatosAsistente.AsisGenLLave;
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
        }
    }
}

