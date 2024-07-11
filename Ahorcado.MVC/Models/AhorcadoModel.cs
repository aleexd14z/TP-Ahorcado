using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Ahorcado.MVC.Models
{
    public class AhorcadoModel
    {
        [DisplayName("Letra")]
        public string LetterTyped { get; set; } = string.Empty;

        [DisplayName("Palabra")]
        public string WordToGuess { get; set; } = string.Empty;

        [DisplayName("Letras acertadas")]
        public string GuessingWord { get; set; } = string.Empty;

        [DisplayName("Chances Restantes")]
        public int? ChancesLeft { get; set; }

        [DisplayName("Letras Erradas")]
        public string WrongLetters { get; set; } = string.Empty;

        [DisplayName("Mensaje")]
        public string? Message { get; set; }

        public bool Win { get; set; }
    }
}
