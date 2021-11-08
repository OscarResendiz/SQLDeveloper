using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SintaxColor;

namespace SQLDeveloper
{
    public partial class FormConfig : Form
    {
        Modulos.Comparador.CCOnfigComparator comparador = new Modulos.Comparador.CCOnfigComparator();
        public FormConfig()
        {
            InitializeComponent();
        }

        private void CHConexionInicio_CheckedChanged(object sender, EventArgs e)
        {
            configuradorApp1.SetBooleanParameter("MostrarDialogConexionInicial", CHConexionInicio.Checked);
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            CHConexionInicio.Checked = configuradorApp1.GetBooleanParameter("MostrarDialogConexionInicial");

            ColorDiferenciaLinea.Color = comparador.ColorDiferenciaLinea;
            ColoLetraLineaDiferente.Color = comparador.ColoLetraLineaDiferente;
            ColorPalbraDiferente.Color = comparador.ColorPalbraDiferente;
            ColorLetraDiferenciaDetalle.Color = comparador.ColorLetraDiferenciaDetalle;
            ColorNuevaLinea.Color = comparador.ColorNuevaLinea;
            ColorLetraNuevaLinea.Color = comparador.ColorLetraNuevaLinea;
            ColorLineaVirtual.Color = comparador.ColorLineaVirtual;

            ComboAlgoritmo.SelectedItem = comparador.AlgoritmoComparador;
            BarraSensibilidad.Value = comparador.SensibilidadComparador;
            TSensivilidad.Value = comparador.SensibilidadComparador;
            CHCaseSensibility.Checked = comparador.CaseSencibility;
            ChCerrar.Checked=configuradorApp1.GetBooleanParameter("MostrarDialogoCerrar");
        }

        private void ColorLineaVVirtual_Load(object sender, EventArgs e)
        {

        }

        private void ColorDiferenciaLinea_OnColorCahnge(Modulos.Herramientas.GestorColors.CComponetColor sender, Color color)
        {
            comparador.ColorDiferenciaLinea = color;            
        }

        private void ColoLetraLineaDiferente_OnColorCahnge(Modulos.Herramientas.GestorColors.CComponetColor sender, Color color)
        {
            comparador.ColoLetraLineaDiferente = color;

        }

        private void ColorPalbraDiferente_OnColorCahnge(Modulos.Herramientas.GestorColors.CComponetColor sender, Color color)
        {
            comparador.ColorPalbraDiferente = color;

        }

        private void ColorLetraDiferenciaDetalle_OnColorCahnge(Modulos.Herramientas.GestorColors.CComponetColor sender, Color color)
        {
            comparador.ColorLetraDiferenciaDetalle = color;

        }

        private void ColorNuevaLinea_OnColorCahnge(Modulos.Herramientas.GestorColors.CComponetColor sender, Color color)
        {
            comparador.ColorNuevaLinea = color;

        }

        private void ColorLetraNuevaLinea_OnColorCahnge(Modulos.Herramientas.GestorColors.CComponetColor sender, Color color)
        {
            comparador.ColorLetraNuevaLinea = color;

        }

        private void ColorLineaVirtual_OnColorCahnge(Modulos.Herramientas.GestorColors.CComponetColor sender, Color color)
        {
            comparador.ColorLineaVirtual = color;
        }

        private void ComboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboAlgoritmo.SelectedIndex != -1)
            {
                comparador.AlgoritmoComparador = ComboAlgoritmo.SelectedItem.ToString();
            }
        }

        private void BarraSensibilidad_Scroll(object sender, EventArgs e)
        {
            comparador.SensibilidadComparador = BarraSensibilidad.Value;
            if (TSensivilidad.Value != comparador.SensibilidadComparador)
                TSensivilidad.Value = comparador.SensibilidadComparador;
        }

        private void TSensivilidad_ValueChanged(object sender, EventArgs e)
        {
            comparador.SensibilidadComparador =(int)TSensivilidad.Value  ;
            if (BarraSensibilidad.Value != comparador.SensibilidadComparador)
                BarraSensibilidad.Value = comparador.SensibilidadComparador;

        }

        private void CHCaseSensibility_CheckedChanged(object sender, EventArgs e)
        {
            comparador.CaseSencibility = CHCaseSensibility.Checked;

        }

        private void ChCerrar_CheckedChanged(object sender, EventArgs e)
        {
            configuradorApp1.SetBooleanParameter("MostrarDialogoCerrar", ChCerrar.Checked);
        }
    }
}
