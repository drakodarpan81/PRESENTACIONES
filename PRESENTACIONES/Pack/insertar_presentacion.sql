CREATE OR REPLACE FUNCTION insertar_presentacion(presentacion char(20)) 
RETURNS VOID
AS 
$$
	BEGIN
		INSERT INTO ctl_presentacion(presentacion)
		VALUES(presentacion);
	END
	
$$ 
language 'plpgsql';