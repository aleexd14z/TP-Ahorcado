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
        public void ErrarPalabra()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            var resultado = juego.ArriesgarPalabra("palabras");
            Assert.False(resultado);
        }

        [Fact]
        public void ErrarPalabraYPerder()
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
    }
}