using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.TextEditor.Gui.CompletionWindow;


namespace Inteliences
{
    class CInteliencesObject: ICompletionData
    {
        #region Implementacion de la inserface ICompletionData
        public int ImageIndex
        {
            get 
            {
                //dependiendo del tipo de objeto hay que regresar el indice de la imagen
                return 0;
            }
        }

        public string Text
        {
            get;
            set;
        }

        public string Description
        {
            get 
            {
                return Text;
            }
        }

        public double Priority
        {
            get 
            {
                return 1.0;
            }
        }

        public bool InsertAction(ICSharpCode.TextEditor.TextArea textArea, char ch)
        {
            //aqui hay que poner el codigo que se va a remplazar cuando se selecciona la opcion de
            //inteliense
            //por ahorita solo inserto el texto
            textArea.InsertString(Text);
            return false;
        }
        #endregion
    }
}
