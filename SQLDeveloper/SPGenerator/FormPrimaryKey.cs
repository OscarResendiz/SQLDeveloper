using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPGenerator
{
    public partial class FormPrimaryKey : Form
    {
        public FormPrimaryKey(List<Objetos.CParametroSP> l)
        {
            InitializeComponent();
            foreach (Objetos.CParametroSP obj in l)
            {
                Campos.Items.Add(obj, obj.LLavePrimaria);
            }
        }
        public bool EsLLave(int pos)
        {
            int i, n;
            n = Campos.CheckedIndices.Count;
            for (i = 0; i < n; i++)
            {

                if (Campos.CheckedIndices[i] == pos)
                    return true;
            }
            return false;
        }
    }
}