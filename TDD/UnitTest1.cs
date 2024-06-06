using TP_Ahorcado;

namespace TDD   
{
    public class AhorcadoTests
    {
        [Fact]
        public void AdivinarPalabra()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            var resultado = juego.ArriesgarPalabra("palabra");
            Assert.True(resultado);
        }

        [Fact]
        public void AdivinarPalabraCaseSensitive()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            var resultado = juego.ArriesgarPalabra("PALABRA");
            Assert.True(resultado);
        }

        [Fact]
        public void NoIngresarPalabraNoPerderIntentos()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            int intentosAntes = juego.IntentosRestantes;
            bool resultado = juego.ArriesgarPalabra("");
            int intentosDespues = juego.IntentosRestantes;
            Assert.False(resultado);
            Assert.Equal(intentosAntes, intentosDespues);
        }

        [Fact]
        public void PalabraConEspaciosNoPerderIntentos()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            int intentosAntes = juego.IntentosRestantes;
            bool resultado = juego.ArriesgarPalabra("dos palabras");
            int intentosDespues = juego.IntentosRestantes;
            Assert.False(resultado);
            Assert.Equal(intentosAntes, intentosDespues);
        }

        [Fact]
        public void CaracterInvalidoNoPerderIntentos()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            int intentosAntes = juego.IntentosRestantes;
            bool resultado = juego.ArriesgarPalabra("palabra#");
            int intentosDespues = juego.IntentosRestantes;
            Assert.False(resultado);
            Assert.Equal(intentosAntes, intentosDespues);
        }

        [Fact]
        public void CaracterNumericoNoPerderIntentos()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            int intentosAntes = juego.IntentosRestantes;
            bool resultado = juego.ArriesgarPalabra("palabra1");
            int intentosDespues = juego.IntentosRestantes;
            Assert.False(resultado);
            Assert.Equal(intentosAntes, intentosDespues);
        }

        [Fact]
        public void ErrarPalabra()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            var resultado = juego.ArriesgarPalabra("palabras");
            Assert.False(resultado);
        }

        [Fact]
        public void ErrarPalabraYPerderUnaVida()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            int intentosAntes = juego.IntentosRestantes;
            juego.ArriesgarPalabra("palabras");
            int intentosDespues = juego.IntentosRestantes;
            Assert.Equal(7, intentosAntes);
            Assert.Equal(6, intentosDespues);
        }

        [Fact]
        public void ErrarPalabraYPerderPartida()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            for (int i = 0; i < 6; i++)
            {
                juego.ArriesgarPalabra("palabras");
            }
            var resultado = juego.ArriesgarPalabra("palabras");
            Assert.False(resultado);
            Assert.True(juego.HaPerdido());
        }

        [Fact]
        public void ArriesgarLetraValida()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            bool resultado = juego.ArriesgarLetra('p');
            Assert.True(resultado);
        }

        [Fact]
        public void ArriesgarNumero()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            bool resultado = juego.ArriesgarLetra('1');
            Assert.False(resultado);
        }

        [Fact]
        public void ArriesgarCaracter()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            bool resultado = juego.ArriesgarLetra('#');
            Assert.False(resultado);
        }

        [Fact]
        public void ArriesgarCaracterCaseSensitive()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            bool resultado = juego.ArriesgarLetra('A');
            Assert.True(resultado);
        }

        [Fact]
        public void ArriesgarEspacioEnBlanco()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            bool resultado = juego.ArriesgarLetra(' ');
            Assert.False(resultado);
        }

        [Fact]
        public void ArriesgarLetraIncorrecta()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            bool resultado = juego.ArriesgarLetra('x');
            Assert.False(resultado);
        }

        [Fact]
        public void ArriesgarLetraIncorrectaYPerderIntento()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            int intentosAntes = juego.IntentosRestantes;
            bool resultado = juego.ArriesgarLetra('x');
            int intentosDespues = juego.IntentosRestantes;
            Assert.False(resultado);
            Assert.Equal(7, intentosAntes);
            Assert.Equal(6, intentosDespues);
        }

        [Fact]
        public void ArriesgarLetraYPederPartida()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            for (int i = 0; i < 6; i++)
            {
                juego.ArriesgarLetra('x');
            }
            var resultado = juego.ArriesgarLetra('x');
            Assert.False(resultado);
            Assert.True(juego.HaPerdido());
        }

        [Fact]
        public void ValidarEstadoLetra()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            juego.ArriesgarLetra('a');
            Assert.Equal("_a_a__a", juego.MostrarEstado());
        }

        [Fact]
        public void ErrarEstadoLetra()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            juego.ArriesgarLetra('a');
            Assert.NotEqual("a__a__a", juego.MostrarEstado());
        }

        [Fact]
        public void DevuelvePosicioLetraCorrecta()
        {
            var juego = new Ahorcado("palabra");
            var posiciones = juego.ObtenerPosicionesLetra('p');
            Assert.Equal(new List<int> { 0 }, posiciones);
        }

        [Fact]
        public void DevuelvePosicionesLetrasCorrectas()
        {
            var juego = new Ahorcado("palabra");
            var posiciones = juego.ObtenerPosicionesLetra('a');
            Assert.Equal(new List<int> { 1, 3, 6 }, posiciones);
        }

        [Fact]
        public void DevuelveLetraIncorrecta()
        {
            var juego = new Ahorcado("palabra");
            juego.ArriesgarLetra('e');
            char letraIncorrecta = 'e';
            Assert.Contains(letraIncorrecta, juego.LetrasIncorrectas);
        }

        [Fact]
        public void DevuelveLetrasIncorrectas()
        {
            var juego = new Ahorcado("palabra");
            juego.ArriesgarLetra('x');
            juego.ArriesgarLetra('m');
            juego.ArriesgarLetra('z');

            char[] letrasIncorrectas = { 'x', 'm', 'z' };
            foreach (char letra in letrasIncorrectas)
            {
                Assert.Contains(letra, juego.LetrasIncorrectas);
            }
        }

        [Fact]
        public void DevuelveLetraCorrecta()
        {
            var juego = new Ahorcado("palabra");
            juego.ArriesgarLetra('p');
            char letraCorrecta = 'p';
            Assert.Contains(letraCorrecta, juego.LetrasCorrectas());
        }

        [Fact]
        public void DevuelveLetrasCorrectas()
        {
            var juego = new Ahorcado("palabra");
            juego.ArriesgarLetra('p');
            juego.ArriesgarLetra('a');
            juego.ArriesgarLetra('l');

            char[] letrasCorrectas = { 'p', 'a', 'l' };
            foreach (char letra in letrasCorrectas)
            {
                Assert.Contains(letra, juego.LetrasCorrectas());
            }
        }
    }
}