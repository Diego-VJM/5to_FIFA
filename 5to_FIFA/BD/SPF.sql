

USE 5to_FIFA;
delimiter $$

drop procedure if exists mostrarfutbolistas $$
create procedure mostrarfutbolistas (unidFutbolista SMALLINT UNSIGNED)
begin
	SELECT idFutbolista, nombre, apellido, nacimiento, velocidad, remate, pase, defensa, p.idPosicion, Posicion 
    FROM futbolistas f
	inner join Posicion p on p.idPosicion = f.idPosicion
    where idFutbolista = unidFutbolista;
end $$


delimiter $$
DROP PROCEDURE IF EXISTS AltaJugadores $$
CREATE PROCEDURE AltaJugadores (unidJugador SMALLINT UNSIGNED, unUsuario VARCHAR(45), 
								unNombre VARCHAR(45), unApellido VARCHAR(45), 
                                unaContrasena VARCHAR(45), Monedas MEDIUMINT UNSIGNED)
BEGIN

INSERT INTO Jugadores (idJugador, usuario, Nombre, Apellido, Contrasena, Monedas)
	VALUES		(unidJugador, unUsuario, unNombre, unApellido, unaContrasena, Monedas);
		
END $$

delimiter $$
DROP PROCEDURE IF EXISTS AltaHabilidad $$
CREATE PROCEDURE AltaHabilidad (unidHabilidad TINYINT UNSIGNED, Nombre VARCHAR(45), Descripcion VARCHAR(45) )
begin

INSERT INTO Habilidad (idHabilidad, Nombre, Descripcion)
VALUES (unidHabilidad, Nombre, Descripcion);

END $$

delimiter $$
DROP PROCEDURE IF EXISTS AltaPosicion $$
CREATE PROCEDURE AltaPosicion  (unidPosicion tinyint,unaPosicion varchar(45))
BEGIN

INSERT INTO Posicion (idPosicion,Posicion)
   	 VALUES    (unidPosicion,unaPosicion);
END $$

delimiter $$
DROP PROCEDURE IF EXISTS AltaPosesion$$
CREATE PROCEDURE AltaPosesion (unidFutbolista TINYINT UNSIGNED, unidJugador SMALLINT UNSIGNED)
BEGIN

INSERT INTO Posesion (idFutbolista, idJugador)
   	 VALUES    (unidFutbolista, unidJugador);
END $$

delimiter $$
DROP PROCEDURE IF EXISTS AltaPosesionHabilidad $$
CREATE PROCEDURE AltaPosesionHabilidad (unidFutbolista TINYINT UNSIGNED, unidHabilidad TINYINT UNSIGNED)
BEGIN

INSERT INTO PosesionHabilidad (idFutbolista, idHabilidad)
   	 VALUES    (unidFutbolista, unidHabilidad);
END $$

delimiter $$
DROP PROCEDURE IF EXISTS AltaFutbolista $$
CREATE PROCEDURE AltaFutbolista( unidFutbolista TINYINT UNSIGNED, unNombre VARCHAR(45), unApellido VARCHAR(45), unnacimiento DATE, unVelocidad TINYINT UNSIGNED , unRemate TINYINT UNSIGNED, unPase TINYINT UNSIGNED, unDefensa TINYINT UNSIGNED, unidPosicion TINYINT UNSIGNED )
BEGIN
	
INSERT INTO Futbolistas (idFutbolista, Nombre, Apellido, nacimiento, Velocidad, Remate, Pase, Defensa, idPosicion)
VALUES (unidFutbolista, unNombre, unApellido, unnacimiento , unVelocidad , unRemate, unPase, unDefensa, unidPosicion);
END $$


delimiter $$

DROP PROCEDURE IF EXISTS Publicar $$
CREATE PROCEDURE Publicar (unidVendedor SMALLINT UNSIGNED, unidFutbolista TINYINT UNSIGNED, unPrecio MEDIUMINT UNSIGNED)
BEGIN

INSERT INTO Transferencias (Fecha, Precio, idVendedor, idComprador, idFutbolista, Transferencia_exitosa)
					VALUES(NULL, unPrecio, unidVendedor, NULL, unidFutbolista, false);

END $$

delimiter $$
DROP PROCEDURE IF EXISTS Comprar $$
CREATE PROCEDURE Comprar (unidTransferencia SMALLINT UNSIGNED, unidComprador MEDIUMINT UNSIGNED)
BEGIN

update Transferencias
SET idComprador = unidComprador, Fecha = now(), Transferencia_exitosa = True
where idTransferencia = unidTransferencia;
END $$


delimiter $$
DROP PROCEDURE IF EXISTS transferenciasActivas $$
CREATE PROCEDURE transferenciasActivas (UnidFutbolista TINYINT UNSIGNED)

BEGIN

SELECT COUNT(Transferencia_exitosa) 'TransferenciaActiva'
FROM Transferencias
WHERE Transferencia_exitosa = FALSE
ORDER BY fecha ASC; 

END $$

delimiter $$

DROP FUNCTION IF EXISTS GananciaEntre $$
CREATE FUNCTION GananciaEntre (UnidJugador SMALLINT UNSIGNED, Fecha1 DATETIME, Fecha2 DATETIME)
RETURNS INT READS SQL DATA 
BEGIN 
DECLARE Suma MEDIUMINT UNSIGNED;
SELECT SUM(monedas) INTO Suma
FROM Jugadores
WHERE Fecha BETWEEN Fecha1 AND Fecha2 
AND Transferencia_exitosa = TRUE;

RETURN Suma;

END $$

