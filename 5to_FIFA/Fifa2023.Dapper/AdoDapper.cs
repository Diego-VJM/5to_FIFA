using Dapper;
using MySqlConnector;
using Fifa2023.Core;
using System.Data;

namespace Fifa2023.Dapper;

public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;

    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);


    #region Futbolistas
    private static readonly string _queryFutbolistas
    = @"SELECT * FROM Futbolistas";
    private static readonly string _queryFutbolistasporID 
    = @"CALL mostrarfutbolistas(@unidFutbolista);";
    private static readonly string _queryAltaFutbolistas
    = @"INSERT INTO Futbolistas (idFutbolista, Nombre, Apellido, nacimiento, Velocidad, Remate, Pase, Defensa, idPosicion) 
                    VALUES (@IdFutbolista, @Nombre, @Apellido, @nacimiento, @Velocidad, @Remate, @Pase, @Defensa, @IdPosicion)";
    public void AltaFutbolistas(Futbolistas futbolistas)
        => _conexion.Execute(
                _queryAltaFutbolistas,
                new
                {
                    idFutbolista = futbolistas.idFutbolista,
                    idPosicion = futbolistas.idPosicion,
                    Nombre = futbolistas.Nombre,
                    Apellido = futbolistas.Apellido,
                    nacimiento = futbolistas.nacimiento,
                    Velocidad = futbolistas.Velocidad,
                    Remate = futbolistas.Remate,
                    Pase = futbolistas.Pase,
                    Defensa = futbolistas.Defensa
                }
            );
    public Futbolistas ObtenerFutbolistas(ushort idFutbolista)
        => _conexion.QueryFirstOrDefault<Futbolistas>(_queryFutbolistasporID, new { unidFutbolista = idFutbolista });

    public List<Futbolistas> ObtenerFutbolistas()
        => _conexion.Query<Futbolistas>(_queryFutbolistas).ToList();
    #endregion

    #region Habilidad
    private static readonly string _queryHabilidad
    = @"SELECT * FROM Habilidad";
    private static readonly string _queryHabilidadporID 
    = @"SELECT * FROM Habilidad WHERE IdHabilidad = @unIdHabilidad";
    private static readonly string _queryAltaHabilidad
    = @"INSERT INTO Habilidad (idHabilidad, nombre, descripcion) 
                        VALUES (@IdHabilidad, @Nombre, @Descripcion)";
    public void AltaHabilidad(Habilidad Habilidad)
        => _conexion.Execute(
                _queryAltaHabilidad,
                new
                {
                    idHabilidad = Habilidad.idHabilidad,
                    Nombre = Habilidad.Nombre,
                    Descripcion = Habilidad.Descripcion
                }
            );

    public Habilidad ObtenerHabilidad(byte idHabilidad)
        => _conexion.QueryFirstOrDefault<Habilidad>(_queryHabilidadporID, new { unIdHabilidad = idHabilidad });

    public List<Habilidad> ObtenerHabilidad()
        => _conexion.Query<Habilidad>(_queryHabilidad).ToList();

