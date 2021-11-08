using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SQLDeveloper.Modulos.AppsAnalizer.Analizadores
{
    class CFileTextAnalizer: IFileAnalizer
    {
        event FileAnalizerEvent AnalizarObjetoEvent;
        ObjetosModelo.CArchivo Archivo;
        /// <summary>
        /// asigna el maejador de evento donde aviso que encontre una cadena
        /// </summary>
        /// <param name="e"></param>
        public void AddAnalizarObjetoEvent(FileAnalizerEvent e)
        {
            AnalizarObjetoEvent += e;
        }
        public void analiza(ObjetosModelo.CArchivo archivo)
        {
            try
            {
                List<String> l = new List<string>();
                Archivo = archivo;
                //abro el archivo
                StreamReader sr = File.OpenText(archivo.NombreArchivo);
                //leo todo el archivo
                String contenido = sr.ReadToEnd();
                //cierro el archivo porque ya no lo noececito
                sr.Close();
                //ahora busco las cadenas
                Compiler.Lexer.Lecxer lexer = new Compiler.Lexer.Lecxer();
                lexer.Cadena = contenido;
                //recorro todos los lexemas buscando las cadenas
                do
                {
                    Compiler.Lexer.Lexema lex = lexer.DameSiguienteLexemaUtil();
                    if (lex == null)
                        return; //termine
                    if (lex.Tipo == Compiler.Lexer.LEXTIPE.CADENADOBLE || lex.Tipo == Compiler.Lexer.LEXTIPE.CADENASIMPLE)
                    {
                        //veo si esta en la lista
                        bool encontrado=false;
                        foreach(string s in l)
                        {
                            if (s.ToUpper().Trim() == lex.Texto.ToUpper().Trim())
                            {
                                encontrado = true;
                                break;
                            }
                        }
                        //mando a ejecutar el evento
                        if (AnalizarObjetoEvent != null && encontrado==false)
                        {
                            l.Add(lex.Texto);
                            AnalizarObjetoEvent(Archivo.ID_Archivo, lex.PosicionInicial.Linea, lex.Texto, archivo.NombreCorto);
                        }
                    }
                }
                while (true);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

    }
}
   