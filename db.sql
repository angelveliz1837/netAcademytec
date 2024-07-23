use master 
go

drop database Academytec
go

use master
go

create database Academytec
go

use Academytec
go

create table tb_documento(
	iddocumento int primary key,
	nombredocumento varchar(20)
)
go


create table tb_empleado(
	idempleado int primary key,
	iddocumento int,
	numerodocumento varchar(10),
	nombreempleado varchar(100),
	apellidopaternoempleado varchar(50),
	apellidomaternoempleado varchar(50),
	correo varchar (100),
	telefono varchar (20),
	cargo varchar(100),
	foto varchar(100),
	foreign key (iddocumento) references tb_documento (iddocumento)
)
go

create table tb_cliente(
	idcliente int primary key,
	iddocumento int,
	numerodocumento varchar(10),
	nombrecliente varchar(100),
	apellidopaternocliente varchar(50),
	apellidomaternocliente varchar(50),
	correo varchar(100),
	telefono varchar(20),
	foto varchar(100),
	foreign key (iddocumento) references tb_documento(iddocumento)
)
go

create table tb_autor(
	idautor int primary key,
	iddocumento int,
	numerodocumento varchar(10),
	nombreautor varchar(100),
	apellidopaternoautor varchar(50),
	apellidomaternoautor varchar(50),
	correo varchar(100),
	telefono varchar(20),
	foto varchar(100),
	foreign key (iddocumento) references tb_documento(iddocumento)
)
go

create table tb_area(
	idarea int primary key,
	nombrearea varchar(50)
)
go

create table tb_impresion(
	idimpresion int primary key,
	descripcion varchar(50)
)
go

create table tb_libro(
	idlibro int primary key,
	nombrelibro varchar(50),
	descripcionlibro varchar(255),
	preciolibro decimal(8,2),
	stock int,
	paginas int,
	idarea int,
	idimpresion int,
	idautor int,
	idempleado int,
	foreign key (idarea) references tb_area(idarea),
	foreign key (idimpresion) references tb_impresion(idimpresion),
	foreign key (idautor) references tb_autor(idautor),
	foreign key (idempleado) references tb_empleado(idempleado)
)
go

create table tb_almacen(
	idalmacen int primary key,
	idlibro int,
	cantidad int,
	idempleado int,
	foreign key (idlibro) references tb_libro(idlibro),
	foreign key (idempleado) references tb_empleado(idempleado)
)
go

create table tb_empresa(
	idempresa int primary key,
	ruc bigint,
	nombre varchar(100),
	direccion varchar(100),
	telefono varchar(20),
	correo varchar(100),
	web varchar(50),
	logo varchar(100)
)
go

create table tb_factura(
	idfactura int primary key,
	fecha datetime,
	idempresa int,
	idcliente int,
	idempleado int,
	foreign key (idempresa) references tb_empresa(idempresa),
	foreign key (idcliente) references tb_cliente(idcliente),
	foreign key (idempleado) references tb_empleado(idempleado)
)
go

create table tb_programa(
	idprograma int primary key,
	titulo varchar(50),
	descripcion varchar(255),
	idlibro int,
	foreign key (idlibro) references tb_libro(idlibro)
)
go

create table tb_transporte(
	idtransporte int primary key,
	direccionllegada varchar(50),
	direccionpartida varchar(50),
	idempleado int,
	idalmacen int,
	foreign key (idempleado) references tb_empleado(idempleado),
	foreign key (idalmacen) references tb_almacen(idalmacen)
)
go

create table tb_detalle_factura(
	iddetalle_factura int primary key,
	idfactura int,
	idprograma int,
	idlibro int,
	cantidad int,
	idtransporte int,
	importe decimal(8,2),
	precioventa decimal(8,2),
	foreign key (idfactura) references tb_factura(idfactura),
	foreign key (idprograma) references tb_programa(idprograma),
	foreign key (idlibro) references tb_libro(idlibro),
	foreign key (idtransporte) references tb_transporte(idtransporte)
)
go

create table tb_lista(
	idlista int primary key,
	fechalista datetime,
	idempresa int,
	idempleado int,
	foreign key (idempresa) references tb_empresa(idempresa),
	foreign key (idempleado) references tb_empleado(idempleado)
)
go

create table tb_recibo(
	idrecibo int primary key,
	nombrerecibo varchar(20)
)
go

