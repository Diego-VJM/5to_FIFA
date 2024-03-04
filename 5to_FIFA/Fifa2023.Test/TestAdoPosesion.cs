using Fifa2023.Core;

namespace Fifa2023.Test;
public class TestAdoPosesion : TestAdo
{
    [Theory]
    [InlineData(3, 1)]
    public void Traerposesion(ushort idJugador, ushort idFutbolista)
    {
        var posesion = Ado.ObtenerPosesion(idJugador, idFutbolista);

        Assert.NotNull(posesion);
    }

    [Fact]
    public void TraerPosesion()
    {
        var posesion = Ado.ObtenerPosesion();

        Assert.NotEmpty(posesion);
    }
    [Fact]
    public void AltaPosesion()
    {
        ushort idFutbolista = 100;
        ushort idJugador = 1; 

        var posesion = Ado.ObtenerPosesion(idJugador, idFutbolista);

        Assert.Null(posesion);

        var nuevaposesion = new Posesion()
        {
            idJugador = idJugador,
            idFutbolista = idFutbolista,
        };

        Ado.AltaPosesion(nuevaposesion); 

        posesion = Ado.ObtenerPosesion(idJugador, idFutbolista);

        Assert.NotNull(posesion);
        Assert.Equal(nuevaposesion.idFutbolista, posesion.idFutbolista);
        Assert.Equal(nuevaposesion.idJugador, posesion.idJugador);
    }
}