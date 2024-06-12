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
        private List<char> letrasIncorrectas;
        private string nombreUsuario;
        private int puntuacion;
        private int letrasAcertadas;
        private string estadoAnterior;
        private const int PUNTOS_POR_VIDA = 15;
        private const int VALOR_POR_LETRA_FALTANTE = 50;


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
            letrasAcertadas = 0;
            estadoAnterior = new string(estadoAux);
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
                    letrasAcertadas++;
                }
            }
            if (!letraEncontrada && !letrasIncorrectas.Contains(letra)) 
            {
                letrasIncorrectas.Add(letra);
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

        public bool IngresarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre) || !nombre.All(char.IsLetter))
            {
                return false;
            }
            nombreUsuario = nombre;
            return true;
        }

        public int CalcularPuntuacion()
        {
            puntuacion = 0;
            if (haGanado)
            {
                int letrasFaltantes = estadoAnterior.Count(letra => letra == '_');
                int letrasIncorrectas = LetrasIncorrectas.Count;
                puntuacion += (IntentosRestantes * PUNTOS_POR_VIDA);
                if (letrasFaltantes == 2)
                    puntuacion += VALOR_POR_LETRA_FALTANTE;
                else if (letrasFaltantes > 2)
                    puntuacion += VALOR_POR_LETRA_FALTANTE * letrasFaltantes;
            }
            return puntuacion;
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

        private void TerminarPartida()
        {
            if (haGanado)
            {
                puntuacion = CalcularPuntuacion();
                Console.WriteLine($"¡Felicidades! Has ganado con una puntuación de {puntuacion}.");
            }
            else
                Console.WriteLine("Derrota. Mejor suerte la próxima vez.");
        }

    }
}