create table tb_material(
	idmaterial int primary key,
	nombrematerial varchar(100),
	preciomaterial decimal(8,2),
	idrecibo int,
	numerorecibo varchar(20),
	foreign key (idrecibo) references tb_recibo(idrecibo)
)
go

create table tb_detalle_lista(
	iddetalle_lista int primary key,
	idlista int,
	idmaterial int,
	cantidad int,
	preciocosto decimal(8,2),
	foreign key (idlista) references tb_lista(idlista),
	foreign key (idmaterial) references tb_material(idmaterial)
)
go

--Insertando datos a tb_documento
INSERT INTO tb_documento (iddocumento, nombredocumento) VALUES (1, 'DNI');
INSERT INTO tb_documento (iddocumento, nombredocumento) VALUES (2, 'Pasaporte');

--Insertando datos a tb_empleado
INSERT INTO tb_empleado (idempleado, iddocumento, numerodocumento, nombreempleado, apellidopaternoempleado, apellidomaternoempleado, correo, telefono, cargo, foto) 
VALUES (1, 1, '12345678', 'Juan', 'Perez', 'Garcia', 'juan.perez@empresa.com', '123456789', 'Gerente', 'juan.jpg');
INSERT INTO tb_empleado (idempleado, iddocumento, numerodocumento, nombreempleado, apellidopaternoempleado, apellidomaternoempleado, correo, telefono, cargo, foto) 
VALUES (2, 2, '87654321', 'Maria', 'Lopez', 'Mendez', 'maria.lopez@empresa.com', '987654321', 'Asistente', 'maria.jpg');

--Insertando datos a tb_cliente
INSERT INTO tb_cliente (idcliente, iddocumento, numerodocumento, nombrecliente, apellidopaternocliente, apellidomaternocliente, correo, telefono, foto) 
VALUES (1, 1, '11223344', 'Carlos', 'Sanchez', 'Flores', 'carlos.sanchez@cliente.com', '111222333', 'carlos.jpg');
INSERT INTO tb_cliente (idcliente, iddocumento, numerodocumento, nombrecliente, apellidopaternocliente, apellidomaternocliente, correo, telefono, foto) 
VALUES (2, 2, '44332211', 'Ana', 'Gomez', 'Diaz', 'ana.gomez@cliente.com', '333222111', 'ana.jpg');

--Insertamos datos a tb_autor
INSERT INTO tb_autor (idautor, iddocumento, numerodocumento, nombreautor, apellidopaternoautor, apellidomaternoautor, correo, telefono, foto)
VALUES (1, 1, '33445566', 'Luis', 'Fernandez', 'Ramirez', 'luis.fernandez@autor.com', '444555666', 'luis.jpg');
INSERT INTO tb_autor (idautor, iddocumento, numerodocumento, nombreautor, apellidopaternoautor, apellidomaternoautor, correo, telefono, foto)
VALUES (2, 2, '66554433', 'Marta', 'Jimenez', 'Suarez', 'marta.jimenez@autor.com', '666555444', 'marta.jpg');

--Insertamos datos a tb_area
INSERT INTO tb_area (idarea, nombrearea) VALUES (1, 'Informatica');
INSERT INTO tb_area (idarea, nombrearea) VALUES (2, 'Matematicas');

--Insertamos datos a tb_impresion
INSERT INTO tb_impresion (idimpresion, descripcion) VALUES (1, 'Primera Edicion');
INSERT INTO tb_impresion (idimpresion, descripcion) VALUES (2, 'Segunda Edicion');

--Insertamos datos a tb_libro
INSERT INTO tb_libro (idlibro, nombrelibro, descripcionlibro, preciolibro, stock, paginas, idarea, idimpresion, idautor, idempleado) 
VALUES (1, 'Programacion en C#', 'Libro sobre programacion en C#', 29.99, 50, 300, 1, 1, 1, 1);
INSERT INTO tb_libro (idlibro, nombrelibro, descripcionlibro, preciolibro, stock, paginas, idarea, idimpresion, idautor, idempleado) 
VALUES (2, 'Calculo I', 'Libro sobre calculo diferencial', 19.99, 30, 250, 2, 2, 2, 2);

--Insertamos datos a tb_almacen
INSERT INTO tb_almacen (idalmacen, idlibro, cantidad, idempleado) VALUES (1, 1, 20, 1);
INSERT INTO tb_almacen (idalmacen, idlibro, cantidad, idempleado) VALUES (2, 2, 10, 2);

