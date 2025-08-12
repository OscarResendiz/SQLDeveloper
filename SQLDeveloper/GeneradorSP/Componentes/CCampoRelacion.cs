using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorSP.Componentes
{
    public delegate void OnDameCamposEvent(ref List<string> l);
    public partial class CCampoRelacion : UserControl
    {
        public event OnDameCamposEvent OnDameCampos;
        public CCampoRelacion()
        {
            InitializeComponent();
        }
        public string Texto
        {
            get
            {
                return TCampo.Text;
            }
            set
            {
                TCampo.Text = value;
            }
        }
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return ComboCampo.Items;
            }
        }
        public int SelectedIndex
        {
            get
            {
                return ComboCampo.SelectedIndex;
            }
            set
            {
                ComboCampo.SelectedIndex = value;
            }
        }

        private void ComboCampo_DropDown(object sender, EventArgs e)
        {
            if (OnDameCampos != null)
            {
                ComboCampo.SelectedIndex = -1;
                ComboCampo.Items.Clear();
                List<string> l = new List<string>();
                OnDameCampos(ref l);
                foreach (string s in l)
                {
                    ComboCampo.Items.Add(s);
                }
            }
        }
    }
}
