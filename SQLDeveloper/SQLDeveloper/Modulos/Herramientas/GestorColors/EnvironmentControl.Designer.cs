namespace SQLDeveloper.Modulos.Herramientas.GestorColors
{
    partial class EnvironmentControl
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
            this.Default = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.Selection = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.LineNumbers = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.InvalidLines = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.TabMarkers = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.EOLMarkers = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.CaretMarker = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.SpaceMarkers = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.FoldLine = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.FoldMarker = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.FoldMarkerBg = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.FoldLineBg = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.LineNumbersBg = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.VRuler = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.DefaultBg = new SQLDeveloper.Modulos.Herramientas.GestorColors.CComponetColor();
            this.SuspendLayout();
            // 
            // Default
            // 
            this.Default.Color = System.Drawing.SystemColors.Control;
            this.Default.Location = new System.Drawing.Point(12, 12);
            this.Default.Name = "Default";
            this.Default.Nombre = "Color por default";
            this.Default.Size = new System.Drawing.Size(184, 42);
            this.Default.TabIndex = 0;
            this.Default.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.Default_OnColorCahnge);
            // 
            // Selection
            // 
            this.Selection.Color = System.Drawing.SystemColors.Control;
            this.Selection.Location = new System.Drawing.Point(12, 101);
            this.Selection.Name = "Selection";
            this.Selection.Nombre = "Selection";
            this.Selection.Size = new System.Drawing.Size(184, 49);
            this.Selection.TabIndex = 1;
            this.Selection.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.Selection_OnColorCahnge);
            // 
            // LineNumbers
            // 
            this.LineNumbers.Color = System.Drawing.SystemColors.Control;
            this.LineNumbers.Location = new System.Drawing.Point(12, 60);
            this.LineNumbers.Name = "LineNumbers";
            this.LineNumbers.Nombre = "Número de línea";
            this.LineNumbers.Size = new System.Drawing.Size(184, 43);
            this.LineNumbers.TabIndex = 2;
            this.LineNumbers.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.LineNumbers_OnColorCahnge);
            // 
            // InvalidLines
            // 
            this.InvalidLines.Color = System.Drawing.SystemColors.Control;
            this.InvalidLines.Location = new System.Drawing.Point(12, 331);
            this.InvalidLines.Name = "InvalidLines";
            this.InvalidLines.Nombre = "Línea invalida";
            this.InvalidLines.Size = new System.Drawing.Size(184, 46);
            this.InvalidLines.TabIndex = 3;
            this.InvalidLines.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.InvalidLines_OnColorCahnge);
            // 
            // TabMarkers
            // 
            this.TabMarkers.Color = System.Drawing.SystemColors.Control;
            this.TabMarkers.Location = new System.Drawing.Point(12, 192);
            this.TabMarkers.Name = "TabMarkers";
            this.TabMarkers.Nombre = "TabMarkers";
            this.TabMarkers.Size = new System.Drawing.Size(184, 44);
            this.TabMarkers.TabIndex = 4;
            this.TabMarkers.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.TabMarkers_OnColorCahnge);
            // 
            // EOLMarkers
            // 
            this.EOLMarkers.Color = System.Drawing.SystemColors.Control;
            this.EOLMarkers.Location = new System.Drawing.Point(12, 145);
            this.EOLMarkers.Name = "EOLMarkers";
            this.EOLMarkers.Nombre = "EOLMarkers";
            this.EOLMarkers.Size = new System.Drawing.Size(184, 41);
            this.EOLMarkers.TabIndex = 5;
            this.EOLMarkers.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.EOLMarkers_OnColorCahnge);
            // 
            // CaretMarker
            // 
            this.CaretMarker.Color = System.Drawing.SystemColors.Control;
            this.CaretMarker.Location = new System.Drawing.Point(221, 195);
            this.CaretMarker.Name = "CaretMarker";
            this.CaretMarker.Nombre = "CaretMarker";
            this.CaretMarker.Size = new System.Drawing.Size(273, 41);
            this.CaretMarker.TabIndex = 6;
            this.CaretMarker.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.CaretMarker_OnColorCahnge);
            // 
            // SpaceMarkers
            // 
            this.SpaceMarkers.Color = System.Drawing.SystemColors.Control;
            this.SpaceMarkers.Location = new System.Drawing.Point(221, 145);
            this.SpaceMarkers.Name = "SpaceMarkers";
            this.SpaceMarkers.Nombre = "SpaceMarkers";
            this.SpaceMarkers.Size = new System.Drawing.Size(273, 44);
            this.SpaceMarkers.TabIndex = 7;
            this.SpaceMarkers.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.SpaceMarkers_OnColorCahnge);
            // 
            // FoldLine
            // 
            this.FoldLine.Color = System.Drawing.SystemColors.Control;
            this.FoldLine.Location = new System.Drawing.Point(12, 242);
            this.FoldLine.Name = "FoldLine";
            this.FoldLine.Nombre = "FoldLine";
            this.FoldLine.Size = new System.Drawing.Size(184, 41);
            this.FoldLine.TabIndex = 8;
            this.FoldLine.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.FoldLine_OnColorCahnge);
            // 
            // FoldMarker
            // 
            this.FoldMarker.Color = System.Drawing.SystemColors.Control;
            this.FoldMarker.Location = new System.Drawing.Point(12, 289);
            this.FoldMarker.Name = "FoldMarker";
            this.FoldMarker.Nombre = "FoldMarker";
            this.FoldMarker.Size = new System.Drawing.Size(184, 42);
            this.FoldMarker.TabIndex = 9;
            this.FoldMarker.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.FoldMarker_OnColorCahnge);
            // 
            // FoldMarkerBg
            // 
            this.FoldMarkerBg.Color = System.Drawing.SystemColors.Control;
            this.FoldMarkerBg.Location = new System.Drawing.Point(221, 289);
            this.FoldMarkerBg.Name = "FoldMarkerBg";
            this.FoldMarkerBg.Nombre = "Back FoldMarker";
            this.FoldMarkerBg.Size = new System.Drawing.Size(273, 46);
            this.FoldMarkerBg.TabIndex = 10;
            this.FoldMarkerBg.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.FoldMarkerBg_OnColorCahnge);
            // 
            // FoldLineBg
            // 
            this.FoldLineBg.Color = System.Drawing.SystemColors.Control;
            this.FoldLineBg.Location = new System.Drawing.Point(221, 241);
            this.FoldLineBg.Name = "FoldLineBg";
            this.FoldLineBg.Nombre = "Back FoldLine ";
            this.FoldLineBg.Size = new System.Drawing.Size(273, 42);
            this.FoldLineBg.TabIndex = 11;
            this.FoldLineBg.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.FoldLineBg_OnColorCahnge);
            // 
            // LineNumbersBg
            // 
            this.LineNumbersBg.Color = System.Drawing.SystemColors.Control;
            this.LineNumbersBg.Location = new System.Drawing.Point(221, 60);
            this.LineNumbersBg.Name = "LineNumbersBg";
            this.LineNumbersBg.Nombre = "Color de fondo de número de línea";
            this.LineNumbersBg.Size = new System.Drawing.Size(273, 38);
            this.LineNumbersBg.TabIndex = 12;
            this.LineNumbersBg.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.LineNumbersBg_OnColorCahnge);
            // 
            // VRuler
            // 
            this.VRuler.Color = System.Drawing.SystemColors.Control;
            this.VRuler.Location = new System.Drawing.Point(221, 104);
            this.VRuler.Name = "VRuler";
            this.VRuler.Nombre = "Regla";
            this.VRuler.Size = new System.Drawing.Size(273, 41);
            this.VRuler.TabIndex = 13;
            this.VRuler.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.VRuler_OnColorCahnge);
            // 
            // DefaultBg
            // 
            this.DefaultBg.Color = System.Drawing.SystemColors.Control;
            this.DefaultBg.Location = new System.Drawing.Point(221, 12);
            this.DefaultBg.Name = "DefaultBg";
            this.DefaultBg.Nombre = "Color de fondo por default";
            this.DefaultBg.Size = new System.Drawing.Size(273, 42);
            this.DefaultBg.TabIndex = 14;
            this.DefaultBg.OnColorCahnge += new SQLDeveloper.Modulos.Herramientas.GestorColors.OnColorCahngeEvent(this.DefaultBg_OnColorCahnge);
            // 
            // EnvironmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DefaultBg);
            this.Controls.Add(this.VRuler);
            this.Controls.Add(this.LineNumbersBg);
            this.Controls.Add(this.FoldLineBg);
            this.Controls.Add(this.FoldMarkerBg);
            this.Controls.Add(this.FoldMarker);
            this.Controls.Add(this.FoldLine);
            this.Controls.Add(this.SpaceMarkers);
            this.Controls.Add(this.CaretMarker);
            this.Controls.Add(this.EOLMarkers);
            this.Controls.Add(this.TabMarkers);
            this.Controls.Add(this.InvalidLines);
            this.Controls.Add(this.LineNumbers);
            this.Controls.Add(this.Selection);
            this.Controls.Add(this.Default);
            this.Name = "EnvironmentControl";
            this.Size = new System.Drawing.Size(497, 386);
            this.ResumeLayout(false);

        }

        #endregion

        private CComponetColor Default;
        private CComponetColor Selection;
        private CComponetColor LineNumbers;
        private CComponetColor InvalidLines;
        private CComponetColor TabMarkers;
        private CComponetColor EOLMarkers;
        private CComponetColor CaretMarker;
        private CComponetColor SpaceMarkers;
        private CComponetColor FoldLine;
        private CComponetColor FoldMarker;
        private CComponetColor FoldMarkerBg;
        private CComponetColor FoldLineBg;
        private CComponetColor LineNumbersBg;
        private CComponetColor VRuler;
        private CComponetColor DefaultBg;

    }
}
