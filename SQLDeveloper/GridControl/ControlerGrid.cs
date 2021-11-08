using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridControl
{
    public partial class ControlerGrid : UserControl
    {
        public event OnMessageEvent OnMessage;
        private DataSet FDataSet;
        public ControlerGrid()
        {
            InitializeComponent();
        }
        public DataSet DataSet
        {
            get
            {
                return FDataSet;
            }
            set
            {
                FDataSet = value;
                //agrego el dataset al contenedor
                CurrentePageResult.DataSet = FDataSet;
                if (FDataSet == null)
                    ActivaBotones = false;
                else
                    ActivaBotones = true;
            }
        }
        private PageResult CurrentePageResult
        {
            get
            {
                if (Contenedor.TabPages.Count == 0)
                {
                    //no hay pestañas, por lo que agrego una
                    AddTab();
                }
                return (PageResult)Contenedor.SelectedTab.Controls[0];
            }
        }
        private void AddTab()
        {
            TabPage page = new TabPage("Resultado " + (Contenedor.TabPages.Count + 1).ToString());
            PageResult res = new PageResult();
            res.Dock = DockStyle.Fill;
            res.OnMessage += new OnMessageEvent(MensajeEvent);
            page.Controls.Add(res);
            Contenedor.TabPages.Add(page);
            Contenedor.SelectedTab = page;
            page.BackColor = Color.Gray;
            page.Focus();
            BCerrar.Enabled = true;
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            AddTab();
        }
        public void SetMensaje(List<string> mensaje)
        {
            CurrentePageResult.SetMensaje(mensaje);
        }
        private void MensajeEvent(string msg)
        {
            if (OnMessage != null)
                OnMessage(msg);
        }
        private bool ActivaBotones
        {
            set
            {
                BNuevo.Enabled = value;
            }
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            if (Contenedor.SelectedTab != null)
            {
                Contenedor.TabPages.Remove(Contenedor.SelectedTab);
                if (Contenedor.TabPages.Count == 0)
                    BCerrar.Enabled = false;
            }
        }

    }
}
