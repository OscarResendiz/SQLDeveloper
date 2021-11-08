using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using System.Diagnostics;


namespace SQLDeveloper.Modulos.AppsAnalizer.Nodos
{
    public class CNodoDependencia : CNodoObjeto
    {
        private ManagerConnect.CConexion FConexionPadre;
        private String FservidorPadre;
        private int ID_ObjetoPadre;
        public CNodoDependencia(int id_objeto, int id_objetoPadre)
            : base(id_objeto)
        {
            ID_ObjetoPadre = id_objetoPadre;
        }
        protected override void MenuEliminar(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("¿Deseas eliminar la referencia del objeto: " + Nombre + "?", "Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            ObjetosModelo.CObjetoObjeto obj = Modelo.GetObjetoObjeto(ID_ObjetoPadre, ID_Objeto);
            obj.delete();
        }
        public override void AgregaRegistrosReporte(System.Data.DataTable tabla, DataRow rp, int nivel)
        {

            base.AgregaRegistrosReporte(tabla, rp, nivel);
        }
        public override int calculaNivel(int n)
        {
            if (Nodes.Count == 0)
                return n + 1;
            int max = n + 1;
            foreach (CNodoBase nodo in Nodes)
            {
                int x = nodo.calculaNivel(n + 1);
                if (x > max)
                    max = x;
            }
            return max;
        }
        protected override void InicializaMenu()
        {
            base.InicializaMenu();
            this.AddMenuItem("Ver Referencia", "buscar", MenuVerReferencia);
            this.AddMenuItem("Marcar y eliminar las otras referencias", "Resaltar", MenuResaltarYEliminar);

        }
        private ManagerConnect.CConexion ConexionPadre
        {
            get
            {
                if (FConexionPadre == null)
                {
                    ObjetosModelo.CObjeto objeto = Modelo.GetObjeto(ID_ObjetoPadre);
                    ObjetosModelo.CConexion con = Modelo.GetConexion(objeto.ID_Conexion);
                    ObjetosModelo.CServidor server = Modelo.GetServidor(con.ID_Servidor);
                    FservidorPadre = server.Nombre;
                    FConexionPadre = ManagerConnect.ControladorConexiones.GetConexion(server.Nombre, con.Nombre);
                }
                return FConexionPadre;
            }
        }

        private string DameCodigoPadre()
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_ObjetoPadre);
            MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(ConexionPadre);
            string s = "";
            switch (obj.TipoObjeto)
            {
                case MotorDB.EnumTipoObjeto.FUNCION:
                    s = motor.DameCodigoFuncction(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.PROCEDURE:
                    s = motor.DameCodigoStoreProcedure(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TABLE:
                    s = motor.DameCodigoTabla(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TRIGER:
                    s = motor.DameCodigoTrigger(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.VIEW:
                    s = motor.DameCodigoVista(obj.Nombre);
                    break;
                case MotorDB.EnumTipoObjeto.TYPE_TABLE:
                    s = motor.DameCodigoTypeTable(obj.Nombre);
                    break;
            }
            return s;
        }
        private void MenuVerReferencia(object sender, EventArgs e)
        {
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto);
            string nombre=obj.Nombre.ToUpper().Trim();
            // me traigo el codigo del padre
            string codigo = DameCodigoPadre();
            //ahora separo el codigo por lineas
            string[] lineas = codigo.Split('\n');
            string lineasEncontradas="";
            //recorro las lineas para buscar cuales contienen la definicion del objeto
            Compiler.Lexer.Lecxer lex = new Compiler.Lexer.Lecxer();
            foreach(string linea in lineas)
            {
                if (linea.ToUpper().Contains(nombre))
                {
                    lex.Cadena = linea.ToUpper();
                    foreach (Compiler.Lexer.Lexema c in lex)
                    {
                        if (c.Texto == nombre)
                        {
                            //si contiene la cadena buscada
                            lineasEncontradas = lineasEncontradas + linea ;
                            break;
                        }
                    }
                }
            }
            CNodoDependencias padre = (CNodoDependencias)this.Parent;
            //muestro el resultado
            if (padre.Editor == null || padre.Editor.Parent.Parent==null)
            {
                //me traigo el motor
                MotorDB.IMotorDB motor = ManagerConnect.ControladorConexiones.DameMotor(ConexionPadre);
                //me traigo el acceso al formulario
                Formularios.FormAppsAnalizer dlg = (Formularios.FormAppsAnalizer)TreeView.Tag;
                ObjetosModelo.CObjeto objPadre = Modelo.GetObjeto(this.ID_ObjetoPadre);

                //mando a mostrar el codigo
                padre.Editor = (TextEditor.CTextEdit)dlg.VerCodigo(objPadre.Nombre, lineasEncontradas, motor, FservidorPadre, ConexionPadre.Nombre);
            }
            else
            {
                padre.Editor.CodigoFuente = lineasEncontradas;
                System.Windows.Forms.TabControl tab = (System.Windows.Forms.TabControl)padre.Editor.Parent.Parent;
                tab.SelectedTab = (System.Windows.Forms.TabPage)padre.Editor.Parent;
            }
            MarcarCoincidencias(nombre, false, true, Color.Yellow, padre.Editor.getTCodigo());
        }
        #region Resaltado de texto
        Dictionary<TextEditorControl, TextEditor.HighlightGroup> _highlightGroups = new Dictionary<TextEditorControl, TextEditor.HighlightGroup>();
        private Modulos.Editores.TextEditorSearcher _search;

        private void MarcarCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar, ICSharpCode.TextEditor.TextEditorControl TCodigo)
        {
            if (!_highlightGroups.ContainsKey(TCodigo))
                _highlightGroups[TCodigo] = new TextEditor.HighlightGroup(TCodigo);
            TextEditor.HighlightGroup group = _highlightGroups[TCodigo];

            if (string.IsNullOrEmpty(textoBuscar))
            {
                // Clear highlights
                group.ClearMarkers();
            }
            else
            {
                if (_search == null)
                {
                    _search = new Modulos.Editores.TextEditorSearcher();
                    _search.Document = TCodigo.Document;
                }
               _search.LookFor = textoBuscar;
                _search.MatchCase = CaseSensitive;
                _search.MatchWholeWordOnly = WholeWords;

                bool looped = false;
                int offset = 0, count = 0;
                for (; ; )
                {
                    Modulos.Editores.TextRange range = _search.FindNext(offset, false, out looped);
                    if (range == null || looped)
                        break;
                    offset = range.Offset + range.Length;
                    count++;

                    var m = new TextMarker(range.Offset, range.Length,
                            TextMarkerType.SolidBlock, ColorAplicar, Color.Black);
                    group.AddMarker(m);
                }
                //                if (count == 0)
                //                  MessageBox.Show("Cadena buscada no encontrada.‘);
            }
            TCodigo.Refresh();
        }
        private void QuitaCoincidencias(string textoBuscar, bool CaseSensitive, bool WholeWords, Color ColorAplicar, ICSharpCode.TextEditor.TextEditorControl TCodigo)
        {
            if (!_highlightGroups.ContainsKey(TCodigo))
                _highlightGroups[TCodigo] = new TextEditor.HighlightGroup(TCodigo);
            TextEditor.HighlightGroup group = _highlightGroups[TCodigo];

            if (string.IsNullOrEmpty(textoBuscar))
            {
                // Clear highlights
                group.ClearMarkers();
            }
            else
            {
                if (_search == null)
                    _search = new Modulos.Editores.TextEditorSearcher();
                _search.LookFor = textoBuscar;
                _search.MatchCase = CaseSensitive;
                _search.MatchWholeWordOnly = WholeWords;

                bool looped = false;
                int offset = 0, count = 0;
                for (; ; )
                {
                    Modulos.Editores.TextRange range = _search.FindNext(offset, false, out looped);
                    if (range == null || looped)
                        break;
                    offset = range.Offset + range.Length;
                    count++;

                    var m = new TextMarker(range.Offset, range.Length,
                            TextMarkerType.SolidBlock, ColorAplicar, Color.Black);
                    group.RemoveMarker(m);
                }
            }
            TCodigo.Refresh();
       }
        #endregion
        private void MenuResaltarYEliminar(object sender, EventArgs e)
        {

            if (System.Windows.MessageBox.Show("¿Deseas eliminar las otras referencias del objeto excepto: " + Nombre + "?", "Resaltar y Eliminar", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) != System.Windows.MessageBoxResult.Yes)
            {
                return;
            }
            ObjetosModelo.CObjeto obj = Modelo.GetObjeto(this.ID_Objeto); //me ôraigo el objeto referencia
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            dlg.Color = obj.BKColor;
           if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            obj.BKColor = dlg.Color;
            obj.update();
            //ahora me traigo las demas dependencias
            List<ObjetosModelo.CObjetoObjeto> l = Modelo.GetObjetoObjetos(this.ID_ObjetoPadre);
            int n = l.Count;
            for(int i=0;i<n;i++)
            {
                ObjetosModelo.CObjetoObjeto referencia=l[i];
                //veo que no sea mi refrencia
                if (referencia.ID_ObjetoHijo != this.ID_Objeto)
                {
                    ObjetosModelo.CObjeto objeto2 = referencia.getObjeto();
                    if (obj.Nombre.ToUpper().Trim() == objeto2.Nombre.ToUpper().Trim())
                    {
                        //elimino la refrencia
                        referencia.delete();
                    }
                }
            }
        }
    }
}
   