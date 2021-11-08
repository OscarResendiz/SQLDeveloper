using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.AppsAnalizer.Formularios
{
    public delegate void FormBuscadorObjetosEvent(int id_objeto) ;
    public partial class FormBuscadorObjetos : Form
    {
        public event FormBuscadorObjetosEvent ObjetoAgregadoEvent;
        private List<Buscador.CNodoBusqueda> Encontrados = new List<Buscador.CNodoBusqueda>();
        private List<Buscador.CNodoBusqueda> Cache= new List<Buscador.CNodoBusqueda>();

        ObjetosModelo.AppModel Modelo;
        List<ObjetosModelo.CServidor> Servidores; 
        public FormBuscadorObjetos(ObjetosModelo.AppModel modelo)
        {
            Modelo = modelo;
            InitializeComponent();
        }

        private void FormBuscadorObjetos_Load(object sender, EventArgs e)
        {
            CargaConexiones();
            CargaTipos();
        }
        private void CargaConexiones()
        {
            Servidores = Modelo.GetServidores();
            foreach (ObjetosModelo.CServidor ser in Servidores)
            {
                List<ObjetosModelo.CConexion> l = Modelo.GetConexiones(ser.ID_Servidor);
                foreach(ObjetosModelo.CConexion con in l)
                {
                    ManagerConnect.CConexion conexion= ManagerConnect.ControladorConexiones.GetConexion(ser.Nombre,con.Nombre);
                    cBuscadorAvanzado1.AgregaMotor(ManagerConnect.ControladorConexiones.DameMotor(conexion));
                }
            }
        }
        private void CargaTipos()
        {
            if (ComboTipo.Items.Count == 0)
            {
                ComboTipo.Items.Clear();
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Todos", MotorDB.EnumTipoObjeto.NONE));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Tablas", MotorDB.EnumTipoObjeto.TABLE));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Type Table", MotorDB.EnumTipoObjeto.TYPE_TABLE));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Vistas", MotorDB.EnumTipoObjeto.VIEW));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Procediientos almacenados", MotorDB.EnumTipoObjeto.PROCEDURE));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Funciones", MotorDB.EnumTipoObjeto.FUNCION));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Trigers", MotorDB.EnumTipoObjeto.TRIGER));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Buscar campos en objetos", MotorDB.EnumTipoObjeto.CAMPO));
                ComboTipo.Items.Add(new MotorDB.CTipoBusqueda("Buscar en el codigo", MotorDB.EnumTipoObjeto.CODE));
                ComboTipo.SelectedIndex = 0;
            }

        }
        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (TNombre.Text.Trim() == "")
            {
                MessageBox.Show("Falta el texto a buscar", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cache.Clear();
            TFiltro.Text = "";
            cBuscadorAvanzado1.DameFiltros().Clear();
            MotorDB.CTipoBusqueda busqueda = (MotorDB.CTipoBusqueda)ComboTipo.SelectedItem;
            Buscador.OPERADOR operador = Buscador.OPERADOR.NONE;
            Buscador.CFiltro filtro = new Buscador.CFiltro(TNombre.Text, busqueda.Tipo, operador);
            cBuscadorAvanzado1.AgregarFiltro(filtro);
            cBuscadorAvanzado1.Buscar();
        }

        private void cBuscadorAvanzado1_OnInicioBusqueda(Buscador.CBuscadorAvanzado sender)
        {
            BBuscar.Enabled = false;
            ComboTipo.Enabled = false;
            ListaObjetos.Items.Clear();
            Encontrados.Clear();
        }

        private void cBuscadorAvanzado1_OnFinBusqueda(Buscador.CBuscadorAvanzado sender)
        {
            BBuscar.Enabled = true;
            ComboTipo.Enabled = true;

        }

        private void cBuscadorAvanzado1_OnObjetoEncontrado(Buscador.CBuscadorAvanzado sender, Buscador.CObjetoBusquedaAvanzado obj)
        {
            Buscador.CNodoBusqueda nodo = new Buscador.CNodoBusqueda();
            nodo.Nombre = obj.Nombre;
            nodo.Tipo = obj.Tipo;
            nodo.Motor = obj.Motor;
            Encontrados.Add(nodo);
            Cache.Add(nodo);

        }

        private void TimerLLena_Tick(object sender, EventArgs e)
        {
            while (Encontrados.Count() > 0)
            {
                Buscador.CNodoBusqueda nodo = Encontrados[0];
                Encontrados.RemoveAt(0);
                if (nodo != null)
                {
                    ListaObjetos.Items.Add(nodo);
                }
                LResultado.Text = ListaObjetos.Items.Count.ToString() + " Objetos encontrados";
            }

        }
        
        private void BAgregar_Click(object sender, EventArgs e)
        {
            foreach(Buscador.CNodoBusqueda nodo in ListaObjetos.CheckedItems)
            {
                ManagerConnect.CPropiedadesMotor propiedades = ManagerConnect.ControladorConexiones.DamePropiedadesMotor(nodo.Motor);
                //busco elservidor
                foreach(ObjetosModelo.CServidor servidor in Servidores)
                {
                    if(servidor.Nombre==propiedades.Grupo)
                    {
                        //me traigo las conexiones del servidor
                        List<ObjetosModelo.CConexion> l = Modelo.GetConexiones(servidor.ID_Servidor);
                        //ahora busco la conexion
                        foreach(ObjetosModelo.CConexion conexion in l)
                        {
                            if(conexion.Nombre==propiedades.Conexion.Nombre)
                            {
                                int id_objeto=Modelo.InsertObjeto(conexion.ID_Conexion, nodo.Nombre, nodo.Tipo, false, "", Color.White);
                                if (ObjetoAgregadoEvent != null)
                                    ObjetoAgregadoEvent(id_objeto);
                                //me salgo del bucle
                                break;
                            }
                        }
                        //me salgo del bucle
                        break;
                    }
                }
            }
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListaObjetos.Items.Clear();
            foreach (Buscador.CNodoBusqueda obj in Cache)
            {
                if (obj.ToString().ToUpper().Contains(TFiltro.Text.ToUpper().Trim()))
                {
                    ListaObjetos.Items.Add(obj);
                }

            }

            
        }
    }
}
   