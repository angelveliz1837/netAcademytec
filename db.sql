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

/**************  TABLAS  ******************/

-- TABLA DOCUMENTO
create table tb_documento(
	iddocumento int primary key,
	nombredocumento varchar(20)
)
go

-- TABLA EMPLEADO
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

--TABLA CLIENTE
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

--TABLA AUTOR
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

--TABLA AREA
create table tb_area(
	idarea int primary key,
	nombrearea varchar(50)
)
go

--TABLA IMPRESION
create table tb_impresion(
	idimpresion int primary key,
	descripcion varchar(50)
)
go

--TABLA LIBRO
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

--TABLA ALMACEN
create table tb_almacen(
	idalmacen int primary key,
	idlibro int,
	cantidad int,
	idempleado int,
	foreign key (idlibro) references tb_libro(idlibro),
	foreign key (idempleado) references tb_empleado(idempleado)
)
go

--TABLA EMPRESA
create table tb_empresa(
	idempresa int primary key,
	ruc varchar(20),
	nombre varchar(100),
	direccion varchar(100),
	telefono varchar(50),
	correo varchar(100),
	web varchar(100),
	logo varchar(100)
)
go

--TABLA FACTURA
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

--TABLA PROGRAMA
create table tb_programa(
	idprograma int primary key,
	titulo varchar(50),
	descripcion varchar(255),
	idlibro int,
	foreign key (idlibro) references tb_libro(idlibro)
)
go

--TABLA TRANSPORTE
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

