using Fifa2023.Core;

namespace Fifa2023.Test;
public class TestAdoPosesionHabilidad : TestAdo
{
    [Theory]
    [InlineData(1)]
    public void TraerPosesionHabilidad(ushort idFutbolista)
    {
        
        var posesionhabilidad = Ado.ObtenerPosesionHabilidad(idFutbolista);

        Assert.NotNull(posesionhabilidad);
    }

    [Fact]
    public void TraerposesionHabilidad()
    {
        var posesionhabilidad = Ado.ObtenerPosesionHabilidad();

        Assert.NotEmpty(posesionhabilidad);
    }
    [Fact]
    public void AltaPosesionHabilidad()
    {
        ushort idFutbolista = 100;
        byte idHabilidad = 100;

        var posesionhabilidad = Ado.ObtenerPosesionHabilidad(idFutbolista);

        Assert.Null(posesionhabilidad);

        var nuevaposesionH = new PosesionHabilidad()
        {
            idFutbolista = idFutbolista,
            idHabilidad = idHabilidad
        };

        Ado.AltaPosesionHabilidad(nuevaposesionH);

        posesionhabilidad = Ado.ObtenerPosesionHabilidad(idFutbolista);


        Assert.NotNull(posesionhabilidad);
        Assert.Equal(nuevaposesionH.idFutbolista, posesionhabilidad.idFutbolista);
    }
}
