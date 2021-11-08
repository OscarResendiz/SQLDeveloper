namespace Inteliences
{
    partial class CInteliences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CInteliences));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cAnaliseManager1 = new CAnaliseManager(this.components);
            this.cBufferProvider1 = new CBufferProvider(this.components);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Vista.ico");
            this.imageList1.Images.SetKeyName(1, "vista.png");
            this.imageList1.Images.SetKeyName(2, "funcion.png");
            this.imageList1.Images.SetKeyName(3, "SP.ICO");
            this.imageList1.Images.SetKeyName(4, "trriger.jpg");
            this.imageList1.Images.SetKeyName(5, "check.png");
            this.imageList1.Images.SetKeyName(6, "default.png");
            this.imageList1.Images.SetKeyName(7, "FK.ico");
            this.imageList1.Images.SetKeyName(8, "llaves.jpg");
            this.imageList1.Images.SetKeyName(9, "Trasar2.jpg");
            this.imageList1.Images.SetKeyName(10, "desconocido.jpg");

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private CAnaliseManager cAnaliseManager1;
        private CBufferProvider cBufferProvider1;
    }
}