#endregion
    
    #region Jugadores
    private static readonly string _queryJugadores
    = @"SELECT * FROM Jugadores";
    private static readonly string _queryJugadoresporID 
    = @"SELECT * FROM Jugadores WHERE idJugador = @unIdJugador";
    private static readonly string _queryAltaJugadores
    = @"INSERT INTO Jugadores (idJugador, usuario, nombre, apellido, contrasena, monedas)
                    VALUES (@IdJugador, @Usuario, @Nombre, @Apellido, @Contrasena, @Monedas)";
    public void AltaJugadores(Jugadores jugadores)
        => _conexion.Execute(
                _queryAltaJugadores,
                new
                {
                    idJugador = jugadores.idJugador,
                    Usuario = jugadores.Usuario,
                    Nombre = jugadores.Nombre,
                    Apellido = jugadores.Apellido,
                    Contrasena = jugadores.Contrasena,
                    Monedas = jugadores.Monedas
                }
            );

    public Jugadores ObtenerJugadores(ushort idJugador)
        => _conexion.QueryFirstOrDefault<Jugadores>(_queryJugadoresporID, new { unIdJugador = idJugador });


    public List<Jugadores> ObtenerJugadores()
        => _conexion.Query<Jugadores>(_queryJugadores).ToList();

    #endregion

    #region Posesion
    private static readonly string _queryPosesion
    = @"SELECT * FROM Posesion";
    private static readonly string _queryPosesionporID 
    = @"SELECT * FROM Posesion WHERE IdJugador = @unIdJugador and idFutbolista = @unIdFutbolista";
    private static readonly string _queryAltaPosesion
    = @"INSERT INTO Posesion VALUES (@IdFutbolista, @IdJugador)";
    public void AltaPosesion(Posesion posesion)
        => _conexion.Execute(
                _queryAltaPosesion,
                new
                {
                    idFutbolista = posesion.idFutbolista,
                    idJugador = posesion.idJugador
                }
            );

    public Posesion ObtenerPosesion(ushort idJugador, ushort idFutbolista)
        => _conexion.QueryFirstOrDefault<Posesion>(_queryPosesionporID, new { unIdJugador = idJugador, unIdFutbolista = idFutbolista });


    public List<Posesion> ObtenerPosesion()
        => _conexion.Query<Posesion>(_queryPosesion).ToList();

    #endregion

    #region PosesionHabilidad
        private static readonly string _queryPosesionHabilidad
    = @"SELECT * FROM PosesionHabilidad";
    private static readonly string _queryPosesionHabilidadporID 
    = @"SELECT * FROM PosesionHabilidad WHERE IdFutbolista = @unIdFutbolista";
    private static readonly string _queryAltaPosesionHabilidad
    = @"INSERT INTO PosesionHabilidad VALUES (@IdFutbolista, @IdHabilidad)";
    public void AltaPosesionHabilidad(PosesionHabilidad posesionHabilidad)
        => _conexion.Execute(
                _queryAltaPosesionHabilidad,
                new
                {
                    idFutbolista = posesionHabilidad.idFutbolista,
                    idHabilidad = posesionHabilidad.idHabilidad
                }
            );
    public PosesionHabilidad ObtenerPosesionHabilidad(ushort idFutbolista)
        => _conexion.QueryFirstOrDefault<PosesionHabilidad>(_queryPosesionHabilidadporID, new {unIdFutbolista = idFutbolista});


    public List<PosesionHabilidad> ObtenerPosesionHabilidad()
        => _conexion.Query<PosesionHabilidad>(_queryPosesionHabilidad).ToList();


    #endregion

    #region Posicion
    private static readonly string _queryPosicion
    = @"SELECT * FROM Posicion";
    private static readonly string _queryPosicionporID 
    = @"SELECT * FROM Posicion WHERE idPosicion = @unidPosicion";
    private static readonly string _queryAltaPosicion
    = @"INSERT INTO Posicion (idPosicion, Posicion)
                        VALUES (@IdPosicion, @Posicion)";
    public void AltaPosicion(Posicion Posicion)
        => _conexion.Execute(
                _queryAltaPosicion,
                new
                {
                    idPosicion = Posicion.idPosicion,
                    Posicion = Posicion.posicion
                }
            );

    public Posicion ObtenerPosicion(byte idPosicion)
        => _conexion.QueryFirstOrDefault<Posicion>(_queryPosicionporID, new {unIdPosicion = idPosicion});


    public List<Posicion> ObtenerPosicion()
        => _conexion.Query<Posicion>(_queryPosicion).ToList();

    #endregion

    #region Transferencias
    private static readonly string _queryTransferencias
    = @"SELECT * FROM Transferencias";
    private static readonly string _queryTransferenciasporID
    = @"SELECT * FROM Transferencias WHERE IdTransferencia = @unIdTransferencia";
    private static readonly string _queryAltaTransferencias
    = @"INSERT INTO Transferencias (idTransferencia, fecha, precio, idVendedor, idComprador, idFutbolista, Transferencia_exitosa)
                        VALUES (@IdTransferencia, @Fecha , @Precio, @IdVendedor, @IdComprador, @IdFutbolista, @Transferencia_exitosa)";
    public void AltaTransferencias(Transferencias transferencias)
        => _conexion.Execute(
                _queryAltaTransferencias,
                new
                {
                    idTransferencia = transferencias.idTransferencia,
                    idVendedor = transferencias.idVendedor,
                    idComprador = transferencias.idComprador,
                    idFutbolista = transferencias.idFutbolista,
                    Fecha = transferencias.Fecha,
                    Precio = transferencias.Precio,
                    Transferencia_exitosa = transferencias.Transferencia_exitosa
                }
            );

    public Transferencias ObtenerTransferencias(byte idTransferencia)
        => _conexion.QueryFirstOrDefault<Transferencias>(_queryTransferenciasporID, new {unIdTransferencia = idTransferencia});


    public List<Transferencias> ObtenerTransferencias()
        => _conexion.Query<Transferencias>(_queryTransferencias).ToList();



    #endregion

}