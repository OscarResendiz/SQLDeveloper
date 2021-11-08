using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Compiler.Lexer
{
    public class LexEnumerable : IEnumerator
    {
        int position = -1;
        public List<Lexema> lexemas;
        public LexEnumerable(List<Lexema> l)
        {
            lexemas = l;
        }
        public bool MoveNext()
        {
            position++;
            return (position < lexemas.Count());
        }
        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Lexema Current
        {
            get
            {
                try
                {
                    return lexemas[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
