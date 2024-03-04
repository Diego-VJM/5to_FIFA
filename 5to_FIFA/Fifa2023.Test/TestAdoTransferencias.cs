using Fifa2023.Core;

namespace Fifa2023.Test;
public class TestAdoTransferencias : TestAdo
{
    [Theory]
    [InlineData(1)]
    public void TraerTransferencias(byte idTransferencia)
    {
        var transferencia = Ado.ObtenerTransferencias(idTransferencia);

        Assert.NotNull(transferencia);
    }

    [Fact]
    public void TraerTransferencia()
    {
        var transferencia = Ado.ObtenerTransferencias();

        Assert.NotEmpty(transferencia);
    }
    [Fact]
    public void AltaTransferencias()
    {
        byte idTransferencia = 2;
        uint idVendedor = 1;
        uint idComprador = 2;
        ushort idFutbolista = 1;
        DateTime fecha = DateTime.Now;
        string fechaFormateada = fecha.ToString("yyyy-MM-dd HH:mm:ss");
        uint precio = 10;
        bool transferencia_exitosa = false;

        var transferencia = Ado.ObtenerTransferencias(idTransferencia);

        Assert.Null(transferencia);

        var nuevatransferencias = new Transferencias()
        {
            idTransferencia = idTransferencia,
            idVendedor = idVendedor,
            idComprador = idComprador,
            idFutbolista = idFutbolista,
            Fecha = fechaFormateada,
            Precio = precio,
            Transferencia_exitosa = transferencia_exitosa,
        };

        Ado.AltaTransferencias(nuevatransferencias);  

        transferencia = Ado.ObtenerTransferencias(idTransferencia);


        Assert.NotNull(transferencia);
        Assert.Equal(nuevatransferencias.idTransferencia, transferencia.idTransferencia);
    }
}