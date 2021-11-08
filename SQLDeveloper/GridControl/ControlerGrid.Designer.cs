namespace GridControl
{
    partial class ControlerGrid
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlerGrid));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BNuevo = new System.Windows.Forms.ToolStripButton();
            this.BCerrar = new System.Windows.Forms.ToolStripButton();
            this.Contenedor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pageResult1 = new GridControl.PageResult();
            this.DSFiltro = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            this.Contenedor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSFiltro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BNuevo,
            this.BCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(432, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BNuevo
            // 
            this.BNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BNuevo.Enabled = false;
            this.BNuevo.Image = ((System.Drawing.Image)(resources.GetObject("BNuevo.Image")));
            this.BNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BNuevo.Name = "BNuevo";
            this.BNuevo.Size = new System.Drawing.Size(23, 22);
            this.BNuevo.Text = "Nueva pestaña";
            this.BNuevo.Click += new System.EventHandler(this.BNuevo_Click);
            // 
            // BCerrar
            // 
            this.BCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(23, 22);
            this.BCerrar.Text = "Cerrar pestaña actual";
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // Contenedor
            // 
            this.Contenedor.Controls.Add(this.tabPage1);
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 25);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.SelectedIndex = 0;
            this.Contenedor.Size = new System.Drawing.Size(432, 212);
            this.Contenedor.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gray;
            this.tabPage1.Controls.Add(this.pageResult1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(424, 186);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Resultado 1";
            // 
            // pageResult1
            // 
            this.pageResult1.AutoScroll = true;
            this.pageResult1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pageResult1.DataSet = null;
            this.pageResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageResult1.Location = new System.Drawing.Point(3, 3);
            this.pageResult1.Name = "pageResult1";
            this.pageResult1.Size = new System.Drawing.Size(418, 180);
            this.pageResult1.TabIndex = 0;
            this.pageResult1.OnMessage += new GridControl.OnMessageEvent(this.MensajeEvent);
            // 
            // DSFiltro
            // 
            this.DSFiltro.DataSetName = "NewDataSet";
            this.DSFiltro.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.dataTable1.TableName = "Filtros";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Campo";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Condicion";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Valor";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Tabla";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivo de excel|*.xls|Archivo separado por comas|*.csv|Archivo XML|*.xml";
            // 
            // ControlerGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControlerGrid";
            this.Size = new System.Drawing.Size(432, 237);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Contenedor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DSFiltro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BNuevo;
        private System.Windows.Forms.TabControl Contenedor;
        private System.Windows.Forms.TabPage tabPage1;
        private PageResult pageResult1;
        private System.Data.DataSet DSFiltro;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton BCerrar;
    }
}
