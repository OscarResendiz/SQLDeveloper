using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace GeneradorSP.Componentes
{
    public partial class CRelacionTabla : UserControl
    {
        private int pos;
        public List<string> Campos;
        public CRelacionTabla()
        {
            Campos = new List<string>();
            InitializeComponent();
            pos = 0;
        }
        public void Clear()
        {
            PCampos.Controls.Clear();
            pos = 0;
        }
        public void Add(string Campo)
        {
            CCampoRelacion cr = new CCampoRelacion();
            cr.Parent = PCampos;
            cr.OnDameCampos += new OnDameCamposEvent(DameCampos);
            cr.Top = pos;
            pos = pos + cr.Height;
            cr.Texto = Campo;
        }
        private void DameCampos(ref List<string> l)
        {
            foreach (string s in Campos)//
            {
                bool encontrado = false;
                foreach (CCampoRelacion c in PCampos.Controls)
                {
                    if (c.SelectedIndex != -1)
                    {
                        string s2 = (string)c.Items[c.SelectedIndex];
                        if (s2.ToLower().Trim() == s.ToLower().Trim())
                        {
                            encontrado = true;
                            break;
                        }
                    }
                }
                if (encontrado == false)
                {
                    l.Add(s);
                }
            }
        }
        public bool TodosAsignados
        {
            get
            {
                foreach (CCampoRelacion c in PCampos.Controls)
                {
                    if (c.SelectedIndex == -1)
                        return false;
                }
                return true;
            }
        }
        public List<CCampoFK> Relaciones
        {
            get
            {
                List<CCampoFK> l = new List<CCampoFK>();
                foreach (CCampoRelacion c in PCampos.Controls)
                {
                    CCampoFK obj = new CCampoFK();
                    obj.columnahija = (string)c.Items[c.SelectedIndex];
                    obj.columnaMaestra = c.Texto;
                    l.Add(obj);
                }
                return l;
            }
        }
    }
}
