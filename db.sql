use master 
go

drop database Academytec
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
	ruc int,
	nombre varchar(100),
	direccion varchar(100),
	telefono varchar(20),
	correo varchar(100),
	web varchar(20),
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
	idlista int primary  key,
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
	nombrematerial int,
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
