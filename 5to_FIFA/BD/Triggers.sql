
USE 5to_FIFA;
DELIMITER $$
DROP TRIGGER IF EXISTS befInsTransferencias$$
CREATE TRIGGER befInsTransferencias BEFORE UPDATE ON Transferencias
FOR EACH ROW
BEGIN
    DECLARE Cantidad INT;
	DECLARE monedas_comprador INT;
	DECLARE idJugador_existente INT;
    
	SELECT Monedas INTO monedas_comprador
	FROM Jugadores
	WHERE idJugador = NEW.idComprador;
    
	IF (monedas_comprador < NEW.Precio) THEN
	SIGNAL SQLSTATE '45000'
	SET MESSAGE_TEXT = 'Monedas insuficientes';
	END IF;
    
    SELECT COUNT(*) INTO Cantidad
    FROM Posesion
    WHERE idJugador = NEW.idVendedor
    AND idFutbolista = NEW.idFutbolista;
    
    IF (Cantidad = 0) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El jugador no posee al futbolista';
        ELSE IF (Cantidad > 0) THEN
			UPDATE Posesion
            SET idJugador = NEW.idComprador
			WHERE idJugador = NEW.idVendedor
			AND idFutbolista = NEW.idFutbolista;
			
            update Jugadores
			set monedas = monedas - NEW.Precio
			WHere idJugador = NEW.idComprador;
		END IF;
    END IF;
END $$
