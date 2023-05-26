DROP TABLE IF EXISTS ctl_presentacion;

CREATE TABLE ctl_presentacion(
	id SERIAL,
	presentacion CHAR(20) NOT NULL DEFAULT '',
	activo BOOL NOT NULL DEFAULT True
);
