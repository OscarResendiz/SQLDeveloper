using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compiler.Lexer;

namespace SQLDeveloper.Modulos.Visores.Variables
{
    public partial class FormVariables : Form
    {
        private List<CDefinicionVariable> DefVariables;
        private List<CDefinicionTabla> DefTablas;
        private List<Compiler.Lexer.Lexema> Variables;
        private DateTime ProximoAnalisis = System.DateTime.Now;
        private int Intervalo = 25; //cada 5 segundos hace un analisis
        private bool Analizando;
        private bool LexemasListos;
        ICSharpCode.TextEditor.TextEditorControl FEditor;
        public FormVariables()
        {
            Variables = new List<Compiler.Lexer.Lexema>();
            InitializeComponent();
        }
        public ICSharpCode.TextEditor.TextEditorControl Editor
        {
            get
            {
                return FEditor;
            }
            set
            {
                FEditor = value;
                if (FEditor != null)
                    ProximoAnalisis = System.DateTime.Now;
            }
        }

        private void FormVariables_Load(object sender, EventArgs e)
        {
            Analizando = true;
            ProximoAnalisis = System.DateTime.Now;
            BkAnalisador.RunWorkerAsync();
        }
        private void AgregaVariale(Compiler.Lexer.Lexema lex)
        {
            foreach (Compiler.Lexer.Lexema obj in Variables)
            {
                if (obj.Texto.ToUpper().Trim() == lex.Texto.ToUpper().Trim())
                {
                    return; //ya existe
                }
            }
            Variables.Add(lex);
        }
        private void BkAnalisador_DoWork(object sender, DoWorkEventArgs e)
        {
            //siclo infinito que mantiene el analisi hasta que se indique lo contrario
            while (Analizando)
            {
                //veo si es hora de hacer el analisis
                if (ProximoAnalisis <= System.DateTime.Now && FEditor != null)
                {
                    //mando a analizar la cadena
                    LexemasListos = false;
                    BkAnalisador.ReportProgress(0);
                    //y espero a que se estabilice
                    while (LexemasListos == false)
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                    //primero identifico las variables y tablas tmporales
                    Variables.Clear();
                    if (DefTablas == null)
                        DefTablas = new List<CDefinicionTabla>();
                    DefTablas.Clear();
                    foreach (Lexema lex in lecxer1)
                    {
                        if (lex.Tipo == LEXTIPE.SQLVARIABLE || lex.Tipo == LEXTIPE.TABLATEMPORAL)
                        {
                            AgregaVariale(lex);
                        }
                    }
                    //identifico el tipo de variable
                    foreach (Compiler.Lexer.Lexema obj in Variables)
                    {
                        if (obj.Tipo == LEXTIPE.SQLVARIABLE)
                            BuscaVariable(obj);
                        if (obj.Tipo == LEXTIPE.TABLATEMPORAL)
                            BuscaTabla(obj);
                    }
                    //aviso que ya identifique las variables para que se muestren en la pantalla
                    BkAnalisador.ReportProgress(1);
                    //Calculo a que hora hay que hacer el proximo analisis
                    ProximoAnalisis = System.DateTime.Now.AddSeconds(Intervalo);
                }
            }
        }
        private void MuestraVariables(List<Lexema> l)
        {
            int pos = 0;
            while (pos < Lista.Items.Count)
            {
                //me traigo el item
                string s = (string)Lista.Items[pos];
                //veo si se encuentra en la lista
                bool encontrado = false;
                foreach (Lexema lex in l)
                {
                    if (lex.Texto == s)
                    {
                        encontrado = true;
                        pos++;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    //hay que eliminarlo
                    Lista.Items.Remove(s);
                }
            }
            //ahora agrego los nuevos
            foreach (Lexema lex in l)
            {
                bool encontrado = false;
                foreach (string s in Lista.Items)
                {
                    if (s == lex.Texto)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado == false)
                {
                    Lista.Items.Add(lex.Texto);
                }
            }


        }
        private void BkAnalisador_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                if (DefVariables == null)
                    DefVariables = new List<CDefinicionVariable>();
                else
                    DefVariables.Clear();
                lecxer1.Cadena = FEditor.Text;
                LexemasListos = true;
            }
            if (e.ProgressPercentage == 1)
            {
                //ya termino de buscar las variables y tablas temporales y se encuentran en la lista
                //primero quito las que ya no deben de estar
                TFiltro_TextChanged(null, null);
                //MuestraVariables(Variables);
            }
        }
        private void BuscaVariable(Lexema variable)
        {
            //se asume que la primer aparicion de la variable es cuando se declara ya que puede ser parametro de un procedimiento almacenado o una variable
            Lexema tipo;
            Lexema tam=null;
            string longitud = "";
            bool usaTam = false;
            int index = variable.Index+1;
            lecxer1.MueveCursorA(index);
            tipo = lecxer1.DameSiguienteLexemaUtil();
            if(tipo==null)
                return;
            if(tipo.Tipo== LEXTIPE.PALABRARESERVADA && tipo.PalabraReservada== PALABRASRESERVADAS.TABLE )
            {
                //es una tabla
                BuscaTabla(variable);
                return;
            }
            tam = lecxer1.DameSiguienteLexemaUtil();
            if (tam == null)
                return;
            if(tam.Tipo== LEXTIPE.PARENTESISABRE)
            {
                //maneja un tamaño
                tam = lecxer1.DameSiguienteLexemaUtil();
                if (tam == null)
                    return;                    
                usaTam = true;
                longitud = tam.Texto;
            }
            AgregaDefinicionVariable(variable.Texto, tipo.Texto, usaTam, longitud);
        }
        private void AgregaDefinicionVariable(string nombre, string tipo, bool usaLongitud, string longitud)
        {
            if (DefVariables == null)
                DefVariables = new List<CDefinicionVariable>();
            DefVariables.Add(new CDefinicionVariable()

                {
                    Longitud = longitud
                     ,
                    Tipo = tipo
                     ,
                    UsaLongitud = usaLongitud
                     ,
                    Variable = nombre
                });
        }
        private void BuscaTabla(Lexema tabla)
        {
            int index = tabla.Index;
            CDefinicionTabla dt = new CDefinicionTabla();
            dt.Nombre = tabla.Texto;
            Lexema lex=null;
            bool analizando=true;
            //establesco el cursos en la posicion donde empieza la tabla
            lecxer1.MueveCursorA(index+1);
            //primer busco el parentesis donde empieza la definicion de la tabla
            lex=lecxer1.DameSiguienteLexemaUtil();
            if(lex==null)
                return;
            if (tabla.Tipo == LEXTIPE.SQLVARIABLE)
            {
                if (lex.Tipo != LEXTIPE.PALABRARESERVADA || lex.PalabraReservada != PALABRASRESERVADAS.TABLE)
                    return;
                lex = lecxer1.DameSiguienteLexemaUtil();
                if (lex == null)
                    return;
            }
            //lo siguiente que se espera es el parentesis que abre la tabla
            if (lex.Tipo != LEXTIPE.PARENTESISABRE)
                return;

            //aqui es donde inicia el primer campo
            do
            {
                CDefinicionCampo campo = new CDefinicionCampo();
                //me traigo el nombre del campo
                lex = lecxer1.DameSiguienteLexemaUtil();
                if (lex == null)
                    break;
                if (lex.Tipo != LEXTIPE.IDENTIFICADOR)
                    break;
                campo.Nombre = lex.Texto;
                //ahora sigue el tipo 
                lex = lecxer1.DameSiguienteLexemaUtil();
                if (lex == null)
                    break;
                campo.Tipo = lex.Texto;
                //me traigo el siguiente lexema
                lex = lecxer1.DameSiguienteLexemaUtil();
                if (lex == null)
                    break;
                #region Puede tener longitud (tam)
                //puede ser la longitus (tamaño)
                if(lex.Tipo== LEXTIPE.PARENTESISABRE)
                {
                    //me traigo el tamño
                    lex = lecxer1.DameSiguienteLexemaUtil();
                    if (lex == null)
                        break;
                    if (lex.Tipo != LEXTIPE.NUMERO &&(lex.Tipo!= LEXTIPE.PALABRARESERVADA || lex.PalabraReservada!= PALABRASRESERVADAS.MAX))
                        break;
                    campo.Longitud = lex.Texto;
                    //desecho el )
                    lex = lecxer1.DameSiguienteLexemaUtil();
                    if (lex == null)
                        break;
                    //veo si el siguiente item es la coma
                    lex = lecxer1.DameSiguienteLexemaUtil();
                    if (lex == null)
                        break;
                    if(lex.Tipo!= LEXTIPE.COMA)
                    {
                        //no es la coma, por lo que regreso el item para no afectar el analisis
                        lecxer1.DesechaLexema();
                    }
                }
                #endregion
                #region puese ser NOT NULL
                else if(lex.Tipo== LEXTIPE.PALABRARESERVADA)
                {
                    //puede ser NOT NULL
                    if(lex.PalabraReservada== PALABRASRESERVADAS.NOT)
                    {
                        lex = lecxer1.DameSiguienteLexemaUtil();
                        if (lex == null)
                            break;
                        if(lex.Tipo== LEXTIPE.PALABRARESERVADA && lex.PalabraReservada== PALABRASRESERVADAS.NULL)
                        {
                            //no acepta nulos
                            campo.AceptaNulos = false;
                        }
                    }
                    else if(lex.PalabraReservada== PALABRASRESERVADAS.PRIMARY)
                    {
                        //puede ser primary key
                        lex = lecxer1.DameSiguienteLexemaUtil();
                        if(lex.Tipo== LEXTIPE.PALABRARESERVADA && lex.PalabraReservada== PALABRASRESERVADAS.KEY)
                        {
                            campo.PrimaryKey = true;
                        }
                    }
                    #region Se mueve hasta encontrar el final del campo
                    //ahora desecho los demas lexcemas hasta encontrar la coma o el ) que cierra la tabla
                    else
                    {
                        do
                        {
                            lex = lecxer1.DameSiguienteLexemaUtil();
                            if (lex == null)
                                break;
                            if (lex.Tipo == LEXTIPE.COMA)
                                break;
                            if (lex.Tipo == LEXTIPE.PARENTESISCIERRA)
                                break;
                        } while (true);
                    }
                    #endregion
                }
                #endregion
                #region puede ser el final de la tabla )
                else if(lex.Tipo== LEXTIPE.PARENTESISCIERRA)
                {
                    //me salgo del siclo
                    dt.Add(campo);
                    break;
                }
                #endregion
                #region Si no es COMA, busca el final del campo
                else if (lex.Tipo == LEXTIPE.COMA)
                {
                    //me paso analizar el siguiente campo
                    dt.Add(campo);
                    continue;
                }
                #endregion
                #region Se mueve hasta encontrar el final del campo
                //ahora desecho los demas lexcemas hasta encontrar la coma o el ) que cierra la tabla
                else
                {
                    do
                    {
                        lex = lecxer1.DameSiguienteLexemaUtil();
                        if (lex == null)
                            break;
                        if (lex.Tipo == LEXTIPE.COMA)
                            break;
                        if (lex.Tipo == LEXTIPE.PARENTESISCIERRA)
                            break;
                    } while (true);
                }
                #endregion
                //agrego el campo a la tabla
                dt.Add(campo);
            } while (analizando);
            //agrego la tabla a la lista
            if(dt.DameCampos().Count()>0)
            {
                DefTablas.Add(dt);
            }

        }

