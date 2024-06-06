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
        private int intentosRestantes;
        private bool haGanado;
        private char[] estadoAux;

        public Ahorcado(string palabra)
        {
            palabraSecreta = palabra;
            intentosRestantes = 7;
            haGanado = false;
            estadoAux = new string('_', palabra.Length).ToCharArray();
        }

        public bool ArriesgarPalabra(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra) || palabra.Contains(" ") || !palabra.All(char.IsLetter))
                return false;
            if (palabra.Equals(palabraSecreta, StringComparison.OrdinalIgnoreCase))
            {
                haGanado = true;
                estadoAux = palabraSecreta.ToCharArray();
                return true;
            }
            intentosRestantes--;
            return false;
        }

        public bool ArriesgarLetra(char letra)
        {
            if (!char.IsLetter(letra))
                return false;

            letra = char.ToLower(letra);   
            bool letraEncontrada = false;


            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (char.ToLower(palabraSecreta[i]) == letra)
                {
                    estadoAux[i] = palabraSecreta[i];
                    letraEncontrada = true;
                }
            }
            if (!letraEncontrada)
            {
                intentosRestantes--;
            }

            return letraEncontrada;
        }

        public string MostrarEstado()
        {
            return new string(estadoAux);
        }

        public bool HaPerdido()
        {
            return intentosRestantes == 0 && !haGanado;
        }
        public int IntentosRestantes => intentosRestantes;

    }
}
