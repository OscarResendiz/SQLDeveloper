namespace SPGenerator
{
    partial class AnimatedWaitTextBox
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimatedWaitTextBox));
            this.Edit = new System.Windows.Forms.TextBox();
            this.Step = new System.Windows.Forms.Timer(this.components);
            this.IList = new System.Windows.Forms.ImageList(this.components);
            this.Img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Img)).BeginInit();
            this.SuspendLayout();
            // 
            // Edit
            // 
            this.Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Edit.Location = new System.Drawing.Point(0, 0);
            this.Edit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(178, 22);
            this.Edit.TabIndex = 0;
            this.Edit.TextChanged += new System.EventHandler(this.Edit_TextChanged);
            this.Edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Edit_KeyPress);
            // 
            // Step
            // 
            this.Step.Tick += new System.EventHandler(this.Step_Tick);
            // 
            // IList
            // 
            this.IList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IList.ImageStream")));
            this.IList.TransparentColor = System.Drawing.Color.Transparent;
            this.IList.Images.SetKeyName(0, "LoadFrame00.GIF");
            this.IList.Images.SetKeyName(1, "LoadFrame01.GIF");
            this.IList.Images.SetKeyName(2, "LoadFrame02.GIF");
            this.IList.Images.SetKeyName(3, "LoadFrame03.GIF");
            this.IList.Images.SetKeyName(4, "LoadFrame04.GIF");
            this.IList.Images.SetKeyName(5, "LoadFrame05.GIF");
            this.IList.Images.SetKeyName(6, "LoadFrame06.GIF");
            this.IList.Images.SetKeyName(7, "LoadFrame07.GIF");
            this.IList.Images.SetKeyName(8, "LoadFrame08.GIF");
            this.IList.Images.SetKeyName(9, "LoadFrame09.GIF");
            this.IList.Images.SetKeyName(10, "LoadFrame10.GIF");
            this.IList.Images.SetKeyName(11, "LoadFrame11.GIF");
            this.IList.Images.SetKeyName(12, "LoadFrame12.GIF");
            this.IList.Images.SetKeyName(13, "LoadFrame13.GIF");
            // 
            // Img
            // 
            this.Img.BackColor = System.Drawing.Color.Transparent;
            this.Img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Img.Dock = System.Windows.Forms.DockStyle.Right;
            this.Img.Location = new System.Drawing.Point(178, 0);
            this.Img.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Img.Name = "Img";
            this.Img.Size = new System.Drawing.Size(22, 22);
            this.Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img.TabIndex = 1;
            this.Img.TabStop = false;
            // 
            // AnimatedWaitTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Img);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "AnimatedWaitTextBox";
            this.Size = new System.Drawing.Size(200, 22);
            this.FontChanged += new System.EventHandler(this.TOText_FontChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Edit;
        public System.Windows.Forms.PictureBox Img;
        private System.Windows.Forms.Timer Step;
        private System.Windows.Forms.ImageList IList;

    }
}
