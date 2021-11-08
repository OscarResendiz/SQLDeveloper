using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Modelador.Dibujable
{
    public class DCampo : DTexto
    {
        private Modelador.Modelo.CCampo FCampo;
        private System.Drawing.SolidBrush PinBrus;
        public int ID_Campo
        {
            get;
            set;
        }
        protected override void ModeloAsignado()
        {
            base.ModeloAsignado();
            FCampo = Modelo.Get_Campo(ID_Campo);
            Texto = FCampo.NombreX;
            //            Modelador.Modelo.CTabla tabla=Modelo.Get_Tabla(FCampo.ID_Tabla);
            //            ColorFondo = new SolidBrush(tabla.BKColor);// System.Drawing.Color.Black);
            ColorFondo = new SolidBrush(System.Drawing.Color.Black);// );
            if (FCampo.PK)
                ColorTexto = new SolidBrush(Color.GreenYellow);
            else
                ColorTexto = new SolidBrush(Color.White);
            Modelo.OnCampoUpdate += new Modelo.DelegateModeloDatosEvent(CampoUpdate);
        }
        public override void Free()
        {
            base.Free();
            Modelo.OnCampoUpdate -= CampoUpdate;
        }
        public DCampo()
        {
            this.Contorno = false;
        }
        private void CampoUpdate(Modelo.ModeloDatos modelo, int id_campo)
        {
            if (ID_Campo == id_campo)
            {
                FCampo = Modelo.Get_Campo(id_campo);
                Texto = FCampo.NombreX;
                Modelador.Modelo.CTabla tabla = Modelo.Get_Tabla(FCampo.ID_Tabla);
                //ColorFondo = new SolidBrush(tabla.BKColor);
                Redibuja();
            }
        }
        public override void Dibuja(MiGraphics graphics)
        {
            base.Dibuja(graphics);
            //ahora dibujo unas patitas tipo circuito integrado
            if (PinBrus == null)
                PinBrus = new System.Drawing.SolidBrush(System.Drawing.Color.LightGray);

            graphics.FillRectangle(PinBrus, Posicion.X - 5, Posicion.Y + Dimencion.Height / 4, 5, Dimencion.Height / 4);
            graphics.FillRectangle(PinBrus, Posicion.X + Dimencion.Width, Posicion.Y + Dimencion.Height / 4, 5, Dimencion.Height / 4);
        }
        protected override void InicializaMenu(int x, int y)
        {
            AddMenuItem("Copiar nombre al portapapeles", "copiar", this.MenuCoiarNombre_Click);
            AddMenuItem("Editar Campo", "IconoEditar", MenuEditar_Click);
            AddMenuSeparator();
            AddMenuItem("Eliminar Campo", "Eliminar", MenuEliminar_Click);
        }
        protected virtual void MenuCoiarNombre_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Texto);
        }

        private Modelo.CCampo GetCampo()
        {
            return Modelo.Get_Campo(ID_Campo);
        }
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Modelo.CCampo campo = GetCampo();
                UI.FormPropiedadesCampo dlg = new UI.FormPropiedadesCampo(Modelo);
                dlg.NombreX = campo.NombreX;
                dlg.Comentarios = campo.Comentarios;
                dlg.ID_TipoDato = campo.ID_TipoDato;
                dlg.Longitud = campo.Longitud;
                dlg.PK = campo.PK;
                dlg.AceptaNulos = campo.AceptaNulos;
                dlg.CampoCalculado = campo.Calculado;
                dlg.Formula = campo.Formula;
                dlg.EsDefault = campo.EsDefault;
                dlg.DefaultName = campo.DefaultName;
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                campo.NombreX = dlg.NombreX;
                campo.Comentarios = dlg.Comentarios;
                campo.ID_TipoDato = dlg.ID_TipoDato;
                campo.Longitud = dlg.Longitud;
                campo.PK = dlg.PK;
                campo.AceptaNulos = dlg.AceptaNulos;
                campo.Calculado = dlg.CampoCalculado;
                campo.Formula = dlg.Formula;
                campo.EsDefault = dlg.EsDefault;
                campo.DefaultName = dlg.DefaultName;
                campo.Update();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Eliminar el campo " + Texto, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                GetCampo().Delete();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

