﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorDB;
namespace SQLDeveloper.Modulos.Visores.Tabla
{
    public partial class FormQuitarCampo : Form
    {
        string NombreTabla;
        CTabla Tabla;
        MotorDB.IMotorDB motor;
        public FormQuitarCampo(string tabla,MotorDB.IMotorDB db)
        {
            motor = db;
            NombreTabla = tabla;

            InitializeComponent();
        }

        private void FormQuitarCampo_Load(object sender, EventArgs e)
        {
            CargaTabla();
        }
        private void CargaTabla()
        {
            BDeafult.Enabled = false;
            ComboCampos.Items.Clear();
            Tabla = motor.DameTabla(NombreTabla);
            TTabla.Text = Tabla.Nombre;
            //lleno el combo
            foreach (CCampo obj in Tabla.Campos)
            {
                ComboCampos.Items.Add(obj);
            }

        }
        private void BAceptar_Click(object sender, EventArgs e)
        {
            if(ComboCampos.SelectedIndex==-1)
            {
                MessageBox.Show("Seleccione el campo a elimnar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            try
            {
                CCampo campo =(CCampo)ComboCampos.SelectedItem;
                if (MessageBox.Show("¿Seguro que desea eliminar el campo " + campo.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    DialogResult = DialogResult.None;
                    return;
                }
                motor.AlterTable_DropColumn(Tabla.Nombre, campo.Nombre);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
        }

        private void ComboCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCampo campo = (CCampo)ComboCampos.SelectedItem;
            //mando a mostrar las propiedades del campo seleccionado
            CpropiedadesCampo propiedades = new CpropiedadesCampo(campo, Tabla.Identidad);
            if (Tabla.EsPrimaryKey(campo))
            {
                propiedades.SetPrimaryKey(Tabla.PrimaryKey);
            }
            propertyGrid1.SelectedObject = propiedades;
            BDeafult.Enabled = campo.EsDefault;
        }

        private void BUniques_Click(object sender, EventArgs e)
        {
            FormUniques dlg = new FormUniques(Tabla.Nombre, motor);
            dlg.ShowDialog();
        }

        private void BDeafult_Click(object sender, EventArgs e)
        {
            CCampo campo = (CCampo)ComboCampos.SelectedItem;
            if (MessageBox.Show("Seguro que quiere quitar el valor default al campo: " + campo.Nombre, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                motor.AlterTable_DropDefault(Tabla.Nombre, campo.DefaultName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            CargaTabla();
        }

        private void Bchecks_Click(object sender, EventArgs e)
        {
            FormChecks dlg = new FormChecks(Tabla.Nombre, motor);
            dlg.Show();
        }
    }
}
