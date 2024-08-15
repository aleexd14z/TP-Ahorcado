using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Ahorcado.UIAutomation
{
    [Binding]
    public class HangmanSpecflow
    {
        IWebDriver driver;
        String baseURL = "https://agilesv2.azurewebsites.net/";
        int chancesLeftAnt;
        private WebDriverWait wait;

        [BeforeScenario]
        public void TestInitialize()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            //var path = AppDomain.CurrentDomain.BaseDirectory + @"\Drivers\chromedriver.exe";
            var path = AppDomain.CurrentDomain.BaseDirectory + @"../../../Drivers\chromedriver.exe";
            //chromeOptions.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            chromeOptions.AddArgument("--start-maximized"); // Opcional: maximiza la ventana del navegador

            driver = new ChromeDriver(path, chromeOptions);
            //driver = new ChromeDriver(chromeOptions);
        }

        /*  //Primer test - perder el juego
          [Given(@"I have entered Ahorcado as the wordToGuess")]
          public void GivenIHaveEnteredAhorcadoAsTheWordToGuess()
          {
              driver.Navigate().GoToUrl(baseURL);

              Thread.Sleep(5000);

              var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
              txtPalabra.SendKeys("Ahorcado");

              Thread.Sleep(5000);

              var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
              btnInsertWord.SendKeys(Keys.Enter);

              Thread.Sleep(5000);
          }

          [When(@"I enter X as the typedLetter five times")]
          public void WhenIEnterXAsTheTypedLetterFiveTimes()
          {
              var letterTyped = driver.FindElement(By.Id("LetterTyped"));
              var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
              List<char> lettersRisked = ['s', 't', 'w', 'z', 'y', 'k', 'v'];
              for (int i = 0; i < 7; i++)
              {
                  letterTyped.SendKeys(lettersRisked[i].ToString());
                  Thread.Sleep(5000);
                  btnInsertLetter.SendKeys(Keys.Enter);
                  Thread.Sleep(5000);
                  letterTyped.Clear(); // Limpiar el campo después de cada letra
                  Thread.Sleep(5000);
              }
          }

          [Then(@"I should be told that I lost")]
          public void ThenIShouldBeToldThatILost()
          {
              Thread.Sleep(5000);
              var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
              var loss = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 0;
              Thread.Sleep(5000);
              Assert.IsTrue(loss);
              Thread.Sleep(5000);
          } 

          [AfterScenario]
          public void TestCleanUp()
          {
              //driver.Quit();
          }


          //Segundo test - acertar una letra
          [Given(@"I have entered Hola as the wordToGuess")]
          public void GivenIHaveEnteredHolaAsTheWordToGuess()
          {
              driver.Navigate().GoToUrl(baseURL);

              Thread.Sleep(5000);

              var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
              txtPalabra.SendKeys("Hola");

              Thread.Sleep(5000);

              var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
              btnInsertWord.SendKeys(Keys.Enter);

              Thread.Sleep(5000);
          }

          [When(@"I enter A as the typedLetter one time")]
          public void WhenIEnterAAsTheTypedLetterOneTime()
          {
              Thread.Sleep(5000);
              var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
              chancesLeftAnt = Convert.ToInt32(chancesLeft.GetAttribute("value"));
              var letterTyped = driver.FindElement(By.Id("LetterTyped"));
              var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
              letterTyped.SendKeys("A");
              Thread.Sleep(5000);
              btnInsertLetter.SendKeys(Keys.Enter);
          }

          [Then(@"I should be told that I hit the letter")]
          public void ThenIShouldBeToldThatIHitTheLetter()
          {
              Thread.Sleep(5000);
              var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
              Thread.Sleep(5000);
              var hit = Convert.ToInt32(chancesLeft.GetAttribute("value")) == chancesLeftAnt;
              Thread.Sleep(5000);
              Assert.IsTrue(hit);
              Thread.Sleep(5000);
          }  


          //Tercer test - Insertar un numero
          [Given(@"I have entered Computadora as the wordToGuess")]
          public void GivenIHaveEnteredComputadoraAsTheWordToGuess()
          {
              driver.Navigate().GoToUrl(baseURL);

              Thread.Sleep(5000);

              var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
              txtPalabra.SendKeys("computadora");

              Thread.Sleep(5000);

              var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
              btnInsertWord.SendKeys(Keys.Enter);

              Thread.Sleep(5000);
          }

          [When(@"I enter 4 as the typedLetter one time")]
          public void WhenIEnter4AsTheTypedLetterOneTime()
          {
              var letterTyped = driver.FindElement(By.Id("LetterTyped"));
              var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
              letterTyped.SendKeys("4");
              Thread.Sleep(5000);
              btnInsertLetter.SendKeys(Keys.Enter);
          }



          [Then(@"It should tell me that the letter is invalid")]
          public void ThenIShouldBeToldThatTheLetterIsInvalid()
          {
              Thread.Sleep(5000);
              var mensaje = driver.FindElement(By.ClassName("ui-pnotify-text"));
              Thread.Sleep(5000);
              var invalid = "Incorrecto" == mensaje.Text;
              Thread.Sleep(5000);
              Assert.IsTrue(invalid);
              Thread.Sleep(5000);
          } 

                  //Cuarto test - Arriesgar palabra correcta
          [Given(@"I have entered Teclado as the wordToGuess")]
          public void GivenIHaveEnteredTecladoAsTheWordToGuess()
          {
              driver.Navigate().GoToUrl(baseURL);

              Thread.Sleep(5000);

              var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
              txtPalabra.SendKeys("teclado");

              Thread.Sleep(5000);

              var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
              btnInsertWord.SendKeys(Keys.Enter);

              Thread.Sleep(5000);
          }

          [When(@"I enter Teclado as the typedLetter")]
          public void WhenIEnterTecladoAsTheTypedLette()
          {
              var letterTyped = driver.FindElement(By.Id("LetterTyped"));
              var btnRiskWord = driver.FindElement(By.Id("btnRiskWord"));
              letterTyped.SendKeys("teclado");
              Thread.Sleep(5000);
              btnRiskWord.SendKeys(Keys.Enter);
          }

          [Then(@"I should be told that I win")]
          public void ThenIShouldBeToldThatIWin()
          {
              Thread.Sleep(5000);
              var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
              var guessingWord = driver.FindElement(By.Id("GuessingWord"));
              //   var mensaje = driver.FindElement(By.ClassName("ui-pnotify-text"));
              var mensaje = driver.FindElement(By.CssSelector(".brighttheme-success .ui-pnotify-text"));

              var win = guessingWord.GetAttribute("value").Replace(" ", String.Empty) == txtPalabra.GetAttribute("value");
              var correctMesagge = "Ganaste. Felicitaciones." == mensaje.Text.Trim();
              Thread.Sleep(5000);
              Assert.IsTrue(win && correctMesagge);
              Thread.Sleep(5000);
          }


            //Quinto test - Insertar palabra secreta no alfabetica
            [Given(@"I have entered 123 as the wordToGuess")]
            public void GivenIhaveentered123asthewordToGuess()
            {
                driver.Navigate().GoToUrl(baseURL);

                Thread.Sleep(5000);

                var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
                txtPalabra.SendKeys("123");

                Thread.Sleep(5000);

                var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
                btnInsertWord.SendKeys(Keys.Enter);

                Thread.Sleep(5000);
            }

            [Then(@"It should tell me that the word is invalid")]
            public void ThenIShouldBeToldThatTheWordIsInvalid()
            {
                Thread.Sleep(5000);
                var mensaje = driver.FindElement(By.ClassName("ui-pnotify-text"));
                var invalid = "Palabra secreta invalida" == mensaje.Text;
                Console.WriteLine($"Mensaje mostrado: {mensaje.Text}");
                Thread.Sleep(5000);
                Assert.IsTrue(invalid);
                Thread.Sleep(5000);
            }

          //Sexto text - Dos veces la misma letra no descuenta vidas
          [Given(@"I have entered Sexto as the wordToGuess")]
          public void GivenIHaveEnteredSextoAsTheWordToGuess()
          {
              driver.Navigate().GoToUrl(baseURL);

              Thread.Sleep(5000);

              var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
              txtPalabra.SendKeys("Sexto");

              var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
              btnInsertWord.SendKeys(Keys.Enter);

              Thread.Sleep(5000);
          }

          [When(@"I enter X as the typedLetter one time and I enter X as the typedLetter again")]

          public void WhenIEnterXAsTheTypedLetterTwice()
          {
              var letterTyped = driver.FindElement(By.Id("LetterTyped"));
              var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));

              List<char> lettersRisked = ['x', 'x'];
              for (int i = 0; i < 2; i++)
              {
                  letterTyped.SendKeys(lettersRisked[i].ToString());
                  Thread.Sleep(5000);
                  btnInsertLetter.SendKeys(Keys.Enter);
                  Thread.Sleep(5000);
                  letterTyped.Clear(); // Limpiar el campo después de cada letra
                  Thread.Sleep(5000);
              }
          }

          [Then(@"The number of chances left should remain the same")]
          public void ThenTheNumberOfChancesLeftShouldRemainTheSame()
          {
              Thread.Sleep(5000);

              var chancesLeftBefore = driver.FindElement(By.Id("ChancesLeft")).GetAttribute("value");

              Thread.Sleep(5000);

              var chancesLeftAfter = driver.FindElement(By.Id("ChancesLeft")).GetAttribute("value");

              Assert.AreEqual(chancesLeftBefore, chancesLeftAfter, "The number of chances left should remain the same after guessing the same letter.");
          } */

        //Primer test - perder el juego
        [Given(@"I have entered Ahorcado as the wordToGuess")]
        public void GivenIHaveEnteredAhorcadoAsTheWordToGuess()
        {
            driver.Navigate().GoToUrl(baseURL);

            var txtPalabra = wait.Until(driver => driver.FindElement(By.Id("WordToGuess")));
            txtPalabra.SendKeys("Ahorcado");

            var btnInsertWord = wait.Until(driver => driver.FindElement(By.Id("btnInsertWord")));
            btnInsertWord.SendKeys(Keys.Enter);
        }

        [When(@"I enter X as the typedLetter five times")]
        public void WhenIEnterXAsTheTypedLetterFiveTimes()
        {
            var letterTyped = wait.Until(driver => driver.FindElement(By.Id("LetterTyped")));
            var btnInsertLetter = wait.Until(driver => driver.FindElement(By.Id("btnInsertLetter")));

            List<char> lettersRisked = new List<char> { 's', 't', 'w', 'z', 'y', 'k', 'v' };

            foreach (var letter in lettersRisked)
            {
                letterTyped.SendKeys(letter.ToString());
                btnInsertLetter.SendKeys(Keys.Enter);
                letterTyped.Clear(); // Limpiar el campo después de cada letra
            }
        }

        [Then(@"I should be told that I lost")]
        public void ThenIShouldBeToldThatILost()
        {
            var chancesLeft = wait.Until(driver => driver.FindElement(By.Id("ChancesLeft")));
            var loss = Convert.ToInt32(chancesLeft.GetAttribute("value")) == 0;
            Assert.IsTrue(loss, "The player should be informed that they lost after exhausting all chances.");
        }

        [AfterScenario]
        public void TestCleanUp()
        {
            //driver.Quit();
        }


        //Segundo test - acertar una letra
        [Given(@"I have entered Hola as the wordToGuess")]
        public void GivenIHaveEnteredHolaAsTheWordToGuess()
        {
            driver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(5000);

            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("Hola");

            Thread.Sleep(5000);

            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);

            Thread.Sleep(5000);
        }

        [When(@"I enter A as the typedLetter one time")]
        public void WhenIEnterAAsTheTypedLetterOneTime()
        {
            Thread.Sleep(5000);
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            chancesLeftAnt = Convert.ToInt32(chancesLeft.GetAttribute("value"));
            var letterTyped = driver.FindElement(By.Id("LetterTyped"));
            var btnInsertLetter = driver.FindElement(By.Id("btnInsertLetter"));
            letterTyped.SendKeys("A");
            Thread.Sleep(5000);
            btnInsertLetter.SendKeys(Keys.Enter);
        }

        [Then(@"I should be told that I hit the letter")]
        public void ThenIShouldBeToldThatIHitTheLetter()
        {
            Thread.Sleep(5000);
            var chancesLeft = driver.FindElement(By.Id("ChancesLeft"));
            Thread.Sleep(5000);
            var hit = Convert.ToInt32(chancesLeft.GetAttribute("value")) == chancesLeftAnt;
            Thread.Sleep(5000);
            Assert.IsTrue(hit);
            Thread.Sleep(5000);
        }


        //Tercer test - Insertar un numero
        [Given(@"I have entered Computadora as the wordToGuess")]
        public void GivenIHaveEnteredComputadoraAsTheWordToGuess()
        {
            driver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(5000);

            var txtPalabra = driver.FindElement(By.Id("WordToGuess"));
            txtPalabra.SendKeys("computadora");

            Thread.Sleep(5000);

            var btnInsertWord = driver.FindElement(By.Id("btnInsertWord"));
            btnInsertWord.SendKeys(Keys.Enter);

            Thread.Sleep(5000);
        }

        [When(@"I enter 4 as the typedLetter one time")]
        public void WhenIEnter4AsTheTypedLetterOneTime()
        {
            var letterTyped = wait.Until(driver => driver.FindElement(By.Id("LetterTyped")));
            letterTyped.SendKeys("4");

            var btnInsertLetter = wait.Until(driver => driver.FindElement(By.Id("btnInsertLetter")));
            btnInsertLetter.SendKeys(Keys.Enter);
        }



        [Then(@"It should tell me that the letter is invalid")]
        public void ThenIShouldBeToldThatTheLetterIsInvalid()
        {
            var mensaje = wait.Until(driver => driver.FindElement(By.ClassName("ui-pnotify-text")));
            var invalid = mensaje.Text.Contains("Incorrecto"); // Ajusta el mensaje según el texto esperado

            Assert.IsTrue(invalid);
        }

        //Cuarto test - Arriesgar palabra correcta
        [Given(@"I have entered Teclado as the wordToGuess")]
        public void GivenIHaveEnteredTecladoAsTheWordToGuess()
        {
            var txtPalabra = wait.Until(driver => driver.FindElement(By.Id("WordToGuess")));
            txtPalabra.SendKeys("teclado");

            var btnInsertWord = wait.Until(driver => driver.FindElement(By.Id("btnInsertWord")));
            btnInsertWord.SendKeys(Keys.Enter);
        }

        [When(@"I enter Teclado as the typedLetter")]
        public void WhenIEnterTecladoAsTheTypedLette()
        {
            var letterTyped = wait.Until(driver => driver.FindElement(By.Id("LetterTyped")));
            letterTyped.SendKeys("teclado");

            var btnRiskWord = wait.Until(driver => driver.FindElement(By.Id("btnRiskWord")));
            btnRiskWord.SendKeys(Keys.Enter);
        }

        [Then(@"I should be told that I win")]
        public void ThenIShouldBeToldThatIWin()
        {
            var txtPalabra = wait.Until(driver => driver.FindElement(By.Id("WordToGuess")));
            var guessingWord = wait.Until(driver => driver.FindElement(By.Id("GuessingWord")));
            var mensaje = wait.Until(driver => driver.FindElement(By.CssSelector(".brighttheme-success .ui-pnotify-text")));

            var win = guessingWord.GetAttribute("value").Replace(" ", String.Empty) == txtPalabra.GetAttribute("value");
            var correctMessage = "Ganaste. Felicitaciones." == mensaje.Text.Trim();

            Assert.IsTrue(win && correctMessage);
        }


        //Quinto test - Insertar palabra secreta no alfabetica
        [Given(@"I have entered 123 as the wordToGuess")]
        public void GivenIhaveentered123asthewordToGuess()
        {
            driver.Navigate().GoToUrl(baseURL);

            var txtPalabra = wait.Until(driver => driver.FindElement(By.Id("WordToGuess")));
            txtPalabra.SendKeys("123");

            var btnInsertWord = wait.Until(driver => driver.FindElement(By.Id("btnInsertWord")));
            btnInsertWord.SendKeys(Keys.Enter);
        }

        [Then(@"It should tell me that the word is invalid")]
        public void ThenIShouldBeToldThatTheWordIsInvalid()
        {
            var mensaje = wait.Until(driver => driver.FindElement(By.ClassName("ui-pnotify-text")));
            var invalid = "Palabra secreta invalida" == mensaje.Text;

            Console.WriteLine($"Mensaje mostrado: {mensaje.Text}");

            Assert.IsTrue(invalid);
        }

        //Sexto text - Dos veces la misma letra no descuenta vidas
        [Given(@"I have entered Sexto as the wordToGuess")]
        public void GivenIHaveEnteredSextoAsTheWordToGuess()
        {
            driver.Navigate().GoToUrl(baseURL);

            var txtPalabra = wait.Until(driver => driver.FindElement(By.Id("WordToGuess")));
            txtPalabra.SendKeys("Sexto");

            var btnInsertWord = wait.Until(driver => driver.FindElement(By.Id("btnInsertWord")));
            btnInsertWord.SendKeys(Keys.Enter);
        }

        [When(@"I enter X as the typedLetter one time and I enter X as the typedLetter again")]

        public void WhenIEnterXAsTheTypedLetterTwice()
        {
            var letterTyped = wait.Until(driver => driver.FindElement(By.Id("LetterTyped")));
            var btnInsertLetter = wait.Until(driver => driver.FindElement(By.Id("btnInsertLetter")));

            List<char> lettersRisked = new List<char> { 'x', 'x' };

            foreach (var letter in lettersRisked)
            {
                letterTyped.SendKeys(letter.ToString());
                btnInsertLetter.SendKeys(Keys.Enter);

                letterTyped.Clear(); // Limpiar el campo después de cada letra
            }
        }

        [Then(@"The number of chances left should remain the same")]
        public void ThenTheNumberOfChancesLeftShouldRemainTheSame()
        {
            var chancesLeftBefore = wait.Until(driver => driver.FindElement(By.Id("ChancesLeft"))).GetAttribute("value");

            WhenIEnterXAsTheTypedLetterTwice();

            var chancesLeftAfter = wait.Until(driver => driver.FindElement(By.Id("ChancesLeft"))).GetAttribute("value");

            Assert.AreEqual(chancesLeftBefore, chancesLeftAfter);
        }


    }
}
