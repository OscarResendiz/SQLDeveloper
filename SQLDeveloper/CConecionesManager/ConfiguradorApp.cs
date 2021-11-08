using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TextEditor.Document;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace ManagerConnect
{
    public partial class ConfiguradorApp : Component
    {
        #region General
        private string NombreArchivo
        {
            get
            {
                if (System.IO.Directory.Exists(Application.StartupPath + "\\Colores") == false)
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Colores");
                return Application.StartupPath + "\\Colores\\Config.xml";
            }
        }
        public void LoadConfig()
        {
            dataSet1.Clear();
            if(File.Exists(NombreArchivo))
                dataSet1.ReadXml(NombreArchivo);
        }
        public void SaveConfig()
        {
            dataSet1.WriteXml(NombreArchivo);
        }
        public ConfiguradorApp()
        {
            InitializeComponent();
        }
        public ConfiguradorApp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion
        #region Chechks
        public bool GetBooleanParameter(string Parametro)
        {
            LoadConfig();
            bool valor = false;
            DataTable tabla = dataSet1.Tables["Checkers"];
            foreach(DataRow dr in tabla.Rows)
            {
                if (dr["Parametro"].ToString() == Parametro)
                {
                    valor = bool.Parse(dr["Valor"].ToString());
                    break;
                }
            }
            return valor;
        }
        public void SetBooleanParameter(string parametro, bool valor)
        {
            LoadConfig();
            DataTable tabla = dataSet1.Tables["Checkers"];
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Parametro"].ToString() == parametro)
                {
                    dr["Valor"]=valor;
                    SaveConfig();
                    return;
                }
            }
            //como no existe, lo agrego
            DataRow nr = tabla.NewRow();
            nr["Parametro"] = parametro;
            nr["Valor"] = valor;
            tabla.Rows.Add(nr);
            SaveConfig();
        }
        #endregion
        #region Texts
        public string GetTextParameter(string Parametro)
        {
            LoadConfig();
            string valor = "";
            DataTable tabla = dataSet1.Tables["Texts"];
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Parametro"].ToString() == Parametro)
                {
                    valor = dr["Valor"].ToString();
                    break;
                }
            }
            return valor;
        }
        public void SetTextParameter(string parametro, string valor)
        {
            LoadConfig();
            DataTable tabla = dataSet1.Tables["Texts"];
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Parametro"].ToString() == parametro)
                {
                    dr["Valor"] = valor;
                    SaveConfig();
                    return;
                }
            }
            //como no existe, lo agrego
            DataRow nr = tabla.NewRow();
            nr["Parametro"] = parametro;
            nr["Valor"] = valor;
            tabla.Rows.Add(nr);
            SaveConfig();
        }
        #endregion
        #region Valores enteros
        public int GetIntParameter(string Parametro, int valordefaul=0)
        {
            LoadConfig();
            int valor = valordefaul;
            DataTable tabla = dataSet1.Tables["Texts"];
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Parametro"].ToString() == Parametro)
                {
                    if(int.TryParse(dr["Valor"].ToString(),out valor)==true)
                        return valor;
                    break;
                }
            }
            return valor;
        }
        public void SetIntParameter(string parametro, int valor)
        {
            LoadConfig();
            DataTable tabla = dataSet1.Tables["Texts"];
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Parametro"].ToString() == parametro)
                {
                    dr["Valor"] = valor.ToString();
                    SaveConfig();
                    return;
                }
            }
            //como no existe, lo agrego
            DataRow nr = tabla.NewRow();
            nr["Parametro"] = parametro;
            nr["Valor"] = valor.ToString();
            tabla.Rows.Add(nr);
            SaveConfig();
        }
        #endregion
    }
}
