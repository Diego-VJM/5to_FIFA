namespace Fifa2023.Core;
public interface IAdo
{
    
    void AltaFutbolistas(Futbolistas futbolistas);
    public Futbolistas ObtenerFutbolistas(ushort idFutbolista);
    public List<Futbolistas> ObtenerFutbolistas();
    
    void AltaHabilidad(Habilidad Habilidad);
    public Habilidad ObtenerHabilidad(byte idHabilidad);
    public List<Habilidad> ObtenerHabilidad();

    void AltaJugadores(Jugadores jugadores);
    public Jugadores ObtenerJugadores(ushort idJugador);
    public List<Jugadores> ObtenerJugadores();

    void AltaPosesion(Posesion posesion);
    public Posesion ObtenerPosesion(ushort idJugador,ushort idFutbolista);
    public List<Posesion> ObtenerPosesion();

    void AltaPosesionHabilidad(PosesionHabilidad posesionHabilidad);
    public PosesionHabilidad ObtenerPosesionHabilidad(ushort idFutbolista);

    public List<PosesionHabilidad> ObtenerPosesionHabilidad();
    
    void AltaPosicion(Posicion Posicion);
    public Posicion ObtenerPosicion(byte idPosicion);
    public List<Posicion> ObtenerPosicion();
    
    void AltaTransferencias(Transferencias transferencias);
    public Transferencias ObtenerTransferencias(byte idTransferencia);
    public List<Transferencias> ObtenerTransferencias();

}
