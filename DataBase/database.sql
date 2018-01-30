create database webapi
go

use webapi
go

create table Persona(
	Id int identity(1,1) not null primary key,
	Nombre varchar(100) not null,
	Apellido1 varchar(100) not null,
	Apellido2 varchar(100) not null
)
go