        private void Lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lista.SelectedIndex == -1)
                return;
            string nombre = (string)Lista.SelectedItem;
            //lo busco en las tablas
            foreach(CDefinicionTabla tbl in DefTablas)
            {
                if(tbl.Nombre.ToUpper().Trim()==nombre.ToUpper().Trim())
                {
                    PropiedadesTabla pt = new PropiedadesTabla();
                    pt.Tabla = tbl;
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(pt);
                    pt.Dock = DockStyle.Fill;
                    return;
                }
            }
            //no es tabla, por lo que es variable
            foreach(CDefinicionVariable var in DefVariables)
            {
                if(var.Variable.ToUpper().Trim()==nombre.ToUpper().Trim())
                {

                    PropiedadesVariable pt = new PropiedadesVariable();
                    pt.Variable = var;
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(pt);
                    pt.Dock = DockStyle.Fill;
                    return;

                }
            }
        }

        private void TFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Lexema>l=new List<Lexema>();
            foreach (Compiler.Lexer.Lexema obj in Variables)
            {
                if(obj.Texto.ToUpper().Trim().Contains(TFiltro.Text.ToUpper().Trim()))
                {
                    l.Add(obj);;
                }
            }
            MuestraVariables(l);
        }

        private void FormVariables_FormClosing(object sender, FormClosingEventArgs e)
        {
            Analizando = false;
        }
    }
}