--Insertamos datos a tb_empresa
INSERT INTO tb_empresa (idempresa, ruc, nombre, direccion, telefono, correo, web, logo) 
VALUES (1, 12345678901, 'Empresa Tech', 'Calle 123', '123456789', 'contacto@empresatech.com', 'www.empresatech.com', 'logo.png');
INSERT INTO tb_empresa (idempresa, ruc, nombre, direccion, telefono, correo, web, logo) 
VALUES (2, 98765432109, 'Soluciones SA', 'Avenida 456', '987654321', 'info@solucionessa.com', 'www.solucionessa.com', 'logo2.png');

--Insertamos datos a tb_factura
INSERT INTO tb_factura (idfactura, fecha, idempresa, idcliente, idempleado) 
VALUES (1, '2024-01-01', 1, 1, 1);
INSERT INTO tb_factura (idfactura, fecha, idempresa, idcliente, idempleado) 
VALUES (2, '2024-02-01', 2, 2, 2);

--Insertamos datos a tb_programa
INSERT INTO tb_programa (idprograma, titulo, descripcion, idlibro) 
VALUES (1, 'Curso C#', 'Curso completo de programacion en C#', 1);
INSERT INTO tb_programa (idprograma, titulo, descripcion, idlibro) 
VALUES (2, 'Curso Calculo', 'Curso completo de calculo diferencial', 2);

--Insertamos datos a tb_transporte
INSERT INTO tb_transporte (idtransporte, direccionllegada, direccionpartida, idempleado, idalmacen) 
VALUES (1, 'Destino 1', 'Partida 1', 1, 1);
INSERT INTO tb_transporte (idtransporte, direccionllegada, direccionpartida, idempleado, idalmacen) 
VALUES (2, 'Destino 2', 'Partida 2', 2, 2);

--Insertamos datos a tb_detalle_factura
INSERT INTO tb_detalle_factura (iddetalle_factura, idfactura, idprograma, idlibro, cantidad, idtransporte, importe, precioventa) 
VALUES (1, 1, 1, 1, 2, 1, 59.98, 29.99);
INSERT INTO tb_detalle_factura (iddetalle_factura, idfactura, idprograma, idlibro, cantidad, idtransporte, importe, precioventa) 
VALUES (2, 2, 2, 2, 1, 2, 19.99, 19.99);

--Insertamos datos a tb_lista
INSERT INTO tb_lista (idlista, fechalista, idempresa, idempleado) 
VALUES (1, '2024-03-01', 1, 1);
INSERT INTO tb_lista (idlista, fechalista, idempresa, idempleado) 
VALUES (2, '2024-04-01', 2, 2);

--Insertamos datos a tb_recibo
INSERT INTO tb_recibo (idrecibo, nombrerecibo) VALUES (1, 'Recibo 1');
INSERT INTO tb_recibo (idrecibo, nombrerecibo) VALUES (2, 'Recibo 2');

--Insertamos datos a tb_material
INSERT INTO tb_material (idmaterial, nombrematerial, preciomaterial, idrecibo, numerorecibo) 
VALUES (1, 'Material 1', 9.99, 1, '001');
INSERT INTO tb_material (idmaterial, nombrematerial, preciomaterial, idrecibo, numerorecibo) 
VALUES (2, 'Material 2', 19.99, 2, '002');

--Insertamos datos a tb_detalle_lista
INSERT INTO tb_detalle_lista (iddetalle_lista, idlista, idmaterial, cantidad, preciocosto) 
VALUES (1, 1, 1, 5, 49.95);
INSERT INTO tb_detalle_lista (iddetalle_lista, idlista, idmaterial, cantidad, preciocosto) 
VALUES (2, 2, 2, 3, 59.97);

create or alter proc usp_materiaprima
As
Select * from tb_materiaprima
go

create or alter proc usp_inserta_materiaprima
@idmp int,
@desmp varchar(255),
@preuni decimal(10,2),
@stock int
As
insert tb_materiaprima Values(@idmp,@desmp,@preuni,@stock)
go

create or alter proc usp_actualiza_materiaprima
@idmp int,
@desmp varchar(255),
@preuni decimal(10,2),
@stock int
As
update tb_materiaprima 
Set desmp=@desmp,preuni=@preuni,stock=@stock Where idmp=@idmp
go

create or alter proc usp_elimina_materiaprima
@idmp int
As
Delete tb_materiaprima Where idmp=@idmp
go
