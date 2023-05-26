CREATE OR REPLACE FUNCTION insertar_presentacion(desc_presentacion VARCHAR(20)) 
RETURNS VOID
AS 
$$
	BEGIN
		INSERT INTO tb_presentacion(des_presentacion)
		VALUES(desc_presentacion);
	END
	
$$ 
language 'plpgsql';