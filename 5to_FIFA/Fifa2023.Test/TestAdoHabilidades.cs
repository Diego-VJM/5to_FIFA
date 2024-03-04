using Fifa2023.Core;

namespace Fifa2023.Test;
public class TestAdoHabilidad : TestAdo
{
    [Theory]
    [InlineData(1)]
    public void TraerHabilidadPorID(byte idHabilidad)
    {
        var habilidad = Ado.ObtenerHabilidad(idHabilidad);

        Assert.NotNull(habilidad);
    }

    [Fact]
    public void TraerHabilidad()
    {
        var habilidad = Ado.ObtenerHabilidad();

        Assert.NotEmpty(habilidad);
    }
    [Fact]
    public void AltaHabilidad()
    {
        byte idHabilidad = 2;
        string nombre = "Calidad";
        string descripcion = "Le pega godeitor";

        var habilidad = Ado.ObtenerHabilidad(idHabilidad);

        Assert.Null(habilidad);

        var nuevohabilidad = new Habilidad()
        {
            idHabilidad = idHabilidad,
            Nombre = nombre,
            Descripcion = descripcion
        };

        Ado.AltaHabilidad(nuevohabilidad);

        habilidad = Ado.ObtenerHabilidad(idHabilidad);


        Assert.NotNull(habilidad);
        Assert.Equal(habilidad.idHabilidad, nuevohabilidad.idHabilidad);
    //verifica si la operación de inserción y recuperación de una habilidad funciona correctamente. Si la habilidad se inserta correctamente y se puede recuperar de manera adecuada, y si el idHabilidad de la habilidad recuperada coincide con el idHabilidad de la habilidad insertada, entonces las aserciones pasarán y la prueba se considerará exitosa.
    }
}
