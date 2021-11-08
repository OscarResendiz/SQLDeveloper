using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SintaxColor;

namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    public partial class KeyWordControl : CControlBase
    {
        private CKeyWords KeyWords;
        public KeyWordControl()
        {
            InitializeComponent();
        }
        public string Nombre
        {
            get
            {
                return TNombre.Text;
            }
            set
            {
                TNombre.Text=value;
            }
        }
        public bool Negrita
        {
            get
            {
                return ChNegrita.Checked;
            }
            set
            {
                ChNegrita.Checked = value;
            }
        }
        public bool Cursiva
        {
            get
            {
                return ChCursiva.Checked;
            }
            set
            {
                ChCursiva.Checked = value;
            }
        }
        public Color Color
        {
            get
            {
                return ColorWords.Color;
            }
            set
            {
                ColorWords.Color = value;
            }
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            KeyWords = (CKeyWords)Objeto;
            Nombre = KeyWords.name;
            Negrita = KeyWords.bold;
            Cursiva = KeyWords.italic;
            Color = KeyWords.Color.Color;
            CargaKeyWords();
        }

        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            KeyWords.name = Nombre;

        }

        private void ChNegrita_CheckedChanged(object sender, EventArgs e)
        {
            KeyWords.bold = Negrita;

        }

        private void ChCursiva_CheckedChanged(object sender, EventArgs e)
        {
            KeyWords.italic = Cursiva;

        }

        private void ColorWords_OnColorCahnge(CComponetColor sender, Color color)
        {
            KeyWords.Color.Color = Color;

        }
        private void CargaKeyWords()
        {
            Lista.Items.Clear();
            foreach(CKey obj in KeyWords.Keys )
            {
                Lista.Items.Add(obj);
            }
        }

        private void Bagregar_Click(object sender, EventArgs e)
        {
            FormPalabra dlg = new FormPalabra();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            CKey key=new CKey();
            key.Word=dlg.Palabra;
            KeyWords.Add(key);
            CargaKeyWords();
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (Lista.SelectedIndex == -1)
                return;
            if (MessageBox.Show("¿Eliminar la palabra reservada?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            CKey obj = (CKey)Lista.SelectedItem;
            Lista.Items.Remove(obj);
            KeyWords.Keys.Remove(obj);
            CargaKeyWords();
        }
    }
}
