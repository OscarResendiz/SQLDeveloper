using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorManager
{
    public delegate void OnCerrarEvent();
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }
        public virtual void Guardar()
        {
            //este codigo hay que sobre escribirlo
        }
        public virtual void ActualizaColores()
        {
            //este codigo hay que sobre escribirlo
        }
        public virtual void Abrir()
        {
            //este codigo hay que sobre escribirlo
        }
    }
}
