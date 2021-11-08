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
    public partial class EnvironmentControl : CControlBase
    {
        private CEnvironment Environment;
        public EnvironmentControl()
        {
            InitializeComponent();
        }
        public override void Recarga()
        {
            if (Objeto == null)
                return;
            Environment = (CEnvironment)Objeto;

            Default.Color = Environment.DefaultColor.Color;
            Selection.Color = Environment.SelectionBgcolor.Color;
            LineNumbers.Color = Environment.LineNumbersColor.Color;
            InvalidLines.Color = Environment.InvalidLinesColor.Color;
            TabMarkers.Color = Environment.TabMarkersColor.Color;
            EOLMarkers.Color = Environment.EOLMarkersColor.Color;
            CaretMarker.Color = Environment.CaretMarkerColor.Color;
            SpaceMarkers.Color = Environment.SpaceMarkersColor.Color;
            FoldLine.Color = Environment.FoldLineColor.Color;
            FoldMarker.Color = Environment.FoldMarkerColor.Color;
            FoldMarkerBg.Color = Environment.FoldMarkerBgcolor.Color;
            FoldLineBg.Color = Environment.FoldLineBgcolor.Color;
            LineNumbersBg.Color = Environment.LineNumbersBgcolor.Color;
            VRuler.Color = Environment.VRulerColor.Color;
            DefaultBg.Color = Environment.DefaultBgcolor.Color;
        }

        private void Default_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.DefaultColor.Color=color;
        }

        private void LineNumbers_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.LineNumbersColor.Color = color;
        }

        private void Selection_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.SelectionBgcolor.Color = color;
        }

        private void EOLMarkers_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.EOLMarkersColor.Color = color;
        }

        private void TabMarkers_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.TabMarkersColor.Color = color;
        }

        private void FoldLine_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.FoldLineColor.Color = color;
        }

        private void FoldMarker_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.FoldMarkerColor.Color = color;
        }

        private void InvalidLines_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.InvalidLinesColor.Color = color;
        }

        private void DefaultBg_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.DefaultBgcolor.Color = color;
        }

        private void LineNumbersBg_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.LineNumbersBgcolor.Color = color;
        }

        private void VRuler_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.VRulerColor.Color = color;
        }

        private void SpaceMarkers_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.SpaceMarkersColor.Color = color;
        }

        private void CaretMarker_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.CaretMarkerColor.Color = color;
        }

        private void FoldLineBg_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.FoldLineBgcolor.Color = color;
        }

        private void FoldMarkerBg_OnColorCahnge(CComponetColor sender, Color color)
        {
            Environment.FoldMarkerBgcolor.Color = color;
        }
    }
}
