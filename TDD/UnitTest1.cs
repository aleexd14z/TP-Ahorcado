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
            bool resultado = juego.ArriesgarPalabra("palabra#12");
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
    }
}