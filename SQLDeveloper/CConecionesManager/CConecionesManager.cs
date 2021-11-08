using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerConnect
{
    public partial class CConecionesManager : UserControl
    {
        CNodoRaiz NodoRaiz;
        public CConecionesManager()
        {
            InitializeComponent();
        }
        public MotorDB.IMotorDB MotorInicial
        {
            get;
            set;
        }

        public void CargaConexiones()
        {
            NodoRaiz = new CNodoRaiz();
            treeView1.Nodes.Add(NodoRaiz);
            NodoRaiz.CargaGrupos();
            if (MotorInicial != null)
            {
                NodoRaiz.MarcaMotor(MotorInicial);
            }
        }
        public List<CConexion> DameConexionesSeleccionadas()
        {
            return NodoRaiz.DameConexionesSeleccionadas();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CNodoBase nodo = (CNodoBase)e.Node;
            nodo.AfterCheck();
        }
    }
}
