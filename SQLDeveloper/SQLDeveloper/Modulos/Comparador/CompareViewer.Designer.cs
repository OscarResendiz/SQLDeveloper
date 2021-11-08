namespace SQLDeveloper.Modulos.Comparador
{
    partial class CompareViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Contenedor = new System.Windows.Forms.SplitContainer();
            this.TCodigoIzqierdo = new ICSharpCode.TextEditor.TextEditorControl();
            this.LIzquierdo = new System.Windows.Forms.Label();
            this.TCodigoDerecho = new ICSharpCode.TextEditor.TextEditorControl();
            this.LDerecho = new System.Windows.Forms.Label();
            this.textComparator21 = new SQLDeveloper.Modulos.Comparador.TextComparator();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waitControl1 = new WaitControl.WaitControl();
            ((System.ComponentModel.ISupportInitialize)(this.Contenedor)).BeginInit();
            this.Contenedor.Panel1.SuspendLayout();
            this.Contenedor.Panel2.SuspendLayout();
            this.Contenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textComparator21)).BeginInit();
            this.SuspendLayout();
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Contenedor.Name = "Contenedor";
            // 
            // Contenedor.Panel1
            // 
            this.Contenedor.Panel1.Controls.Add(this.TCodigoIzqierdo);
            this.Contenedor.Panel1.Controls.Add(this.LIzquierdo);
            // 
            // Contenedor.Panel2
            // 
            this.Contenedor.Panel2.Controls.Add(this.TCodigoDerecho);
            this.Contenedor.Panel2.Controls.Add(this.LDerecho);
            this.Contenedor.Size = new System.Drawing.Size(741, 491);
            this.Contenedor.SplitterDistance = 368;
            this.Contenedor.TabIndex = 2;
            // 
            // TCodigoIzqierdo
            // 
            this.TCodigoIzqierdo.AutoScroll = true;
            this.TCodigoIzqierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigoIzqierdo.IsReadOnly = false;
            this.TCodigoIzqierdo.Location = new System.Drawing.Point(0, 33);
            this.TCodigoIzqierdo.Name = "TCodigoIzqierdo";
            this.TCodigoIzqierdo.Size = new System.Drawing.Size(368, 458);
            this.TCodigoIzqierdo.TabIndex = 0;
            this.TCodigoIzqierdo.Text = "textEditorControl1";
            this.TCodigoIzqierdo.OnVScrollBarValueChanged += new System.EventHandler(this.TCodigoIzqierdo_OnVScrollBarValueChanged);
            this.TCodigoIzqierdo.OnHScrollBarValueChanged += new System.EventHandler(this.TCodigoIzqierdo_OnHScrollBarValueChanged);
            this.TCodigoIzqierdo.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TCodigoIzqierdo_Scroll);
            // 
            // LIzquierdo
            // 
            this.LIzquierdo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.LIzquierdo.Name = "LIzquierdo";
            this.LIzquierdo.Padding = new System.Windows.Forms.Padding(5);
            this.LIzquierdo.Size = new System.Drawing.Size(368, 33);
            this.LIzquierdo.TabIndex = 1;
            this.LIzquierdo.Text = "label1";
            // 
            // TCodigoDerecho
            // 
            this.TCodigoDerecho.AutoScroll = true;
            this.TCodigoDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCodigoDerecho.IsReadOnly = false;
            this.TCodigoDerecho.Location = new System.Drawing.Point(0, 33);
            this.TCodigoDerecho.Name = "TCodigoDerecho";
            this.TCodigoDerecho.Size = new System.Drawing.Size(369, 458);
            this.TCodigoDerecho.TabIndex = 0;
            this.TCodigoDerecho.Text = "textEditorControl2";
            this.TCodigoDerecho.OnVScrollBarValueChanged += new System.EventHandler(this.TCodigoDerecho_OnVScrollBarValueChanged);
            this.TCodigoDerecho.OnHScrollBarValueChanged += new System.EventHandler(this.TCodigoDerecho_OnHScrollBarValueChanged);
            this.TCodigoDerecho.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TCodigoDerecho_Scroll);
            // 
            // LDerecho
            // 
            this.LDerecho.Dock = System.Windows.Forms.DockStyle.Top;
            this.LDerecho.Location = new System.Drawing.Point(0, 0);
            this.LDerecho.Name = "LDerecho";
            this.LDerecho.Padding = new System.Windows.Forms.Padding(5);
            this.LDerecho.Size = new System.Drawing.Size(369, 33);
            this.LDerecho.TabIndex = 1;
            this.LDerecho.Text = "label2";
            // 
            // textComparator21
            // 
//            this.textComparator21.DataSetName = "TextComparator2";
  //          this.textComparator21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // waitControl1
            // 
            this.waitControl1.AnchoBarraInterior = 25;
            this.waitControl1.Animar = true;
            this.waitControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.Location = new System.Drawing.Point(108, 206);
            this.waitControl1.ModoGradiente = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.waitControl1.Name = "waitControl1";
            this.waitControl1.PrimerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.waitControl1.SegundoColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.waitControl1.Size = new System.Drawing.Size(554, 43);
            this.waitControl1.TabIndex = 6;
            // 
            // CompareViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.waitControl1);
            this.Controls.Add(this.Contenedor);
            this.Name = "CompareViewer";
            this.Size = new System.Drawing.Size(741, 491);
            this.Load += new System.EventHandler(this.CompareViewer_Load);
            this.Contenedor.Panel1.ResumeLayout(false);
            this.Contenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Contenedor)).EndInit();
            this.Contenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textComparator21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Contenedor;
        private ICSharpCode.TextEditor.TextEditorControl TCodigoIzqierdo;
        private System.Windows.Forms.Label LIzquierdo;
        private ICSharpCode.TextEditor.TextEditorControl TCodigoDerecho;
        private System.Windows.Forms.Label LDerecho;
        private TextComparator textComparator21;
        private System.Windows.Forms.Timer timer1;
        private WaitControl.WaitControl waitControl1;
    }
}
