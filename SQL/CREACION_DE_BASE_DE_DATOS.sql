--CREAR BASE DE DATOS--
create database RetoSophos
go

--EJECUTAR--
use RetoSophos
go


--LA TABLA DE CLIENTES--
create table Clientes(
Identificacion varchar (50) primary key,
Nombres varchar(200),
Edad int
)
go

--LA TABLA DE JUEGOS--
create table Juegos(
Id int primary key identity,
Nombre varchar(150),
Precio int,
Plataforma varchar(70),
Director varchar(70),
Protagonistas varchar(70),
ProductorMarca varchar(70),
FechaLanzamiento varchar(70),
)
go


--TABLA DE USUARIO(login)--
create table Usuario(
IdUsuario int primary key identity(1,1),
Nombre varchar(50),
Clave varchar(50)
)
go


--TABLA DE ALQUILERES--
create table Alquileres(
  IdAlquiler int primary key identity (1,1),
  IdJuego int,
  IdCliente varchar(50),
  Estado bit default 1,
  Fecha datetime default getdate(),
  FOREIGN KEY (IdJuego) REFERENCES Juegos(Id),
  FOREIGN KEY (IdCliente) REFERENCES Clientes(Identificacion)
)
go