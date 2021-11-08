using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Inteliences
{
    public partial class CBaseTextAnaliser : Component, ITextAnaliser
    {
        private bool Consultando=false;
        private DateTime ProximoAnalisis; 
        protected CBuffer DbBuffer = null;
        private string FTextoInterno = "";
        protected bool AnalisisActivo = false; //variable que indica que el anasisis esta activo
        protected List<CSimbolo> TablaSimbolos = new List<CSimbolo>();
        protected ICSharpCode.TextEditor.TextEditorControl TCodigo;
        public CBaseTextAnaliser()
        {
            TiempoRefresh = 1; 
            InitializeComponent();
        }

        public CBaseTextAnaliser(IContainer container)
        {
            TiempoRefresh = 1;
            container.Add(this);

            InitializeComponent();
        }
        #region implementacion de ITextAnaliser
        private void IniciaAnalisis()
        {
            AnalisisActivo = true;
            //con esto obligo a que haga el analisi
            ProximoAnalisis = System.DateTime.Now.AddSeconds( - 1);
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
        public void SetTextEditor(ICSharpCode.TextEditor.TextEditorControl editor)
        {
            TCodigo = editor;
            IniciaAnalisis();
        }

        public List<string> GetVariableNames()
        {
            List<string> l = new List<string>();
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Tipo == TIPO_SIMBOLO.VARIABLE)
                {
                    l.Add(obj.Name);
                }
            }
            return l;
        }
        protected virtual void BuscaTablas()
        {
            // hay que sobreescribirla
        }
        public List<string> GetTablesNames()
        {
            Consultando = true;
            BuscaTablas();
            List<string> l = new List<string>();
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Tipo == TIPO_SIMBOLO.TABLA)
                {
                    l.Add(obj.Name);
                }
            }
            Consultando = false;
            return l;
        }
        protected virtual void BuscaCamposTablas()
        {
            // hay que sobreescribirla
        }

        public List<string> GetTableFields(string tabla)
        {
            Consultando = true;
            BuscaCamposTablas();
            List<string> l = new List<string>();
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Tipo == TIPO_SIMBOLO.CAMPO)
                {
                    l.Add(obj.Name);
                }
            }
            Consultando = false;
            return l;
        }
        public List<string> GetAllFields()
        {
            Consultando = true;
            BuscaCamposTablas();
            List<string> l = new List<string>();
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Tipo == TIPO_SIMBOLO.CAMPO)
                {
                    l.Add(obj.Name);
                }
            }
            Consultando = false;
            return l;
        }

        public int GetDeclarationLine(string nombre)
        {
            foreach (CSimbolo obj in TablaSimbolos)
            {
                if (obj.Name.ToUpper().Trim() == nombre.ToUpper().Trim())
                {
                    return obj.DeclarationLinea;
                }
            }
            return -1;
        }
        #endregion
        protected virtual void AnalizaTexto( string Texto)
        {
            //esta funcion hay que sobreescribirla para dar la funcionalidad al sistema
        }
        public int TiempoRefresh
        {
            get;
            set;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string texto = "";
            ProximoAnalisis = DateTime.Now;
            do
            {
                if (DateTime.Now >= ProximoAnalisis)
                {
                    //hay que analisar el texto
                    try
                    {
                        //me traigo el codigo que se tiene actualmente en el editor
                        FTextoInterno = null;
                        backgroundWorker1.ReportProgress(-1);
                        while (FTextoInterno == null || Consultando==true)
                            Thread.Sleep(1000);
                        texto = FTextoInterno;// TCodigo.Text;
                        //limpio la tabla de simbolos
                        TablaSimbolos.Clear();
                        AnalizaTexto(texto);
                    }
                    catch (System.Exception)
                    {
                        ;//no hace nada
                    }
                    ProximoAnalisis = DateTime.Now.AddMinutes(TiempoRefresh);
                }
                Thread.Sleep(1000); // se duerme un segundo
            }
            while (AnalisisActivo);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnalisisActivo)
            {
                //se salio y no devia hacerlo
                IniciaAnalisis();
            }
        }
        protected void AddSimbol(CSimbolo obj)
        {
            //agrega el simbolo a la tabla de simbolos
            //verifica si no esta repetido
            foreach(CSimbolo obj2 in TablaSimbolos)
            {
                if (obj.Name.ToUpper().Trim() == obj2.Name.ToUpper().Trim() /*&& obj.DeclarationLinea == obj2.DeclarationLinea*/ && obj.Tipo == obj2.Tipo)
                    return; // ya se encuentra en la tabla de simbolos
            }
            //como no esta lo agrego
            TablaSimbolos.Add(obj);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //me traifo el texto
            if(TCodigo!=null)
            {
                FTextoInterno = TCodigo.Text;
            }
        }
        public virtual string GetSincronizadorAnterior(int offset)
        {
            return "";
        }
        public void SetBuffer(CBuffer buffer)
        {
            DbBuffer = buffer;
        }
    }
}
