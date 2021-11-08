using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Buscador
{
    public delegate void OnFiltroEvent(CFiltro filtro);
    public partial class FormFiltro : Form
    {
        public event OnFiltroEvent OnFiltro;
        private bool OperadorEnable = true;
        public FormFiltro(bool operadores = true)
        {
            OperadorEnable = operadores;
            InitializeComponent();
        }

        private void FormFiltro_Load(object sender, EventArgs e)
        {
            CargaTipos();
            cargaOperadores();
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
        private void cargaOperadores()
        {
            if (ComboOperador.Items.Count == 0)
            {
                ComboOperador.Items.Clear();
                ComboOperador.Items.Add(OPERADOR.AND);
                ComboOperador.Items.Add(OPERADOR.OR);
                ComboOperador.Items.Add(OPERADOR.NOT);
            }
            Loperador.Visible = OperadorEnable;
            ComboOperador.Visible = OperadorEnable;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (TNombre.Text == "")
            {
                MessageBox.Show("Falta el texto a buscar", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MotorDB.CTipoBusqueda busqueda = (MotorDB.CTipoBusqueda)ComboTipo.SelectedItem;
            if (busqueda == null)
            {
                MessageBox.Show("Falta el tipo de busqueda", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OPERADOR operador = OPERADOR.NONE;
            if (OperadorEnable)
            {
                if (ComboOperador.SelectedItem == null)
                {
                    MessageBox.Show("Falta el operador de busqueda", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                operador = (OPERADOR)ComboOperador.SelectedItem;
            }
            CFiltro filtro = new CFiltro(TNombre.Text, busqueda.Tipo, operador);
            if (OnFiltro != null)
                OnFiltro(filtro);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        public CFiltro Filtro
        {
            set
            {
                if (value == null)
                    return;
                if (value.operador != OPERADOR.NONE)
                {
                    if (ComboOperador.Items.Count == 0)
                    {
                        cargaOperadores();
                    }
                    for (int i = 0; i < ComboOperador.Items.Count; i++)
                    {
                        OPERADOR oper = (OPERADOR)ComboOperador.Items[i];
                        if (value.operador == oper)
                        {
                            ComboOperador.SelectedIndex = i;
                            break;
                        }

                    }
                }
                TNombre.Text = value.Cadena;
                if (ComboTipo.Items.Count == 0)
                    CargaTipos();
                for (int i = 0; i < ComboTipo.Items.Count; i++)
                {
                    MotorDB.CTipoBusqueda tp = (MotorDB.CTipoBusqueda)ComboTipo.Items[i];
                    if (value.Tipo == tp.Tipo)
                    {
                        ComboTipo.SelectedIndex = i;
                        break;
                    }
                }
            }

        }

    }
}
