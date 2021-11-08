using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridControl
{
    public delegate void OnFormColumnasEvent(FormColumnas dlg);
    public partial class FormColumnas : Form
    {
        public event OnFormColumnasEvent OnColumnasSeleccionadas;
        public event OnFormColumnasEvent OnFormClose;
        private DataTable Ftabla;
        public FormColumnas()
        {
            InitializeComponent();
        }
        public DataTable Tabla
        {
            get
            {
                return Ftabla;
            }
            set
            {
                Ftabla = value;
                CargaCampos();
            }
        }

        private void FormColumnas_Load(object sender, EventArgs e)
        {
        }
        private void CargaCampos()
        {
            Contenedor.Controls.Clear();
            if (Ftabla == null)
                return;
            ControlColumns obj = new ControlColumns();
            obj.Tabla = Ftabla;
            Contenedor.Controls.Add(obj);
            if (Contenedor.Controls.Count == 1)
            {
                Contenedor.Controls[0].Dock = DockStyle.Fill;
            }
            else
            {
                int n = Contenedor.Controls.Count;
                for (int i = n - 1; i >= 0; i--)
                {
                    Contenedor.Controls[i].Dock = DockStyle.Top;
                }

            }
        }
        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
            if (OnFormClose != null)
                OnFormClose(this);
    }
    public List<CTablaColumnas> TablasSeleccionadas
        {
            get
            {
                List<CTablaColumnas> resp = new List<CTablaColumnas>();
                //regresa la lista de tablas seleccionadas
                foreach (ControlColumns obj in Contenedor.Controls)
                {
                    resp.Add(obj.Columnas);

                }
                return resp;
            }
            set
            {
                if(value==null)
                    return;
                List<CTablaColumnas> lista = value;
                foreach (ControlColumns obj in Contenedor.Controls)
                {
                    //busco la tabla que le corresponde
                    foreach(CTablaColumnas tc in lista)
                    {
                        if(obj.TableName==tc.Tabla)
                        {
                            obj.Columnas = tc;
                        }
                    }
                }
            }

        }

        private void BAplicar_Click(object sender, EventArgs e)
        {
            if (OnColumnasSeleccionadas != null)
                OnColumnasSeleccionadas(this);

    }
}
}
