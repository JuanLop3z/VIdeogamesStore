--CREAR BASE DE DATOS--
create database RetoSophos
go
use RetoSophos
go


--CREAMOS LA TABLA DE CLIENTES--
create table Clientes(
Identificacion varchar (50),
Nombres varchar(200),
Estado bit default 1,
Frecuencia int,
edad int
)
go

--CREAMOS LA TABLA DE JUEGOS--
create table Juegos(
Id int primary key identity,
Nombre varchar(150),
Precio int,
Frecuencia int,
Plataforma varchar(70),
Director varchar(70),
Protagonistas varchar(70),
ProductorMarca varchar(70),
FechaLanzamiento varchar(70),
Estado varchar(70),
FechaAlquiler datetime default getdate(),
)
go


--CREAMOS LA TABLA DE USUARIO(login)--
create table Usuario(
IdUsuario int primary key identity(1,1),
Nombre varchar(50),
Clave varchar(50)
)
go

