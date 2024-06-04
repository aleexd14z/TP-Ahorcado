using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Ahorcado
{
    public class Ahorcado
    {
        private string palabraSecreta;

        public Ahorcado(string palabra)
        {
            palabraSecreta = palabra;
        }

        public bool ArriesgarPalabra(string palabra)
        {
            if (palabra.Equals(palabraSecreta, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
