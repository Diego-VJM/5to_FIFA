using Fifa2023.Core;
namespace Fifa2023.Test;

public class TestAdoFutbolistas : TestAdo
{
    [Theory]
    [InlineData(1)]
    public void TraerFutbolista(ushort idFutbolista)
    {
        var futbolista = Ado.ObtenerFutbolistas(idFutbolista);

        Assert.NotNull(futbolista);
    }

    [Fact]
    public void TraerFutbolistas()
    {
        var futbolista = Ado.ObtenerFutbolistas();

        Assert.NotEmpty(futbolista);
    }
    
    [Fact]
    public void AltaFutbolistas()
    {
        ushort idFutbolista = 2;
        string nombre = "Nicolas";
        string apellido = "Otamendi";
        DateOnly fecha = new DateOnly(2002, 1, 13);
        string nacimiento = fecha.ToString("yyyy-MM-dd");
        byte Velocidad = 75;
        byte Remate = 70;
        byte Pase = 75;
        byte Defensa =90;
        byte idPosicion = 1;

        var futbolista = Ado.ObtenerFutbolistas(idFutbolista);

        Assert.Null(futbolista);

        var nuevofutbolista = new Futbolistas()
        {
            idFutbolista = idFutbolista,
            Nombre = nombre,
            Apellido = apellido,
            Velocidad = Velocidad,
            nacimiento = nacimiento,
            Remate = Remate,
            Pase = Pase,
            Defensa = Defensa,
            idPosicion = idPosicion,
            
        };

        Ado.AltaFutbolistas(nuevofutbolista);

        futbolista = Ado.ObtenerFutbolistas(idFutbolista);


        Assert.NotNull(futbolista);
        Assert.Equal(futbolista.idFutbolista, nuevofutbolista.idFutbolista);
    }
}
