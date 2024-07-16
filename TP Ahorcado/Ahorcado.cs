using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Ahorcado
{
    public class Ahorcado
    {
        public string palabraSecreta;
        public int intentosRestantes;
        public bool haGanado;
        public char[] estadoAux;
        public List<char> letrasIncorrectas;
        public int puntuacion;
        public string estadoAnterior;
        public const int PUNTOS_POR_VIDA = 15;
        public const int VALOR_POR_LETRA_FALTANTE = 50;
        public const int PUNTUACION_MAXIMA = 100000;


        private static readonly Dictionary<string, List<string>> bancosDePalabras = new Dictionary<string, List<string>>
        {
            { "facil", new List<string> { "gato", "perro", "casa", "sol", "mesa" } },
            { "medio", new List<string> { "elefante", "mariposa", "murcielago", "bicicleta" } },
            { "dificil", new List<string> { "otorrinolaringologia", "electroencefalograma", "paralelepipedo", "anticonstitucionalidad" } }
        };

        public Ahorcado(string entrada)
        {
            if (bancosDePalabras.ContainsKey(entrada))
            {
                palabraSecreta = SeleccionarPalabra(entrada);
            }
            else
            {
                palabraSecreta = entrada;
            }
            intentosRestantes = 7;
            haGanado = false;
            estadoAux = new string('_', palabraSecreta.Length).ToCharArray();
            letrasIncorrectas = new List<char>();
            estadoAnterior = new string(estadoAux);
        }

        public string validarSecretWord()
        {
            if (string.IsNullOrWhiteSpace(palabraSecreta) || !palabraSecreta.All(char.IsLetter))
            {
                return "Palabra secreta invalida";
            }
            else
            {
                return "Valida";
            }
        }

        private static string SeleccionarPalabra(string dificultad)
        {
            var palabras = bancosDePalabras[dificultad];
            var random = new Random();
            int index = random.Next(palabras.Count);
            return palabras[index];
        }

        public bool ArriesgarPalabra(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra) || palabra.Contains(" ") || !palabra.All(char.IsLetter))
                return false;
            if (palabra.Equals(palabraSecreta, StringComparison.OrdinalIgnoreCase))
            {
                haGanado = true;
                estadoAnterior = new string(estadoAux);
                estadoAux = palabraSecreta.ToCharArray();
                return true;
            }
            intentosRestantes--;
            return false;
        }

        public bool ArriesgarLetra(char letra)
        {
            if (!char.IsLetter(letra) || estadoAux.Contains(letra))
                return false;

            letra = char.ToLower(letra);
            bool letraEncontrada = false;
            estadoAnterior = new string(estadoAux);

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
                if (!letrasIncorrectas.Contains(letra))
                {
                    letrasIncorrectas.Add(letra);
                }
                intentosRestantes--;
            }
            if (!estadoAux.Contains('_'))
            {
                haGanado = true;
            }

            return letraEncontrada;
        }

        public List<int> ObtenerPosicionesLetra(char letra)
        {
            List<int> posiciones = new List<int>();
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (char.ToLower(palabraSecreta[i]) == char.ToLower(letra))
                {
                    posiciones.Add(i);
                }
            }
            return posiciones;
        }

        public List<char> LetrasCorrectas()
        {
            List<char> letrasCorrectas = new List<char>();
            foreach (char letra in estadoAux)
            {
                if (char.IsLetter(letra))
                {
                    letrasCorrectas.Add(letra);
                }
            }
            return letrasCorrectas;
        }

        /* public bool IngresarNombre(string nombre)
         {
             if (string.IsNullOrWhiteSpace(nombre) || !nombre.All(char.IsLetter))
             {
                 return false;
             }
             nombreUsuario = nombre;
             return true;
         } */

        public int CalcularPuntuacion()
        {
            puntuacion = 0;
            if (haGanado)
            {
                int letrasFaltantes = estadoAnterior.Count(letra => letra == '_');
                puntuacion += (IntentosRestantes * PUNTOS_POR_VIDA);
                if (letrasFaltantes == 2)
                    puntuacion += VALOR_POR_LETRA_FALTANTE;
                else if (letrasFaltantes > 2)
                    puntuacion += VALOR_POR_LETRA_FALTANTE * letrasFaltantes;
                if (estadoAnterior.All(letra => letra == '_') && intentosRestantes == 7)  // Si no había ninguna letra arriesgada
                    puntuacion = PUNTUACION_MAXIMA;  // Puntuación máxima por adivinar la palabra sin letras arriesgadas

            }
            return puntuacion;
        }

        public void DarPista()
        {
            var random = new Random();
            var letrasOcultas = new List<int>();

            for (int i = 0; i < estadoAux.Length; i++)
            {
                if (estadoAux[i] == '_')
                {
                    letrasOcultas.Add(i);
                }
            }

            if (letrasOcultas.Count > 0)
            {
                int indiceAleatorio = random.Next(letrasOcultas.Count);
                int posicion = letrasOcultas[indiceAleatorio];
                estadoAux[posicion] = palabraSecreta[posicion];
            }
        }

        public string MostrarEstado()
        {
            return new string(estadoAux);
        }

        public string ObtenerPalabraSecreta()
        {
            return palabraSecreta;
        }

        public bool HaPerdido()
        {
            return intentosRestantes == 0 && !haGanado;
        }

        public int IntentosRestantes => intentosRestantes;

        public string PalabraSecreta => palabraSecreta;

        public List<char> LetrasIncorrectas { get { return letrasIncorrectas; } }

        public string TerminarPartida()
        {
            if (haGanado)
            {
                puntuacion = CalcularPuntuacion();
                return $"¡Felicidades! Has ganado con una puntuación de {puntuacion}.";
            }
            else
                return "Derrota. Mejor suerte la próxima vez."; //nada
        }

        public bool checkearEstadoActual()
        {
            if (estadoAux.Contains('_')) return false;
            else return true;
        } 
    }
}
