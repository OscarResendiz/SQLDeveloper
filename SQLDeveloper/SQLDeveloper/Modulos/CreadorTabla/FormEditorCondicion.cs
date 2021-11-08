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
namespace SQLDeveloper.Modulos.CreadorTabla
{
    public partial class FormEditorCondicion : Form
    {
        CTabla Tabla;
        private bool FPrimero;
        public string Resultado
        {
            get;
            set;
        }
        public FormEditorCondicion(CTabla tabla)
        {
            FPrimero = false;
            Tabla = tabla;
            Resultado = "";
            InitializeComponent();
        }
        public bool Primero
        {
            set
            {
                FPrimero = value;
                if (value)
                {
                    //desactivo el panel de and or
                    PanelAndOr.Visible = false;
                    RBAnd.Checked = false;
                    RBOr.Checked = false;
                }
                else
                {
                    PanelAndOr.Visible = true;
                    RBAnd.Checked = true; //por default es and
                    RBOr.Checked = false;
                }
            }
        }
        private bool VisibleNormal
        {
            set
            {
                PanelNormal.Visible = value;
            }
        }
        private bool VisibleValores
        {
            set
            {
                PanelValores.Visible = value;
            }
        }
        private bool VisibleCampos
        {
            set
            {
                PanelCampos.Visible = value;
            }
        }
        private bool VisibleLista
        {
            set
            {
                PanelLista.Visible = value;
            }
        }
        private void CargaCampos()
        {
            ComboCampo.Items.Clear();
            ComboCampoNormal.Items.Clear();
            ComboCampoInicial.Items.Clear();
            ComboCampoFinal.Items.Clear();
            foreach (CCampo obj in Tabla.Campos)
            {
                ComboCampo.Items.Add(obj);
                ComboCampoNormal.Items.Add(obj);
                ComboCampoInicial.Items.Add(obj);
                ComboCampoFinal.Items.Add(obj);
            }
        }
        private void FormEditorCondicion_Load(object sender, EventArgs e)
        {
            VisibleNormal = false;
            VisibleValores = false;
            VisibleCampos = false;
            VisibleLista = false;
            CargaCampos();
            RecalculaTamaño();
        }
        private void ComboCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboCondicion.SelectedIndex)
            {
                case 0: //Igual (=)
                case 1: //Diferente (<>)
                case 2: //Mayor que (>)
                case 3: //Menor que (<)
                case 4: //Mayor o gual que (>=)
                case 5: //Menor o igual que (<=)
                    VisibleNormal = true;
                    VisibleValores = false;
                    VisibleCampos = false;
                    VisibleLista = false;
                    break;
                case 6: // Entre dos valores
                    VisibleNormal = false;
                    VisibleValores = true;
                    VisibleCampos = false;
                    VisibleLista = false;
                    break;
                case 7: //Entre dos campos
                    VisibleNormal = false;
                    VisibleValores = false;
                    VisibleCampos = true;
                    VisibleLista = false;
                    break;
                case 8: //Estar en una lista de valores
                case 9: //No estar en una lista de valores
                    VisibleNormal = false;
                    VisibleValores = false;
                    VisibleCampos = false;
                    VisibleLista = true;
                    break;
                case 10: //Que no sea Nulo
                    VisibleNormal = false;
                    VisibleValores = false;
                    VisibleCampos = false;
                    VisibleLista = false;
                    break;
            }
            RecalculaTamaño();
        }

        private void RBCampo_CheckedChanged(object sender, EventArgs e)
        {
            ComboCampoNormal.Enabled = RBCampo.Checked;
            TValor.Enabled=!RBCampo.Checked;
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            if(TValorLista.Text.Trim()=="")
            {
                MessageBox.Show("Falta el texto", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListaValores.Items.Add(TValorLista.Text);
            TValorLista.Text = "";
            TValorLista.Focus();
        }

        private void BQuitar_Click(object sender, EventArgs e)
        {
            if(ListaValores.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione en elemento a quitar", "Quitar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListaValores.Items.RemoveAt(ListaValores.SelectedIndex);
        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidaDatos())
            {
                DialogResult = DialogResult.None;
                return;
            }
            AsignaResultado();
            DialogResult = DialogResult.OK;
            Close();
        }
        private bool ValidaDatos()
        {
            if(ComboCampo.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione el campo a comprar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ComboCampoNormal.Focus();
                return false;

            }
            switch (ComboCondicion.SelectedIndex)
            {
                case 0: //Igual (=)
                case 1: //Diferente (<>)
                case 2: //Mayor que (>)
                case 3: //Menor que (<)
                case 4: //Mayor o gual que (>=)
                case 5: //Menor o igual que (<=)
                    if(RBCampo.Checked)
                    {
                        //hayq ue validar que se tenga un valor seleccionado
                        if(ComboCampoNormal.SelectedIndex==-1)
                        {
                            MessageBox.Show("Seleccione el campo con el que se comparará", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ComboCampoNormal.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if(TValor.Text.Trim()=="")
                        {
                            MessageBox.Show("Ingrese el valor a comprara", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            TValor.Focus();
                            return false;
                        }
                    }
                    break;
                case 6: // Entre dos valores
                    if (TValorInicial.Text.Trim() == "")
                    {
                        MessageBox.Show("Falta el valor inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TValorInicial.Focus();
                        return false;
                    }
                    if (TValorFinal.Text.Trim() == "")
                    {
                        MessageBox.Show("Falta el valor Final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TValorFinal.Focus();
                        return false;
                    }
                    break;
                case 7: //Entre dos campos
                    if (ComboCampoInicial.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione el campo inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ComboCampoInicial.Focus();
                        return false;
                    }
                    if (ComboCampoFinal.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione el campo final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ComboCampoFinal.Focus();
                        return false;
                    }
                    break;
                case 8: //Estar en una lista de valores
                case 9: //No estar en una lista de valores
                    if(ListaValores.Items.Count==0)
                    {
                        MessageBox.Show("No hay datos en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TValorLista.Focus();
                        return false;
                    }
                    break;
            }
            return true;
        }
        private void AsignaResultado()
        {
            string s = "";
            int tipo = 0;
            s = ComboCampo.Text;
            switch (ComboCondicion.SelectedIndex)
            {
                case 0: //Igual (=)
                    s += "=";
                    break;
                case 1: //Diferente (<>)
                    s += "<>";
                    break;
                case 2: //Mayor que (>)
                    s += ">";
                    break;
                case 3: //Menor que (<)
                    s += "<";
                    break;
                case 4: //Mayor o gual que (>=)
                    s += ">=";
                    break;
                case 5: //Menor o igual que (<=)
                    s += "<=";
                    break;
                case 6: // Entre dos valores
                    tipo = 1;
                    break;
                case 7: //Entre dos campos
                    tipo = 2;
                    break;
                case 8: //Estar en una lista de valores
                    tipo = 3;
                    break;
                case 9: //No estar en una lista de valores
                    tipo = 4;
                    break;
                case 10: //que no sea nulo
                    tipo = 5;
                    break;
            }
            switch(tipo)
            {
                case 0: //normal
                    if (RBCampo.Checked)
                    {
                        //hayq ue validar que se tenga un valor seleccionado
                        s += ComboCampoNormal.Text;
                    }
                    else
                    {
                        s += TValor.Text;
                    }
                    break;
                case 1: // Entre dos valores
                    s="( "+s+" >= " + TValorInicial.Text + " and " + ComboCampo.Text + " <= " + TValorFinal.Text+" )";
                    break;
                case 2://Entre dos campos
                    s = "( " + s + " >= " + ComboCampoInicial.Text + " and " + ComboCampo.Text + " <= " + ComboCampoFinal.Text + " )";
                    break;
                case 3:  //Estar en una lista de valores
                case 4: //No estar en una lista de valores
                    if (tipo == 4)
                        s += " not ";
                    s += " in (";
                    bool primer = true;
                    foreach(string s2 in ListaValores.Items)
                    {
                        if (primer == false)
                            s += ",";
                        primer = false;
                        s += s2;
                    }
                    s += ")";
                    break;
                case 5: //que no sea nulo
                    s += "  IS NOT NULL ";
                    break;
            }
            if(!FPrimero)
            {
                if(RBAnd.Checked)
                {
                    s = " AND " + s;
                }
                else
                {
                    s = " OR " + s;

                }
            }
            Resultado = s;
        }
        private void RecalculaTamaño()
        {
            int tam = PanelInicial.Height + PanelFinal.Height+ PanelCondicion.Height+ 20;
            if (PanelNormal.Visible)
                tam += PanelNormal.Height;
            if (PanelValores.Visible)
                tam += PanelValores.Height;
            if (PanelCampos.Visible)
                tam += PanelCampos.Height;
            if (PanelLista.Visible)
                tam += PanelLista.Height;
            Height = tam;

        }

        private void TValorLista_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TValorLista.Text.Trim() != "")
                {
                    e.Handled = true;
                    BAgregar_Click(sender, e);
                }
            }
        }

    }
}
