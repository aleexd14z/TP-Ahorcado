using Ahorcado.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado.MVC.Controllers
{
    public class AhorcadoController : Controller
    {
        public static TP_Ahorcado.Ahorcado Ahorcado { get; set; } = null!; 

        public ActionResult Index()
        {
            return View(new AhorcadoModel());
        }

        [HttpPost]

        public JsonResult InsertWordToGuess(AhorcadoModel model)
        {
            Ahorcado = new TP_Ahorcado.Ahorcado(model.WordToGuess);
            model.Message = Ahorcado.validarSecretWord();
            if (model.Message == "Palabra secreta invalida")
            {
                Ahorcado = null;
            }
            else
            {
                model.ChancesLeft = Ahorcado.intentosRestantes;
                foreach (var rLetter in Ahorcado.estadoAux)
                {
                    model.GuessingWord += rLetter + " ";
                }
                model.Message = null;
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult TryLetter(AhorcadoModel model)
        {
            char letra;
            try
            {
                letra = Convert.ToChar(model.LetterTyped);
                bool letraEncontrada = Ahorcado.ArriesgarLetra(letra);
                model.Message = letraEncontrada ? "Acierto" : "Incorrecto";
                model.Win = Ahorcado.checkearEstadoActual();
                model.ChancesLeft = Ahorcado.intentosRestantes;
                model.WrongLetters = string.Empty;
                foreach (var wLetter in Ahorcado.letrasIncorrectas)
                {
                    model.WrongLetters += wLetter + ",";
                }
                model.GuessingWord = string.Empty;
                foreach (var rLetter in Ahorcado.estadoAux)
                {
                    model.GuessingWord += rLetter + " ";
                }
                model.LetterTyped = string.Empty;
            }
            catch (FormatException e)
            {
                model.Message = "Ingrese un caracter válido";
            }
            catch (ArgumentNullException e)
            {
                model.Message = "Ingrese una letra o palabra";
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult TryWord(AhorcadoModel model)
        {
            bool palabraCorrecta = Ahorcado.ArriesgarPalabra(model.LetterTyped);
            model.Message = palabraCorrecta ? "¡Palabra correcta!" : "Palabra incorrecta.";
            Console.WriteLine($"Mensaje generado: {model.Message}");
            model.Win = Ahorcado.checkearEstadoActual();
            model.ChancesLeft = Ahorcado.intentosRestantes;
            model.WrongLetters = string.Empty;
            foreach (var wLetter in Ahorcado.letrasIncorrectas) //
            {
                model.WrongLetters += wLetter + ",";
            }
            model.GuessingWord = string.Empty;
            foreach (var rLetter in Ahorcado.estadoAux)
            {
                model.GuessingWord += rLetter + " ";
            }
            model.LetterTyped = string.Empty;
            return Json(model);
        }
    }
}
