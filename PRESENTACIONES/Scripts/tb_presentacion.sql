SELECT eliminartabla('tb_presentacion');

CREATE TABLE tb_presentacion(
	id 					SERIAL,
	des_presentacion 	CHAR(50) NOT NULL,
	status 				SMALLINT NOT NULL DEFAULT 0,
	fecha_alta 			DATE NOT NULL DEFAULT CURRENT_DATE,
	PRIMARY KEY 		(des_presentacion)
);