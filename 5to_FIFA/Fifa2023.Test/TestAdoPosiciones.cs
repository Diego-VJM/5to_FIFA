using Fifa2023.Core;

namespace Fifa2023.Test;
public class TestAdoPosicion : TestAdo
{
    [Theory]
    [InlineData(1)]
    public void TraerPosicionPorID(byte idPosicion)
    {
        var posicion = Ado.ObtenerPosicion(idPosicion);

        Assert.NotNull(posicion);
    }

    [Fact]
    public void TraerPosicion()
    {
        var posicion = Ado.ObtenerPosicion();

        Assert.NotEmpty(posicion);
    }
    [Fact]
    public void AltaPosicion()
    {
        byte idPosicion = 7;
        string Posicion = "defensa";


        var posicion = Ado.ObtenerPosicion(idPosicion);

        Assert.Null(posicion);

        var nuevaposicion = new Posicion()
        {
            idPosicion = idPosicion,
            posicion = Posicion,
        };

        Ado.AltaPosicion(nuevaposicion);    

        posicion = Ado.ObtenerPosicion(idPosicion);

        Assert.NotNull(posicion);
         Assert.Equal(posicion.idPosicion, nuevaposicion.idPosicion);
    }
}
