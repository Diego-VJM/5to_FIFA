
USE 5to_FIFA;
SELECT 'Rellenando Tablas' Estado;
CALL AltaHabilidad (1, "Preciso", "Mejora la presicion del Futbolista");
CALL AltaHabilidad (100, "peruano", "peruano");
CALL AltaJugadores (1, "Lol305", "Diego", "vega", "12345678vega", 0);
CALL AltaJugadores (3, "goku", "kakaroto", "gohan", "vegeta", 200);
CALL AltaPosicion (1, "Defensa");
CALL AltaFutbolista (1, "Nicolas", "Otamendi", "2024-09-09", 75, 70, 75, 90, 1);
CALL AltaFutbolista (100, "peruano", "peruano", "2024-09-08", 99, 99, 99, 99, 1);
CALL AltaPosesionHabilidad (1, 1);
CALL AltaPosesion (1, 1);
CALL Publicar (1, 1, 200);
CALL Comprar (1, 3);
CALL mostrarfutbolistas(1);