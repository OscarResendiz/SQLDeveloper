using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SintaxColor;
namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public delegate void OnEditConfigChangeEvent(string editor);
    public partial class FormGestorColor : Form
    {
        public event OnEditConfigChangeEvent OnEditConfigChange;
        public FormGestorColor()
        {
            InitializeComponent();
        }
        private void FormGestorColor_Load(object sender, EventArgs e)
        {
            CargaArchivos();
        }
        private string Directorio
        {
            get
            {
                if (System.IO.Directory.Exists(Application.StartupPath + "\\Colores") == false)
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Colores");
                return Application.StartupPath + "\\Colores";
            }
        }
        private void CargaArchivos()
        {
            //busco todos los archivos xshd
            ComboTema.Items.Clear();
            string[] Archivos;
            Archivos = System.IO.Directory.GetFiles(Directorio, "*.xshd");
            foreach (string s in Archivos)
            {
                CFileName file = new CFileName();
                file.FileName = s;
                ComboTema.Items.Add(file);
            }
            //cargo el tema selccionado por default
            if(File.Exists(Directorio+"\\DefaultTeme.dft"))
            {
                StreamReader sr=                File.OpenText(Directorio+"\\DefaultTeme.dft");
                string tema = sr.ReadToEnd();
                sr.Close();
                //ahora selecciono el tema de la lista
                for(int i=0;i<ComboTema.Items.Count;i++)
                {
                    CFileName f=(CFileName )ComboTema.Items[i];
                    if(f.ShortFileName==tema)
                    {
                        ComboTema.SelectedIndex = i;                       
                        return;
                    }
                }
            }

        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ComboTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboTema.SelectedIndex == -1)
            {
                BEliminar.Enabled = false;
                return;
            }
            try
            {
                BEliminar.Enabled = true;
                CFileName obj = (CFileName)ComboTema.SelectedItem;
                //abro el archivo
                sintaxColorManager1.LoadFile(obj.FileName);
                LLenaArbol();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private SplitterPanel Contenedor
        {
            get
            {
                return splitContainer1.Panel2;
            }
        }
        private CControlBase Visor
        {
            get
            {
                return (CControlBase)Contenedor.Controls[0];
            }
            set
            {
                Contenedor.Controls.Clear();
                if (value != null)
                {
                    Contenedor.Controls.Add(value);
                    value.Dock = DockStyle.Fill;
                }
            }
        }
        private void Lista_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                Contenedor.Controls.Clear();
                return;
            }
            CNodoBase nodo = (CNodoBase)e.Node;
            Visor = nodo.Visor;
        }
        private void LLenaArbol()
        {
            CSyntaxDefinition definicio = sintaxColorManager1.GetSyntaxDefinition();
            Lista.Nodes.Clear();
            CNodoEnvironment Environment = new CNodoEnvironment();
            Environment.Objeto = definicio.Environment;
            Lista.Nodes.Add(Environment);
            Environment.Recarga();
            CNodoProperties Properties = new CNodoProperties();
            Properties.Objeto = definicio.Properties;
            Properties.Recarga();
            Lista.Nodes.Add(Properties);
            CNodoDigits Digits = new CNodoDigits();
            Digits.Objeto = definicio.Digits;
            Lista.Nodes.Add(Digits);
            Digits.Recarga();
            CNodoRuleSet reglas = new CNodoRuleSet();
            reglas.Objeto = definicio.RuleSet;
            reglas.Recarga();
            Lista.Nodes.Add(reglas);
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (ComboTema.SelectedIndex == -1)
            {
                Close();
                return;
            }
            try
            {
                CFileName obj = (CFileName)ComboTema.SelectedItem;
                sintaxColorManager1.WriteFile(obj.FileName);
                Close();
                if (OnEditConfigChange != null)
                {
                    OnEditConfigChange(obj.ShortFileName);
                }
                //ahora asigno el tema seleccionado por defaulr
                StreamWriter sw = File.CreateText(Directorio + "\\DefaultTeme.dft");
                sw.Write(obj.ShortFileName);
                sw.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            FormNuevoColor dlg = new FormNuevoColor();
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            CFileName obj = new CFileName();
            obj.FileName = dlg.Archivo;
            ComboTema.Items.Add(obj);
            ComboTema.SelectedItem = obj;

        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (ComboTema.SelectedIndex == -1)
                return;
            if (MessageBox.Show("¿Eliminar el archivo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            try
            {
                BEliminar.Enabled = true;
                CFileName obj = (CFileName)ComboTema.SelectedItem;
                File.Delete(obj.FileName);
                ComboTema.Items.Remove(obj);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
   