--TABLA DETALLE FACTURA
create table tb_detalle_factura(
	iddetallefactura int primary key,
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

--TABLA LISTA
create table tb_lista(
	idlista int primary key,
	fechalista datetime,
	idempresa int,
	idempleado int,
	foreign key (idempresa) references tb_empresa(idempresa),
	foreign key (idempleado) references tb_empleado(idempleado)
)
go

--TABLA RECIBO
create table tb_recibo(
	idrecibo int primary key,
	nombrerecibo varchar(20)
)
go

--TABLA MATERIAL
create table tb_material(
	idmaterial int primary key,
	nombrematerial varchar(100),
	preciomaterial decimal(8,2),
	idrecibo int,
	numerorecibo varchar(20),
	foreign key (idrecibo) references tb_recibo(idrecibo)
)
go

--TABLA DETALLE LISTA
create table tb_detalle_lista(
	iddetallelista int primary key,
	idlista int,
	idmaterial int,
	cantidad int,
	preciocosto decimal(8,2),
	foreign key (idlista) references tb_lista(idlista),
	foreign key (idmaterial) references tb_material(idmaterial)
)
go

/**************MANEJO DEL PORTAL PARA VENTAS************************/

create or alter proc usp_libro_tienda
As
Select idlibro, nombrelibro, descripcionlibro, preciolibro, 
Cast(stock as int), paginas, idarea, idimpresion, idautor, idempleado
from tb_libro
Where stock > 0
go

create table tb_notaventa(
	idnvta int primary key,
	fecnvta datetime default(getdate()),
	idcliente int references tb_cliente
)
go

create table tb_notaventa_detalle(
	idnvta int references tb_notaventa,
	idlibro int references tb_libro,
	preuni decimal,
	cantidad int
)
go

/*un procedure donde retorna el siguiente valor de idnvta de la tabla
tb_notaventa, considere que la tabla en este momento esta vacío*/
create or alter proc usp_idnotaventa
@id int output
As
Begin
	declare @idnota int = (Select top 1 idnvta from tb_notaventa order by idnvta desc)
	if(@idnota is null)
		Set @id=1
	else
		Set @id=@idnota+1
End
go

declare @n int
exec usp_idnotaventa @n output
print @n
go
/******************************************************************************/

/***************CRUD DE TABLAS ******************************/
-- CRUD ALMACEN
create or alter proc usp_almacen
As
Select * from tb_almacen
go

create or alter proc usp_inserta_almacen
@idalmacen int,
@idlibro int,
@cantidad int,
@idempleado int
As
insert tb_almacen Values(@idalmacen,@idlibro,@cantidad,@idempleado)
go

create or alter proc usp_actualiza_almacen
@idalmacen int,
@idlibro int,
@cantidad int,
@idempleado int
As
update tb_almacen 
Set idlibro=@idlibro,cantidad=@cantidad,idempleado=@idempleado Where idalmacen=@idalmacen
go

create or alter proc usp_elimina_almacen
@idalmacen int
As
Delete tb_almacen Where idalmacen=@idalmacen
go

--CRUD AREA
create or alter proc usp_area
As
Select * from tb_area
go

create or alter proc usp_inserta_area
@idarea int,
@nombrearea varchar(50)
As
insert tb_area Values(@idarea,@nombrearea)
go

create or alter proc usp_actualiza_area
@idarea int,
@nombrearea varchar(50)
As
update tb_area
Set nombrearea=@nombrearea Where idarea=@idarea
go

create or alter proc usp_elimina_area
@idarea int
As
Delete tb_area Where idarea=@idarea
go

--CRUD AUTOR
create or alter proc usp_autor
As
Select * from tb_autor
go

create or alter proc usp_inserta_autor
@idautor int,
@iddocumento int,
@numerodocumento varchar(10),
@nombreautor varchar(100),
@apellidopaternoautor varchar(50),
@apellidomaternoautor varchar(50),
@correo varchar(100),
@telefono varchar(20),
@foto varchar(100)
As
insert tb_autor Values(@idautor,@iddocumento,@numerodocumento,@nombreautor, @apellidopaternoautor, @apellidomaternoautor, @correo, @telefono, @foto)
go

create or alter proc usp_actualiza_autor
@idautor int,
@iddocumento int,
@numerodocumento varchar(10),
@nombreautor varchar(100),
@apellidopaternoautor varchar(50),
@apellidomaternoautor varchar(50),
@correo varchar(100),
@telefono varchar(20),
@foto varchar(100)
As
update tb_autor 
Set iddocumento=@iddocumento,numerodocumento=@numerodocumento,nombreautor=@nombreautor,apellidopaternoautor=@apellidopaternoautor,apellidomaternoautor=@apellidomaternoautor,correo=@correo,telefono=@telefono,foto=@foto Where idautor=@idautor
go

create or alter proc usp_elimina_autor
@idautor int
As
Delete tb_autor Where idautor=@idautor
go

--CRUD CLIENTE
create or alter proc usp_cliente
As
Select * from tb_cliente
go

create or alter proc usp_inserta_cliente
@idcliente int,
@iddocumento int,
@numerodocumento varchar(10),
@nombrecliente varchar(100),
@apellidopaternocliente varchar(50),
@apellidomaternocliente varchar(50),
@correo varchar(100),
@telefono varchar(20),
@foto varchar(100)
As
insert tb_cliente Values(@idcliente,@iddocumento,@numerodocumento,@nombrecliente,@apellidopaternocliente,@apellidomaternocliente,@correo,@telefono,@foto)
go

create or alter proc usp_actualiza_cliente
@idcliente int,
@iddocumento int,
@numerodocumento varchar(10),
@nombrecliente varchar(100),
@apellidopaternocliente varchar(50),
@apellidomaternocliente varchar(50),
@correo varchar(100),
@telefono varchar(20),
@foto varchar(100)
As
update tb_cliente 
Set iddocumento=@iddocumento,numerodocumento=@numerodocumento,nombrecliente=@nombrecliente,apellidopaternocliente=@apellidopaternocliente,apellidomaternocliente=@apellidomaternocliente,correo=@correo,telefono=@telefono,foto=@foto Where idcliente=@idcliente
go

create or alter proc usp_elimina_cliente
@idcliente int
As
Delete tb_cliente Where idcliente=@idcliente
go

--CRUD DETALLE FACTURA
create or alter proc usp_detalle_factura
As
Select * from tb_detalle_factura
go

create or alter proc usp_inserta_detalle_factura
@iddetallefactura int,
@idfactura int,
@idprograma int,
@idlibro int,
@cantidad int,
@idtransporte int,
@importe decimal(8,2),
@precioventa decimal(8,2)
As
insert tb_detalle_factura Values(@iddetallefactura,@idfactura,@idprograma,@idlibro,@cantidad,@idtransporte,@importe,@precioventa)
go

create or alter proc usp_actualiza_detalle_factura
@iddetallefactura int,
@idfactura int,
@idprograma int,
@idlibro int,
@cantidad int,
@idtransporte int,
@importe decimal(8,2),
@precioventa decimal(8,2)
As
update tb_detalle_factura 
Set idfactura=@idfactura,idprograma=@idprograma,idlibro=@idlibro,cantidad=@cantidad,idtransporte=@idtransporte,importe=@importe,precioventa=@precioventa Where iddetallefactura=@iddetallefactura
go

create or alter proc usp_elimina_detalle_factura
@iddetallefactura int
As
Delete tb_detalle_factura Where iddetallefactura=@iddetallefactura
go

--CRUD DETALLE LISTA
create or alter proc usp_detalle_lista
As
Select * from tb_detalle_lista
go

create or alter proc usp_inserta_detalle_lista
@iddetallelista int,
@idlista int,
@idmaterial int,
@cantidad int,
@preciocosto decimal(8,2)
As
insert tb_detalle_lista Values(@iddetallelista,@idlista,@idmaterial,@cantidad,@preciocosto)
go

create or alter proc usp_actualiza_detalle_lista
@iddetallelista int,
@idlista int,
@idmaterial int,
@cantidad int,
@preciocosto decimal(8,2)
As
update tb_detalle_lista 
Set idlista=@idlista,idmaterial=@idmaterial,cantidad=@cantidad,preciocosto=@preciocosto Where iddetallelista=@iddetallelista
go

create or alter proc usp_elimina_detalle_lista
@iddetallelista int
As
Delete tb_detallelista Where iddetallelista=@iddetallelista
go

--CRUD LIBRO
create or alter proc usp_libro
As
Select * from tb_libro
go

create or alter proc usp_inserta_libro
@idlibro int,
@nombrelibro varchar(50),
@descripcionlibro varchar(255),
@preciolibro decimal(8,2),
@stock int,
@paginas int,
@idarea int,
@idimpresion int,
@idautor int,
@idempleado int
As
insert tb_libro Values(@idlibro,@nombrelibro,@descripcionlibro,@preciolibro,@stock,@paginas,@idarea,@idimpresion,@idautor,@idempleado)
go

create or alter proc usp_actualiza_libro
@idlibro int,
@nombrelibro varchar(50),
@descripcionlibro varchar(255),
@preciolibro decimal(8,2),
@stock int,
@paginas int,
@idarea int,
@idimpresion int,
@idautor int,
@idempleado int
As
update tb_libro 
Set descripcionlibro=@descripcionlibro,preciolibro=@preciolibro,stock=@stock,paginas=@paginas,idarea=@idarea,idimpresion=@idimpresion,idautor=@idautor,idempleado=@idempleado Where idlibro=@idlibro
go

create or alter proc usp_elimina_libro
@idlibro int
As
Delete tb_libro Where idlibro=@idlibro
go

--CRUD LISTA
create or alter proc usp_lista
As
Select * from tb_lista
go

create or alter proc usp_inserta_lista
@idlista int,
@fechalista varchar(255),
@idempresa decimal(10,2),
@idempleado int
As
insert tb_lista Values(@idlista,@fechalista,@idempresa,@idempleado)
go

create or alter proc usp_actualiza_lista
@idlista int,
@fechalista varchar(255),
@idempresa decimal(10,2),
@idempleado int
As
update tb_lista 
Set fechalista=@fechalista,idempresa=@idempresa,idempleado=@idempleado Where idlista=@idlista
go

create or alter proc usp_elimina_lista
@idlista int
As
Delete tb_lista Where idlista=@idlista
go

--CRUD FACTURA
create or alter proc usp_factura
As
Select * from tb_factura
go

create or alter proc usp_inserta_factura
@idfactura int,
@fecha datetime,
@idempresa int,
@idcliente int,
@idempleado int
As
insert tb_factura Values(@idfactura,@fecha,@idempresa,@idcliente,@idempleado)
go

create or alter proc usp_actualiza_factura
@idfactura int,
@fecha datetime,
@idempresa int,
@idcliente int,
@idempleado int
As
update tb_factura 
Set fecha=@fecha,idempresa=@idempresa,idcliente=@idcliente,idempleado=@idempleado Where idfactura=@idfactura
go

create or alter proc usp_elimina_factura
@idfactura int
As
Delete tb_factura Where idfactura=@idfactura
go

--CRUD EMPLEADO
create or alter proc usp_empleado
As
Select * from tb_empleado
go

create or alter proc usp_inserta_empleado
@idempleado int,
@iddocumento int,
@numerodocumento varchar(10),
@nombreempleado varchar(100),
@apellidopaternoempleado varchar(50),
@apellidomaternoempleado varchar(50),
@correo varchar (100),
@telefono varchar (20),
@cargo varchar(100),
@foto varchar(100)
As
insert tb_empleado Values(@idempleado,@iddocumento,@numerodocumento,@nombreempleado,@apellidopaternoempleado,@apellidomaternoempleado,@correo,@telefono,@cargo,@foto)
go

create or alter proc usp_actualiza_empleado
@idempleado int,
@iddocumento int,
@numerodocumento varchar(10),
@nombreempleado varchar(100),
@apellidopaternoempleado varchar(50),
@apellidomaternoempleado varchar(50),
@correo varchar (100),
@telefono varchar (20),
@cargo varchar(100),
@foto varchar(100)
As
update tb_empleado 
Set iddocumento=@iddocumento,numerodocumento=@numerodocumento,nombreempleado=@nombreempleado,apellidopaternoempleado=@apellidopaternoempleado,apellidomaternoempleado=@apellidomaternoempleado,correo=@correo,telefono=@telefono,cargo=@cargo,foto=@foto Where idempleado=@idempleado
go

create or alter proc usp_elimina_empleado
@idempleado int
As
Delete tb_empleado Where idempleado=@idempleado
go

--CRUD EMPRESA
create or alter proc usp_empresa
As
Select * from tb_empresa
go

create or alter proc usp_inserta_empresa
@idempresa int,
@ruc int,
@nombre varchar(100),
@direccion varchar(100),
@correo varchar(100),
@telefono varchar(20),
@web varchar(50),
@logo varchar(100)
As
insert tb_empresa Values(@idempresa,@ruc,@nombre,@direccion,@correo,@telefono,@web,@logo)
go

create or alter proc usp_actualiza_empresa
@idempresa int,
@ruc varchar(20),
@nombre varchar(100),
@direccion varchar(100),
@correo varchar(100),
@telefono varchar(20),
@web varchar(50),
@logo varchar(100)
As
update tb_empresa
Set ruc=@ruc,nombre=@nombre,direccion=@direccion,correo=@correo,telefono=@telefono,web=@web,logo=@logo Where idempresa=@idempresa
go

create or alter proc usp_elimina_empresa
@idempresa int
As
Delete tb_empresa Where idempresa=@idempresa
go

--CRUD DOCUMENTO
create or alter proc usp_documento
As
Select * from tb_documento
go

create or alter proc usp_inserta_documento
@iddocumento int,
@nombredocumento varchar(20)
As
insert tb_documento Values(@iddocumento,@nombredocumento)
go

create or alter proc usp_actualiza_documento
@iddocumento int,
@nombredocumento varchar(20)
As
update tb_documento 
Set nombredocumento=@nombredocumento Where iddocumento=@iddocumento
go

create or alter proc usp_elimina_documento
@iddocumento int
As
Delete tb_documento Where iddocumento=@iddocumento
go

--CRUD IMPRESION
create or alter proc usp_impresion
As
Select * from tb_impresion
go

create or alter proc usp_inserta_impresion
@idimpresion int,
@descripcion varchar(50)
As
insert tb_impresion Values(@idimpresion,@descripcion)
go

create or alter proc usp_actualiza_impresion
@idimpresion int,
@descripcion varchar(50)
As
update tb_impresion 
Set descripcion=@descripcion Where idimpresion=@idimpresion
go

create or alter proc usp_elimina_impresion
@idimpresion int
As
Delete tb_impresion Where idimpresion=@idimpresion
go

--CRUD MATERIAL
create or alter proc usp_material
As
Select * from tb_material
go

create or alter proc usp_inserta_material
@idmaterial int,
@nombrematerial varchar(100),
@preciomaterial decimal(8,2),
@idrecibo int,
@numerorecibo varchar(20)
As
insert tb_material Values(@idmaterial,@nombrematerial,@preciomaterial,@idrecibo,@numerorecibo)
go

create or alter proc usp_actualiza_material
@idmaterial int,
@nombrematerial varchar(100),
@preciomaterial decimal(8,2),
@idrecibo int,
@numerorecibo varchar(20)
As
update tb_material
Set nombrematerial=@nombrematerial,preciomaterial=@preciomaterial,idrecibo=@idrecibo,numerorecibo=@numerorecibo Where idmaterial=@idmaterial
go

create or alter proc usp_elimina_material
@idmaterial int
As
Delete tb_material Where idmaterial=@idmaterial
go

--CRUD PROGRAMA
create or alter proc usp_programa
As
Select * from tb_programa
go

create or alter proc usp_inserta_programa
@idprograma int,
@titulo varchar(50),
@descripcion varchar(255),
@idlibro int
As
insert tb_programa Values(@idprograma,@titulo,@descripcion,@idlibro)
go

create or alter proc usp_actualiza_programa
@idprograma int,
@titulo varchar(50),
@descripcion varchar(255),
@idlibro int
As
update tb_programa 
Set titulo=@titulo,descripcion=@descripcion,idlibro=@idlibro Where idprograma=@idprograma
go

create or alter proc usp_elimina_programa
@idprograma int
As
Delete tb_programa Where idprograma=@idprograma
go

--CRUD RECIBO
create or alter proc usp_recibo
As
Select * from tb_recibo
go

create or alter proc usp_inserta_recibo
@idrecibo int,
@nombrerecibo varchar(255)
As
insert tb_recibo Values(@idrecibo,@nombrerecibo)
go

create or alter proc usp_actualiza_recibo
@idrecibo int,
@nombrerecibo varchar(255)
As
update tb_recibo 
Set nombrerecibo=@nombrerecibo Where idrecibo=@idrecibo
go

create or alter proc usp_elimina_recibo
@idrecibo int
As
Delete tb_recibo Where idrecibo=@idrecibo
go

--CRUD TRANSPORTE
create or alter proc usp_transporte
As
Select * from tb_transporte
go

create or alter proc usp_inserta_transporte
@idtransporte int,
@direccionpartida varchar(50),
@direccionllegada varchar(50),
@idempleado int,
@idalmacen int
As
insert tb_transporte Values(@idtransporte,@direccionpartida,@direccionllegada,@idempleado,@idalmacen)
go

create or alter proc usp_actualiza_transporte
@idtransporte int,
@direccionpartida varchar(50),
@direccionllegada varchar(50),
@idempleado int,
@idalmacen int
As
update tb_transporte 
Set direccionpartida=@direccionpartida,direccionllegada=@direccionllegada,idempleado=@idempleado,idalmacen=@idalmacen Where idtransporte=@idtransporte
go

create or alter proc usp_elimina_transporte
@idtransporte int
As
Delete tb_transporte Where idtransporte=@idtransporte
go

/*************INSERTANDO DATOS************************/

--Insertando datos a tb_documento
EXEC usp_inserta_documento 
    @iddocumento	 = 1, 
    @nombredocumento = 'DNI';

EXEC usp_inserta_documento 
    @iddocumento	 = 2, 
    @nombredocumento = 'Pasaporte';

--Insertando datos a tb_empleado
EXEC usp_inserta_empleado 
    @idempleado				 = 1,
    @iddocumento			 = 1,
    @numerodocumento		 = '12345678',
    @nombreempleado			 = 'Juan',
    @apellidopaternoempleado = 'Perez',
    @apellidomaternoempleado = 'Garcia',
    @correo					 = 'juan.perez@empresa.com',
    @telefono				 = '123456789',
    @cargo					 = 'Gerente',
    @foto					 = 'juan.jpg';

EXEC usp_inserta_empleado 
    @idempleado				 = 2,
    @iddocumento			 = 2,
    @numerodocumento		 = '87654321',
    @nombreempleado			 = 'Maria',
    @apellidopaternoempleado = 'Lopez',
    @apellidomaternoempleado = 'Mendez',
    @correo					 = 'maria.lopez@empresa.com',
    @telefono				 = '987654321',
    @cargo					 = 'Asistente',
    @foto					 = 'maria.jpg';

--Insertando datos a tb_cliente
EXEC usp_inserta_cliente 
    @idcliente				= 1,
    @iddocumento			= 1,
    @numerodocumento		= '11223344',
    @nombrecliente			= 'Carlos',
    @apellidopaternocliente = 'Sanchez',
    @apellidomaternocliente = 'Flores',
    @correo					= 'carlos.sanchez@cliente.com',
    @telefono				= '111222333',
    @foto					= 'carlos.jpg';

EXEC usp_inserta_cliente 
    @idcliente				= 2,
    @iddocumento			= 2,
    @numerodocumento		= '44332211',
    @nombrecliente			= 'Ana',
    @apellidopaternocliente = 'Gomez',
    @apellidomaternocliente = 'Diaz',
    @correo					= 'ana.gomez@cliente.com',
    @telefono				= '333222111',
    @foto					= 'ana.jpg';


--Insertamos datos a tb_autor
EXEC usp_inserta_autor 
    @idautor			  = 1,
    @iddocumento		  = 1,
    @numerodocumento	  = '33445566',
    @nombreautor		  = 'Luis',
    @apellidopaternoautor = 'Fernandez',
    @apellidomaternoautor = 'Ramirez',
    @correo				  = 'luis.fernandez@autor.com',
    @telefono			  = '444555666',
    @foto				  = 'luis.jpg';

EXEC usp_inserta_autor 
    @idautor			  = 2,
    @iddocumento		  = 2,
    @numerodocumento	  = '66554433',
    @nombreautor		  = 'Marta',
    @apellidopaternoautor = 'Jimenez',
    @apellidomaternoautor = 'Suarez',
    @correo				  = 'marta.jimenez@autor.com',
    @telefono			  = '666555444',
    @foto				  = 'marta.jpg';

--Insertamos datos a tb_area
EXEC usp_inserta_area 
    @idarea		= 1,
    @nombrearea = 'Informatica';

EXEC usp_inserta_area 
    @idarea		= 2,
    @nombrearea = 'Matematicas';

--Insertamos datos a tb_impresion
EXEC usp_inserta_impresion 
    @idimpresion = 1,
    @descripcion = 'Primera Edicion';

EXEC usp_inserta_impresion 
    @idimpresion = 2,
    @descripcion = 'Segunda Edicion';


--Insertamos datos a tb_libro
EXEC usp_inserta_libro 
    @idlibro		  = 1,
    @nombrelibro	  = 'Programacion en C#',
    @descripcionlibro = 'Libro sobre programacion en C#',
    @preciolibro	  = 29.99,
    @stock			  = 50,
    @paginas		  = 300,
    @idarea			  = 1,
    @idimpresion	  = 1,
    @idautor		  = 1,
    @idempleado		  = 1;

EXEC usp_inserta_libro 
    @idlibro		  = 2,
    @nombrelibro	  = 'Calculo I',
    @descripcionlibro = 'Libro sobre calculo diferencial',
    @preciolibro	  = 19.99,
    @stock			  = 30,
    @paginas		  = 250,
    @idarea			  = 2,
    @idimpresion	  = 2,
    @idautor		  = 2,
    @idempleado		  = 2;

--Insertamos datos a tb_almacen
EXEC usp_inserta_almacen 
    @idalmacen	= 1,
    @idlibro	= 1,
    @cantidad	= 20,
    @idempleado = 1;

EXEC usp_inserta_almacen 
    @idalmacen	= 2,
    @idlibro	= 2,
    @cantidad	= 10,
    @idempleado = 2;

--Insertamos datos a tb_empresa
EXEC usp_inserta_empresa 
    @idempresa	= 1,
    @ruc		= 12345678901,
    @nombre		= 'Empresa Tech',
    @direccion	= 'Calle 123',
    @correo		= 'contacto@empresatech.com',
	@telefono	= '123456789',
    @web		= 'www.empresatech.com',
    @logo		= 'logo.png';

EXEC usp_inserta_empresa 
    @idempresa	= 2,
    @ruc		= 98765432109,
    @nombre		= 'Soluciones SA',
    @direccion	= 'Avenida 456',
	@correo		= 'info@solucionessa.com',
    @telefono	= '987654321',
    @web		= 'www.solucionessa.com',
    @logo		= 'logo2.png';

--Insertamos datos a tb_factura
EXEC usp_inserta_factura 
    @idfactura	= 1,
    @fecha		= '2024-01-01',
    @idempresa	= 1,
    @idcliente	= 1,
    @idempleado = 1;

EXEC usp_inserta_factura 
    @idfactura	= 2,
    @fecha		= '2024-02-01',
    @idempresa	= 2,
    @idcliente	= 2,
    @idempleado = 2;


--Insertamos datos a tb_programa
EXEC usp_inserta_programa 
    @idprograma  = 1,
    @titulo		 = 'Curso C#',
    @descripcion = 'Curso completo de programacion en C#',
    @idlibro	 = 1;

EXEC usp_inserta_programa 
    @idprograma  = 2,
    @titulo		 = 'Curso Calculo',
    @descripcion = 'Curso completo de calculo diferencial',
    @idlibro	 = 2;

--Insertamos datos a tb_transporte
EXEC usp_inserta_transporte 
    @idtransporte	  = 1,
    @direccionllegada = 'Destino 1',
    @direccionpartida = 'Partida 1',
    @idempleado		  = 1,
    @idalmacen		  = 1;

EXEC usp_inserta_transporte 
    @idtransporte	  = 2,
    @direccionllegada = 'Destino 2',
    @direccionpartida = 'Partida 2',
    @idempleado		  = 2,
    @idalmacen		  = 2;

--Insertamos datos a tb_detalle_factura
EXEC usp_inserta_detalle_factura 
    @iddetallefactura	= 1,
    @idfactura			= 1,
    @idprograma			= 1,
    @idlibro			= 1,
    @cantidad			= 2,
    @idtransporte		= 1,
    @importe			= 59.98,
    @precioventa		= 29.99;

EXEC usp_inserta_detalle_factura 
    @iddetallefactura	= 2,
    @idfactura			= 2,
    @idprograma			= 2,
    @idlibro			= 2,
    @cantidad			= 1,
    @idtransporte		= 2,
    @importe			= 19.99,
    @precioventa		= 19.99;

--Insertamos datos a tb_lista
EXEC usp_inserta_lista 
    @idlista	= 1,
    @fechalista = '2024-03-01',
    @idempresa	= 1,
    @idempleado = 1;

EXEC usp_inserta_lista 
    @idlista	= 2,
    @fechalista = '2024-04-01',
    @idempresa	= 2,
    @idempleado = 2;

--Insertamos datos a tb_recibo
EXEC usp_inserta_recibo 
    @idrecibo		= 1,
    @nombrerecibo	= 'Recibo 1';

EXEC usp_inserta_recibo 
    @idrecibo		= 2,
    @nombrerecibo	= 'Recibo 2';

--Insertamos datos a tb_material
EXEC usp_inserta_material 
    @idmaterial		= 1,
    @nombrematerial = 'Material 1',
    @preciomaterial = 9.99,
    @idrecibo		= 1,
    @numerorecibo	= '001';

EXEC usp_inserta_material 
    @idmaterial		= 2,
    @nombrematerial = 'Material 2',
    @preciomaterial = 19.99,
    @idrecibo		= 2,
    @numerorecibo	= '002';

--Insertamos datos a tb_detalle_lista
EXEC usp_inserta_detalle_lista 
    @iddetallelista = 1,
    @idlista		= 1,
    @idmaterial		= 1,
    @cantidad		= 5,
    @preciocosto	= 49.95;

EXEC usp_inserta_detalle_lista 
    @iddetallelista = 2,
    @idlista		= 2,
    @idmaterial		= 2,
    @cantidad		= 3,
    @preciocosto	= 59.97;