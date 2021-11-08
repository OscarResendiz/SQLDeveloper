using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            //if(label1.Text!="")
            {
                motor.SetConnectionName(textBox2.Text);
                motor.SetConnectionString(textBox1.Text);
            }
            if(motor.ShowDlgConfig()== DialogResult.OK)
            {
                textBox2.Text = motor.GetConnectionName();
                textBox1.Text = motor.GetConecctionString();
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.CAMPO);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.CHECK);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.FOREIGNKEY);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.FUNCION);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.IDENTITY);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.INDEX);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.NONE);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.PRIMARYKEY);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.PROCEDURE);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.TABLE);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.TIPEDATA);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.TRIGER);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.UNIQUE);
            comboBox1.Items.Add(MotorDB.EnumTipoObjeto.VIEW);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            MotorDB.EnumTipoObjeto modo = (MotorDB.EnumTipoObjeto)comboBox1.SelectedItem;
            string nombre = textBox3.Text;
            List<MotorDB.CObjeto> objetos;
            objetos = motor.Buscar(nombre, modo);
            listBox1.Items.Clear();
            foreach (MotorDB.CObjeto obj in objetos)
            {
                listBox1.Items.Add(obj);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            List<MotorDB.CObjeto> l=        motor.BuscaEnTablas(textBox3.Text);
            listBox1.Items.Clear();
            foreach (MotorDB.CObjeto obj in l)
            {
                listBox1.Items.Add(obj);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            List<MotorDB.CCampo> l;
            l = motor.DameCamposTabla(textBox3.Text);
            listBox1.Items.Clear();
            foreach (MotorDB.CCampo obj in l)
            {
                listBox1.Items.Add(obj);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            List<MotorDB.CCampoBase> l;
            l = motor.DameCamposVista(textBox3.Text);
            listBox1.Items.Clear();
            foreach (MotorDB.CCampoBase obj in l)
            {
                listBox1.Items.Add(obj);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            richTextBox1.Text = motor.DameCodigoFuncction(textBox3.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            richTextBox1.Text = motor.DameCodigoStoreProcedure(textBox3.Text);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            richTextBox1.Text = motor.DameCodigoVista(textBox3.Text);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            MotorDB.CPrimaryKey pk = motor.DameLLavePrimaria(textBox3.Text);
            if(pk==null)
            {
                return;
            }
            listBox1.Items.Add(pk.Nombre);
            foreach(MotorDB.CCampoBase obj in pk.Campos)
            {
                listBox1.Items.Add(obj);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            MotorDB.IMotorDB motor = MotorDB.CProviderDataBase.DameMotor(MotorDB.EnumMotoresDB.SQLSERVER);
            motor.SetConnectionName(textBox2.Text);
            motor.SetConnectionString(textBox1.Text);
            List<MotorDB.CForeignKey> l = motor.DameLLavesForaneas(textBox3.Text);
            listBox1.Items.Clear();
            foreach(MotorDB.CForeignKey fk in l)
            {
                listBox1.Items.Add(fk);
                listBox1.Items.Add(fk.TablaPadre);
                listBox1.Items.Add(fk.TablaHija);
                foreach(MotorDB.CCampoFereneces obj in fk.Campos)
                {
                    listBox1.Items.Add(obj.CampoPadre+"->"+obj.CampoHijo);
                }
                listBox1.Items.Add("-----------------------------------------------");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            textBox3.Text = listBox1.SelectedItem.ToString();
        }
    }
}
