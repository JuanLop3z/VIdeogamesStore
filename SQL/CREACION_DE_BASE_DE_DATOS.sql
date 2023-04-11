create database RetoSophos
go

use RetoSophos
go

create table Clientes(
Identificacion varchar (50),
Nombres varchar(200),
FechaAlquiler datetime default getdate(),
Estado bit default 1,
Frecuencia int
)

go

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
)
go