using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MotorDB;
namespace SPGenerator
{
    public partial class AsisNombreSP : AsistBaseSP
    {
        private IMotorDB DB;
        public AsisNombreSP(IMotorDB db)
        {
            DB = db;
            InitializeComponent();
        }
        private string Capitalize(string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }
        public override void Inicializate()
        {
            base.Inicializate();
            string tabla = Capitalize(DatosAsistente.Tabla.Nombre);
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.SELECT) 
            {
                TNombre.Text = "Sp_Select_" + tabla;
            }
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.INSERT)
            {
                TNombre.Text = "Sp_Insert_" + tabla;
            }
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.UPDATE)
            {
                TNombre.Text = "Sp_Update_" + tabla;
            }
            if (DatosAsistente.TipoSP == Objetos.TIPO_SP.DELETE)
            {
                TNombre.Text = "Sp_Delete_" + tabla;
            }
            if (TComentario.Text.Trim() == "")
            {
                TComentario.Text = DameCometarios();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Visible == false)
                return;
            bool ok = true;
            if (TNombre.Text.Trim() == "")
                ok = false;
            EnableAnterior(true);
            EnableSiguiente(ok);
        }
        public override void BSiguiente()
        {
            DatosAsistente.NombreSp = TNombre.Text;
            DatosAsistente.ComentarioNombreSP = TComentario.Text;
            if (Siguiente == null)
            {
                Siguiente = new AsisSelParametros(DB);
                Siguiente.Anterior = this;
            }
            OnInstalame(Siguiente);
        }

        private void agregarFechaDeCreaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TComentario.Text = DameCometarios();
        }

        private void Chk_Mayusculas_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Mayusculas.Checked == true)
            {
                //cambia a mayusculas
                TNombre.CharacterCasing = CharacterCasing.Upper;
            }
            else
                TNombre.CharacterCasing = CharacterCasing.Normal;
        }
        private string RellenaTexto(string texto, char llenador, int longitud )
        {
            string s = "";
            if(texto.Length> longitud)
                return texto.Substring(longitud);
            s = texto;
            for(int i=texto.Length; i<longitud; i++)
            {
                s = s + llenador;
            }
            return s;
        }
        private string DameCometarios()
        {
            string cabecera = "*************************************************************************************";
            string s = "/"+cabecera+"\r\n";
            s = s + RellenaTexto("*",' ', cabecera.Length) + "*\r\n";
            s = s + RellenaTexto($"* Procedimiento alcenado {TNombre.Text}",' ',cabecera.Length)+"*\r\n";
            s = s + RellenaTexto($"* Fecha de creacion: {System.DateTime.Now.Date.ToString("dd/MM/yyyy")}", ' ', cabecera.Length) + "*\r\n";
            s = s + RellenaTexto($"* Creado por: Oscar Resendiz", ' ', cabecera.Length) + "*\r\n";
            s = s + RellenaTexto($"* Proposito:", ' ', cabecera.Length) + "*\r\n";
            s = s + RellenaTexto($"*", ' ', cabecera.Length) + "*\r\n";
            s = s+ cabecera + "*/\r\n";
            return s;
        }
        private void TNombre_TextChanged(object sender, EventArgs e)
        {
            TComentario.Text = DameCometarios();

        }
    }
}

