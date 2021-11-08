namespace SQLDeveloper
{
    partial class FormConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.Button();
            this.CHConexionInicio = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CHCaseSensibility = new System.Windows.Forms.CheckBox();
            this.TSensivilidad = new System.Windows.Forms.NumericUpDown();
            this.ColorLetraNuevaLinea = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.ColorLetraDiferenciaDetalle = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.ColoLetraLineaDiferente = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.BarraSensibilidad = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboAlgoritmo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorPalbraDiferente = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.ColorLineaVirtual = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.ColorNuevaLinea = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.ColorDiferenciaLinea = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.configuradorApp1 = new ManagerConnect.ConfiguradorApp(this.components);
            this.ChCerrar = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TSensivilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraSensibilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 52);
            this.panel1.TabIndex = 0;
            // 
            // BCerrar
            // 
            this.BCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrar.Location = new System.Drawing.Point(382, 3);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(82, 44);
            this.BCerrar.TabIndex = 1;
            this.BCerrar.Text = "Cerrar";
            this.BCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrar.UseVisualStyleBackColor = true;
            // 
            // CHConexionInicio
            // 
            this.CHConexionInicio.AutoSize = true;
            this.CHConexionInicio.Location = new System.Drawing.Point(12, 22);
            this.CHConexionInicio.Name = "CHConexionInicio";
            this.CHConexionInicio.Size = new System.Drawing.Size(188, 17);
            this.CHConexionInicio.TabIndex = 1;
            this.CHConexionInicio.Text = "Mostrar Cuadro de conexion inicial";
            this.CHConexionInicio.UseVisualStyleBackColor = true;
            this.CHConexionInicio.CheckedChanged += new System.EventHandler(this.CHConexionInicio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CHCaseSensibility);
            this.groupBox1.Controls.Add(this.TSensivilidad);
            this.groupBox1.Controls.Add(this.ColorLetraNuevaLinea);
            this.groupBox1.Controls.Add(this.ColorLetraDiferenciaDetalle);
            this.groupBox1.Controls.Add(this.ColoLetraLineaDiferente);
            this.groupBox1.Controls.Add(this.BarraSensibilidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ComboAlgoritmo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ColorPalbraDiferente);
            this.groupBox1.Controls.Add(this.ColorLineaVirtual);
            this.groupBox1.Controls.Add(this.ColorNuevaLinea);
            this.groupBox1.Controls.Add(this.ColorDiferenciaLinea);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 295);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comparador";
            // 
            // CHCaseSensibility
            // 
            this.CHCaseSensibility.AutoSize = true;
            this.CHCaseSensibility.Location = new System.Drawing.Point(9, 272);
            this.CHCaseSensibility.Name = "CHCaseSensibility";
            this.CHCaseSensibility.Size = new System.Drawing.Size(225, 17);
            this.CHCaseSensibility.TabIndex = 14;
            this.CHCaseSensibility.Text = "Diferenciar entre mayusculas y minusculas";
            this.CHCaseSensibility.UseVisualStyleBackColor = true;
            this.CHCaseSensibility.CheckedChanged += new System.EventHandler(this.CHCaseSensibility_CheckedChanged);
            // 
            // TSensivilidad
            // 
            this.TSensivilidad.Location = new System.Drawing.Point(381, 237);
            this.TSensivilidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TSensivilidad.Name = "TSensivilidad";
            this.TSensivilidad.Size = new System.Drawing.Size(49, 20);
            this.TSensivilidad.TabIndex = 11;
            this.TSensivilidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TSensivilidad.ValueChanged += new System.EventHandler(this.TSensivilidad_ValueChanged);
            // 
            // ColorLetraNuevaLinea
            // 
            this.ColorLetraNuevaLinea.Color = System.Drawing.SystemColors.Control;
            this.ColorLetraNuevaLinea.Location = new System.Drawing.Point(265, 109);
            this.ColorLetraNuevaLinea.Name = "ColorLetraNuevaLinea";
            this.ColorLetraNuevaLinea.Nombre = "Color de letra";
            this.ColorLetraNuevaLinea.Size = new System.Drawing.Size(176, 39);
            this.ColorLetraNuevaLinea.TabIndex = 10;
            this.ColorLetraNuevaLinea.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorLetraNuevaLinea_OnColorCahnge);
            // 
            // ColorLetraDiferenciaDetalle
            // 
            this.ColorLetraDiferenciaDetalle.Color = System.Drawing.SystemColors.Control;
            this.ColorLetraDiferenciaDetalle.Location = new System.Drawing.Point(263, 64);
            this.ColorLetraDiferenciaDetalle.Name = "ColorLetraDiferenciaDetalle";
            this.ColorLetraDiferenciaDetalle.Nombre = "Color de letra";
            this.ColorLetraDiferenciaDetalle.Size = new System.Drawing.Size(176, 39);
            this.ColorLetraDiferenciaDetalle.TabIndex = 9;
            this.ColorLetraDiferenciaDetalle.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorLetraDiferenciaDetalle_OnColorCahnge);
            // 
            // ColoLetraLineaDiferente
            // 
            this.ColoLetraLineaDiferente.Color = System.Drawing.SystemColors.Control;
            this.ColoLetraLineaDiferente.Location = new System.Drawing.Point(265, 19);
            this.ColoLetraLineaDiferente.Name = "ColoLetraLineaDiferente";
            this.ColoLetraLineaDiferente.Nombre = "Color de letra";
            this.ColoLetraLineaDiferente.Size = new System.Drawing.Size(176, 39);
            this.ColoLetraLineaDiferente.TabIndex = 8;
            this.ColoLetraLineaDiferente.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColoLetraLineaDiferente_OnColorCahnge);
            // 
            // BarraSensibilidad
            // 
            this.BarraSensibilidad.Location = new System.Drawing.Point(75, 236);
            this.BarraSensibilidad.Maximum = 100;
            this.BarraSensibilidad.Minimum = 1;
            this.BarraSensibilidad.Name = "BarraSensibilidad";
            this.BarraSensibilidad.Size = new System.Drawing.Size(300, 45);
            this.BarraSensibilidad.TabIndex = 7;
            this.BarraSensibilidad.Value = 15;
            this.BarraSensibilidad.Scroll += new System.EventHandler(this.BarraSensibilidad_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sensibilidad";
            // 
            // ComboAlgoritmo
            // 
            this.ComboAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboAlgoritmo.FormattingEnabled = true;
            this.ComboAlgoritmo.Items.AddRange(new object[] {
            "Palabra por palabra",
            "Letra por letra"});
            this.ComboAlgoritmo.Location = new System.Drawing.Point(144, 204);
            this.ComboAlgoritmo.Name = "ComboAlgoritmo";
            this.ComboAlgoritmo.Size = new System.Drawing.Size(286, 21);
            this.ComboAlgoritmo.TabIndex = 5;
            this.ComboAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.ComboAlgoritmo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Algoritmo de comparación ";
            // 
            // ColorPalbraDiferente
            // 
            this.ColorPalbraDiferente.Color = System.Drawing.SystemColors.Control;
            this.ColorPalbraDiferente.Location = new System.Drawing.Point(5, 64);
            this.ColorPalbraDiferente.Name = "ColorPalbraDiferente";
            this.ColorPalbraDiferente.Nombre = "Color de detalle de diferencia";
            this.ColorPalbraDiferente.Size = new System.Drawing.Size(252, 39);
            this.ColorPalbraDiferente.TabIndex = 3;
            this.ColorPalbraDiferente.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorPalbraDiferente_OnColorCahnge);
            // 
            // ColorLineaVirtual
            // 
            this.ColorLineaVirtual.Color = System.Drawing.SystemColors.Control;
            this.ColorLineaVirtual.Location = new System.Drawing.Point(6, 154);
            this.ColorLineaVirtual.Name = "ColorLineaVirtual";
            this.ColorLineaVirtual.Nombre = "Color de lineas de sincronia";
            this.ColorLineaVirtual.Size = new System.Drawing.Size(251, 39);
            this.ColorLineaVirtual.TabIndex = 2;
            this.ColorLineaVirtual.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorLineaVirtual_OnColorCahnge);
            this.ColorLineaVirtual.Load += new System.EventHandler(this.ColorLineaVVirtual_Load);
            // 
            // ColorNuevaLinea
            // 
            this.ColorNuevaLinea.Color = System.Drawing.SystemColors.Control;
            this.ColorNuevaLinea.Location = new System.Drawing.Point(5, 109);
            this.ColorNuevaLinea.Name = "ColorNuevaLinea";
            this.ColorNuevaLinea.Nombre = "Color de nuevas lineas";
            this.ColorNuevaLinea.Size = new System.Drawing.Size(252, 39);
            this.ColorNuevaLinea.TabIndex = 1;
            this.ColorNuevaLinea.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorNuevaLinea_OnColorCahnge);
            // 
            // ColorDiferenciaLinea
            // 
            this.ColorDiferenciaLinea.Color = System.Drawing.SystemColors.Control;
            this.ColorDiferenciaLinea.Location = new System.Drawing.Point(6, 19);
            this.ColorDiferenciaLinea.Name = "ColorDiferenciaLinea";
            this.ColorDiferenciaLinea.Nombre = "Color de lineas con diferencias";
            this.ColorDiferenciaLinea.Size = new System.Drawing.Size(251, 39);
            this.ColorDiferenciaLinea.TabIndex = 0;
            this.ColorDiferenciaLinea.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.ColorDiferenciaLinea_OnColorCahnge);
            // 
            // ChCerrar
            // 
            this.ChCerrar.AutoSize = true;
            this.ChCerrar.Location = new System.Drawing.Point(218, 22);
            this.ChCerrar.Name = "ChCerrar";
            this.ChCerrar.Size = new System.Drawing.Size(216, 17);
            this.ChCerrar.TabIndex = 3;
            this.ChCerrar.Text = "Pedir confirmación al cerrar la aplicación";
            this.ChCerrar.UseVisualStyleBackColor = true;
            this.ChCerrar.CheckedChanged += new System.EventHandler(this.ChCerrar_CheckedChanged);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCerrar;
            this.ClientSize = new System.Drawing.Size(476, 404);
            this.Controls.Add(this.ChCerrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CHConexionInicio);
            this.Controls.Add(this.panel1);
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion General";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TSensivilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraSensibilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BCerrar;
        private System.Windows.Forms.CheckBox CHConexionInicio;
        private ManagerConnect.ConfiguradorApp configuradorApp1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Modulos.Herramientas.GestorColors.CComponetColor ColorPalbraDiferente;
        private Modulos.Herramientas.GestorColors.CComponetColor ColorLineaVirtual;
        private Modulos.Herramientas.GestorColors.CComponetColor ColorNuevaLinea;
        private Modulos.Herramientas.GestorColors.CComponetColor ColorDiferenciaLinea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboAlgoritmo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar BarraSensibilidad;
        private Modulos.Herramientas.GestorColors.CComponetColor ColorLetraNuevaLinea;
        private Modulos.Herramientas.GestorColors.CComponetColor ColorLetraDiferenciaDetalle;
        private Modulos.Herramientas.GestorColors.CComponetColor ColoLetraLineaDiferente;
        private System.Windows.Forms.NumericUpDown TSensivilidad;
        private System.Windows.Forms.CheckBox CHCaseSensibility;
        private System.Windows.Forms.CheckBox ChCerrar;
    }
}