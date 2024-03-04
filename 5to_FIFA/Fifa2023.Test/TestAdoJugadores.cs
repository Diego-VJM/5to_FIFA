using Fifa2023.Core;

namespace Fifa2023.Test;
public class TestAdoJugadores : TestAdo
{
    [Theory]
    [InlineData(1)]
    public void TraerJugadores(ushort idJugador)
    {
        var jugador = Ado.ObtenerJugadores(idJugador);

        Assert.NotNull(jugador);
    }

    [Fact]
    public void TraerJugador()
    {
        var jugador = Ado.ObtenerJugadores();

        Assert.NotEmpty(jugador);
    }
    [Fact]
    public void AltaJugadores()
    {
        ushort idJugador = 2;
        string usuario = "Jorge el curioso";
        string nombre = "Jorge";
        string apellido = "Copa";
        string contrasena = "12345678";
        ushort monedas = 5000; 

        var jugador = Ado.ObtenerJugadores(idJugador);

        Assert.Null(jugador);

        var nuevojugador = new Jugadores()
        {
            idJugador = idJugador,
            Usuario = usuario,
            Nombre = nombre,
            Apellido = apellido,
            Contrasena = contrasena,
            Monedas = monedas
        };

        Ado.AltaJugadores(nuevojugador); 

        jugador = Ado.ObtenerJugadores(idJugador);
        
        Assert.NotNull(jugador);
        Assert.Equal(jugador.idJugador, nuevojugador.idJugador);
    }
}
