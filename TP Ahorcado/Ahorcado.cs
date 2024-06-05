﻿using System;
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

        public Ahorcado(string palabra)
        {
            palabraSecreta = palabra;
            intentosRestantes = 7;
            haGanado = false;
        }

        public bool ArriesgarPalabra(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra) || palabra.Contains(" ") || !palabra.All(char.IsLetter))
                return false;
            intentosRestantes--;
            if (palabra.Equals(palabraSecreta, StringComparison.OrdinalIgnoreCase))
            {
                haGanado = true;
                return true;
            }

            return false;
        }
        public int IntentosRestantes => intentosRestantes;

        public bool HaPerdido()
        {
            return intentosRestantes == 0 && !haGanado;
        }

    }
}
