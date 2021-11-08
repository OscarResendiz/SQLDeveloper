using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDeveloper.Modulos.Editores
{
    public partial class CEditorComentarios : EditorManager.EditorGenerico
    {
        private string TextoRtfCopia
        {
            get
            {
                return richTextBox2.Rtf;
            }
            set
            {
                richTextBox2.Rtf = value;
            }
        }
        private IComenarioDriver FDriver;
        public IComenarioDriver Driver
        {
            get
            {
                return FDriver;
            }
            set
            {
                FDriver = value;
                FDriver.setDocumentChage(new IComentarioDriverEvent(DocumentNameChange));
            }
        }
        private int TiempoComprobacion = 60; //60 segundos
        private DateTime ProximaComprovacion;
        private bool MostrandoMensaje = false;
        
        private string Texto
        {
            get
            {
                return richTextBox1.Rtf;
            }
            set
            {
                if (value == "")
                {
                    richTextBox1.Text = "";
                    richTextBox2.Text = "";
                }
                else
                {
                    richTextBox1.Rtf = value;
                    richTextBox2.Rtf = value;
                }
                ProximaComprovacion = DateTime.Now.AddSeconds(TiempoComprobacion);
            }
        }         
        public CEditorComentarios()
        {
            InitializeComponent();
        }
        private void BFuente_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if (fontDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void BColor_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = BFColor.BackColor;
        }

        private void BBakColor_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = BBColor.BackColor;
        }

        private void BIzquierda_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void Bcentrado_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void BDerecha_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            Driver.setText(Texto);
            Driver.Save();           
            TextoRtfCopia = Texto;
            BGuardar.Enabled = false;
        }

        private void CEditorComentarios_Load(object sender, EventArgs e)
        {
            Texto = Driver.getText();
        }
        private void DocumentNameChange(int id_document)
        {
            if (id_document == Driver.getId())
            {
                this.Titulo = Driver.getName();
            }
        }


        private void Bnegritas_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.SelectionFont.Bold)
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont,FontStyle.Bold);
            else
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style &  ~FontStyle.Bold);

        }

        private void BCursiva_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.SelectionFont.Bold)
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont, FontStyle.Italic);
            else
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);

        }

        private void BSubrrallado_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.SelectionFont.Bold)
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont, FontStyle.Underline);
            else
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);

        }

        private void BFColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = BFColor.BackColor;
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            BFColor.BackColor = colorDialog1.Color;
            BColor_Click(null, null);
        }

        private void BBColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = BBColor.BackColor;
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            BBColor.BackColor = colorDialog1.Color;
            BBakColor_Click(null, null);
        }

        private void BFontDown_Click(object sender, EventArgs e)
        {
            try
            {
                float tam = richTextBox1.SelectionFont.Size - 1;
                if (richTextBox1.SelectionFont.Size <= 1)
                    return;
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily, tam, richTextBox1.SelectionFont.Style);
            }
            catch (System.Exception)
            {
                return;
            }
        }

        private void BFontUP_Click(object sender, EventArgs e)
        {
            try
            {
                float tam = richTextBox1.SelectionFont.Size + 1;
                richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily, tam, richTextBox1.SelectionFont.Style);
            }
            catch (System.Exception)
            {
                return;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TextoRtfCopia != Texto)
                BGuardar.Enabled = true;
            else
                BGuardar.Enabled = false;
            if (this.TabVisible == true && ProximaComprovacion <= DateTime.Now)
            {
                ProximaComprovacion = DateTime.Now.AddSeconds(TiempoComprobacion);
                string s = Driver.getText();
                if (s == "")
                    richTextBox3.Text = "";
                else
                    richTextBox3.Rtf = s;
                if (richTextBox3.Rtf != TextoRtfCopia)
                {
                    if (MostrandoMensaje == false)
                    {
                        MostrandoMensaje = true;
                        if (MessageBox.Show(this, "Ha cambiado el contenido.\nDesea recargar el documento?", "Documento modificado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Texto = s;
                        }
                        MostrandoMensaje=false;
                    }
                }
            }
        }
    }
}
   