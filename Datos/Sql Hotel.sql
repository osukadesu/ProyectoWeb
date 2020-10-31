USE [Hotel]

CREATE TABLE cliente (
    id_cliente                 VARCHAR(4) NOT NULL,
    persona_cedula             VARCHAR(12) NOT NULL,
    habitacion_id_habitacion   VARCHAR(4) NOT NULL,
    id_cliente_principal       VARCHAR(4)
)

go 

    


CREATE unique nonclustered index cliente__idx ON cliente ( persona_cedula ) go

ALTER TABLE cliente ADD constraint cliente_pk PRIMARY KEY CLUSTERED (id_cliente)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) go

CREATE TABLE empleado (
    id_empleado        VARCHAR(4) NOT NULL,
    persona_cedula     VARCHAR(12) NOT NULL,
    cargo              VARCHAR(12) NOT NULL,
    jornada            VARCHAR(8) NOT NULL,
    id_empleado_jefe   VARCHAR(4)
)

go 

    


CREATE unique nonclustered index empleado__idx ON empleado ( persona_cedula ) go

ALTER TABLE empleado ADD constraint empleado_pk PRIMARY KEY CLUSTERED (id_empleado)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) go

CREATE TABLE factura (
    id_factura                 VARCHAR(4) NOT NULL,
    fecha_factura              datetime NOT NULL,
    subtotal                   NUMERIC(7) NOT NULL,
    iva                        NUMERIC(7) NOT NULL,
    total                      NUMERIC(7) NOT NULL,
    cantidad                   NUMERIC(2) NOT NULL,
    fecha_entrada              datetime NOT NULL,
    fecha_salida               datetime NOT NULL,
    cliente_id_cliente         VARCHAR(4) NOT NULL,
    habitacion_id_habitacion   VARCHAR(4) NOT NULL
)

go 

    


CREATE unique nonclustered index factura__idx ON factura ( habitacion_id_habitacion ) go

ALTER TABLE factura ADD constraint factura_pk PRIMARY KEY CLUSTERED (id_factura)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) go

CREATE TABLE habitacion (
    id_habitacion    VARCHAR(4) NOT NULL,
    tipo             VARCHAR(8) NOT NULL,
    n_min_personas   NUMERIC(1) NOT NULL,
    estado           VARCHAR(12) NOT NULL,
    precio           NUMERIC(7) NOT NULL
)

go

ALTER TABLE habitacion ADD constraint habitacion_pk PRIMARY KEY CLUSTERED (id_habitacion)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) go

CREATE TABLE persona (
    cedula             VARCHAR(12) NOT NULL,
    primer_nombre      VARCHAR(12) NOT NULL,
    segundo_nombre     VARCHAR(12) NOT NULL,
    primer_apellido    VARCHAR(12) NOT NULL,
    segundo_apellido   VARCHAR(12) NOT NULL,
    edad               NUMERIC(2) NOT NULL,
    sexo               VARCHAR(9) NOT NULL,
    email              VARCHAR(30) NOT NULL,
    telefono           NUMERIC(10) NOT NULL,
    departamento       VARCHAR(12) NOT NULL,
    ciudad             VARCHAR(12) NOT NULL
)

go

ALTER TABLE persona ADD constraint persona_pk PRIMARY KEY CLUSTERED (cedula)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) go



CREATE TABLE producto (
    id_producto   VARCHAR(4) NOT NULL,
    nombre        VARCHAR(12) NOT NULL,
    tipo          VARCHAR(15) NOT NULL,
    cantidad      NUMERIC(2) NOT NULL,
    precio      NUMERIC(8) NOT NULL
)

go

ALTER TABLE producto ADD constraint producto_pk PRIMARY KEY CLUSTERED (id_producto)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) go

CREATE TABLE producto_factura (
    producto_id_producto   VARCHAR(4) NOT NULL,
    factura_id_factura     VARCHAR(4) NOT NULL
)

go

ALTER TABLE producto_factura ADD constraint producto_factura_pk PRIMARY KEY CLUSTERED (producto_id_producto, factura_id_factura)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) go

ALTER TABLE cliente
    ADD CONSTRAINT cliente_cliente_fk FOREIGN KEY ( id_cliente_principal )
        REFERENCES cliente ( id_cliente )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE cliente
    ADD CONSTRAINT cliente_habitacion_fk FOREIGN KEY ( habitacion_id_habitacion )
        REFERENCES habitacion ( id_habitacion )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE cliente
    ADD CONSTRAINT cliente_persona_fk FOREIGN KEY ( persona_cedula )
        REFERENCES persona ( cedula )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE empleado
    ADD CONSTRAINT empleado_empleado_fk FOREIGN KEY ( id_empleado_jefe )
        REFERENCES empleado ( id_empleado )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE empleado
    ADD CONSTRAINT empleado_persona_fk FOREIGN KEY ( persona_cedula )
        REFERENCES persona ( cedula )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE factura
    ADD CONSTRAINT factura_cliente_fk FOREIGN KEY ( cliente_id_cliente )
        REFERENCES cliente ( id_cliente )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE factura
    ADD CONSTRAINT factura_habitacion_fk FOREIGN KEY ( habitacion_id_habitacion )
        REFERENCES habitacion ( id_habitacion )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE producto_factura
    ADD CONSTRAINT producto_factura_factura_fk FOREIGN KEY ( factura_id_factura )
        REFERENCES factura ( id_factura )
ON DELETE NO ACTION 
    ON UPDATE no action go

ALTER TABLE producto_factura
    ADD CONSTRAINT producto_factura_producto_fk FOREIGN KEY ( producto_id_producto )
        REFERENCES producto ( id_producto )
ON DELETE NO ACTION 
    ON UPDATE no action go

