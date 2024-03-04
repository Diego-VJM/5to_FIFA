DROP DATABASE IF EXISTS 5to_FIFA;
CREATE DATABASE 5to_FIFA;
USE 5to_FIFA;

CREATE TABLE Jugadores (
	idJugador SMALLINT UNSIGNED PRIMARY KEY,
    usuario VARCHAR(45),
    nombre VARCHAR(45),
    apellido VARCHAR(45),
    contrasena VARCHAR(45),
    monedas MEDIUMINT UNSIGNED,
    CONSTRAINT UQ_Usuario UNIQUE (usuario)
);

CREATE TABLE Habilidad (
	idHabilidad TINYINT UNSIGNED PRIMARY KEY,
    nombre VARCHAR(45),
    descripcion VARCHAR(45)
);

CREATE TABLE Posicion (
	idPosicion TINYINT UNSIGNED PRIMARY KEY,
    Posicion VARCHAR(45)
);
CREATE TABLE Futbolistas(
	idFutbolista TINYINT UNSIGNED PRIMARY KEY,
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    nacimiento DATE NOT NULL,
    velocidad TINYINT UNSIGNED,
    remate TINYINT UNSIGNED,
    pase TINYINT UNSIGNED,
    defensa TINYINT UNSIGNED,
    idPosicion TINYINT UNSIGNED,
    CONSTRAINT FK_Futbolistas_Posicion FOREIGN KEY (idPosicion)
		REFERENCES Posicion (idPosicion)
);

CREATE TABLE PosesionHabilidad (
	idFutbolista TINYINT UNSIGNED,
    idHabilidad TINYINT UNSIGNED,
	CONSTRAINT FK_PH_Futbolistas FOREIGN KEY (idFutbolista)
		REFERENCES Futbolistas (idFutbolista),
	CONSTRAINT FK_PH_Habilidad FOREIGN KEY (idHabilidad)
		REFERENCES Habilidad (idHabilidad)
);
CREATE TABLE Posesion (
	idFutbolista TINYINT UNSIGNED,
    idJugador SMALLINT UNSIGNED,
    CONSTRAINT FK_Posesion_Futbolistas FOREIGN KEY (idFutbolista)
		REFERENCES Futbolistas (idFutbolista),
	CONSTRAINT FK_Posesion_Jugadores FOREIGN KEY (idJugador)
		REFERENCES Jugadores (idJugador)
);
CREATE TABLE Transferencias (
	idTransferencia SMALLINT UNSIGNED PRIMARY KEY auto_increment,
	fecha DATETIME,
    precio MEDIUMINT UNSIGNED,
    idVendedor MEDIUMINT UNSIGNED,
    idComprador MEDIUMINT UNSIGNED,
    idFutbolista TINYINT UNSIGNED,
    Transferencia_exitosa BOOL,
	CONSTRAINT FK_Transferencias_Futbolistas FOREIGN KEY (idFutbolista)
		REFERENCES Futbolistas (idFutbolista)
);
