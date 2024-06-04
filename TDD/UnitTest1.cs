namespace TDD
{
    public class AhorcadoTests
    {
        [Fact]
        public void AdivinarPalabraDentroDe7Intentos()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            var resultado = juego.ArriesgarPalabra("palabra");
            Assert.True(resultado);
        }

        [Fact]
        public void ErrarPalabraDentroDe7Intentos()
        {
            var juego = new TP_Ahorcado.Ahorcado("palabra");
            var resultado = juego.ArriesgarPalabra("palabras");
            Assert.True(resultado);
        }
    }
}