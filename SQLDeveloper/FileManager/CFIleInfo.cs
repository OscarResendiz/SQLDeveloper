using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public enum TIPOC_AMBIO
    {
        CMABIO_CONTENIDO,
        ELIMINADO,
        RENOMBRADO
    }
    public delegate void OnFileChangeEvent(CFIleInfo info, TIPOC_AMBIO tipo);
    public class CFIleInfo
    {
        public event OnFileChangeEvent OnFileChange;
        public string NombreCorto
        {
            get;
            set;
        }
        public string Contenido
        {
            get;
            set;
        }
        public string NombreCompleto
        {
            get;
            set;
        }
        public void FileChange(TIPOC_AMBIO tipo)
        {
            if(OnFileChange!=null )
            {
                OnFileChange(this,tipo);
            }
        }
        public string Path
        {
            get
            {
                int i, n, pos=0;
                n = NombreCompleto.Length;
                for(i=0;i<n;i++)
                {
                    if (NombreCompleto[i] == '\\')
                        pos = i;
                }
                return NombreCompleto.Substring(0, pos);
            }
        }

    }
}
