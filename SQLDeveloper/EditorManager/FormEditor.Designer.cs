﻿namespace EditorManager
{
    partial class FormEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditor));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodasLasPestañasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerCerrar = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem,
            this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem,
            this.cerrarTodasLasPestañasToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(274, 70);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarToolStripMenuItem.Image")));
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar pestaña";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // cerrarTodasLasPestañasExceptoEstaToolStripMenuItem
            // 
            this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarTodasLasPestañasExceptoEstaToolStripMenuItem.Image")));
            this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem.Name = "cerrarTodasLasPestañasExceptoEstaToolStripMenuItem";
            this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem.Text = "Cerrar todas las pestañas excepto esta";
            this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodasLasPestañasExceptoEstaToolStripMenuItem_Click);
            // 
            // cerrarTodasLasPestañasToolStripMenuItem
            // 
            this.cerrarTodasLasPestañasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarTodasLasPestañasToolStripMenuItem.Image")));
            this.cerrarTodasLasPestañasToolStripMenuItem.Name = "cerrarTodasLasPestañasToolStripMenuItem";
            this.cerrarTodasLasPestañasToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.cerrarTodasLasPestañasToolStripMenuItem.Text = "Cerrar todas las pestañas";
            this.cerrarTodasLasPestañasToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodasLasPestañasToolStripMenuItem_Click);
            // 
            // TimerCerrar
            // 
            this.TimerCerrar.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(793, 554);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged_1);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown_1);
            this.tabControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseMove_1);
            this.tabControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseUp_1);
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(793, 554);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de codigo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditor_FormClosing);
            this.Load += new System.EventHandler(this.FormEditor_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.Timer TimerCerrar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodasLasPestañasExceptoEstaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodasLasPestañasToolStripMenuItem;
    }
}