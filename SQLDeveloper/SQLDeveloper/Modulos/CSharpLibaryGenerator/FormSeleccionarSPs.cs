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
namespace SQLDeveloper.Modulos.CSharpLibaryGenerator
{
    public partial class FormSeleccionarSPs : Form
    {
        private List<Modulos.Buscador.CNodoBusqueda> Encontrados = new List<Modulos.Buscador.CNodoBusqueda>();
        private bool NorecargarFiltros;
        public event OnVerObjetoEvent OnVerObjeto;
        ManagerConnect.CNodoRaiz NodoRaiz;
        public FormSeleccionarSPs()
        {
            InitializeComponent();
        }
        public void AgregaMotor(IMotorDB motor)
        {
            cBuscadorAvanzado1.AgregaMotor(motor);
        }

        private void BAgregarFiltro_Click(object sender, EventArgs e)
        {
            bool tipos = true;
            if (cBuscadorAvanzado1.DameFiltros().Count == 0)
                tipos = false;
            Modulos.Buscador.FormFiltro dlg = new Modulos.Buscador.FormFiltro(tipos);
            dlg.OnFiltro += new Modulos.Buscador.OnFiltroEvent(OnFiltro);
            dlg.ShowDialog();
        }
        private void OnFiltro(Modulos.Buscador.CFiltro filtro)
        {
            cBuscadorAvanzado1.AgregarFiltro(filtro);
        }
        private void BBuscar_Click(object sender, EventArgs e)
        {
            //me traigo las conexiones seleccionadas
            List<ManagerConnect.CConexion> conexiones = NodoRaiz.DameConexionesSeleccionadas();
            if(conexiones .Count()==0)
            {
                MessageBox.Show("Seleccione las conexiones a buscar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //agrego las conexiones
            cBuscadorAvanzado1.DameMotores().Clear();
            foreach(ManagerConnect.CConexion obj in conexiones)
            {

                cBuscadorAvanzado1.AgregaMotor(ManagerConnect.ControladorConexiones.DameMotor(obj));
            }
            if(cBuscadorAvanzado1.DameFiltros().Count()==0)
            {
                MessageBox.Show("Tiene que agregar los filtros de busqueda", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cBuscadorAvanzado1.Buscar();
        }

        private void cBuscadorAvanzado1_OnInicioBusqueda(Modulos.Buscador.CBuscadorAvanzado sender)
        {
            LResultado.Text = "Buscando";
            Encontrados = new List<Modulos.Buscador.CNodoBusqueda>();
            ListaObjetos.Nodes.Clear();
            waitControl1.Animar = true;
        }

        private void cBuscadorAvanzado1_OnFinBusqueda(Modulos.Buscador.CBuscadorAvanzado sender)
        {
            waitControl1.Animar = false;

        }

        private void cBuscadorAvanzado1_OnObjetoEncontrado(Modulos.Buscador.CBuscadorAvanzado sender, Modulos.Buscador.CObjetoBusquedaAvanzado obj)
        {
//            TimerLLena.Enabled = true;
            Modulos.Buscador.CNodoBusqueda nodo = new Modulos.Buscador.CNodoBusqueda();
            nodo.Nombre = obj.Nombre;
            nodo.Tipo = obj.Tipo;
            nodo.Motor = obj.Motor;
            Encontrados.Add(nodo);
        }

        private void TimerLLena_Tick(object sender, EventArgs e)
        {
            while(Encontrados.Count()>0)
            {
                Modulos.Buscador.CNodoBusqueda nodo = Encontrados[0];
                Encontrados.RemoveAt(0);
                ListaObjetos.Nodes.Add(nodo);
                LResultado.Text =ListaObjetos.Nodes.Count.ToString()+ " Objetos encontrados";
            }
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Modulos.Buscador.CNodoBusqueda nodo in ListaObjetos.Nodes)
            {
                if (OnVerObjeto != null)
                {
                    OnVerObjeto(nodo.Motor,nodo.Nombre, nodo.Tipo);
                }
            }
        }

        private void ListaObjetos_DoubleClick(object sender, EventArgs e)
        {
            if (ListaObjetos.SelectedNode == null)
                return;
            Modulos.Buscador.CNodoBusqueda nodo = (Modulos.Buscador.CNodoBusqueda)ListaObjetos.SelectedNode;
            if (OnVerObjeto != null)
            {
                OnVerObjeto(nodo.Motor,nodo.Nombre, nodo.Tipo);
            }

        }

        private void cBuscadorAvanzado1_OnFiltroChange(Buscador.CBuscadorAvanzado sender)
        {

        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            cBuscadorAvanzado1.DameFiltros().Clear();
            cBuscadorAvanzado1.AgregarFiltro(new Buscador.CFiltro()
            {
                Cadena = TNombre.Text.Trim()
                 ,
                operador = Buscador.OPERADOR.NONE
                 ,
                Tipo = EnumTipoObjeto.PROCEDURE
            });
            TimerBuscar.Enabled = false;
            TimerBuscar.Enabled = true;
        }

        private void TimerBuscar_Tick(object sender, EventArgs e)
        {
            TimerBuscar.Enabled = false;
            cBuscadorAvanzado1.Buscar();
        }
    }
}
