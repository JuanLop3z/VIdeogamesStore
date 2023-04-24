--DB A USAR--
use RetoSophos
go


--PROCEDIMIENTO PARA CREAR CLIENTES--
Create proc sp_CrearClientes(
@Identificacion varchar(50),
@Nombres varchar(200),
@Edad int,
--Mensajes de salida--
@Registrado bit output,
@Mensaje varchar(100) output
)as 
begin
	--validando si el cliente existe--
	if(not exists(select * from Clientes where Identificacion = @Identificacion))
		begin
			insert into Clientes (Identificacion, Nombres, Edad)
			values (@Identificacion,@Nombres,@Edad)
			set @Registrado = 1
			set @Mensaje = 'Cliente registrado'
		end	
		else
			begin
			set @Registrado = 0
			set @Mensaje = 'Cliente ya Existe'
			end
end
go

--PROCEDIMIENTO PARA REGISTRAR USUARIOS	--
Create proc sp_RegistrarUsuario(
@Nombre varchar(50),
@Clave varchar(50),
--Mensajes de salida--
@Registrado bit output,
@Mensaje varchar(100) output
)as 
begin
	--validando si usuario existe--
	if(not exists(select * from Usuario where Nombre = @Nombre))
		begin
			insert into Usuario(Nombre,Clave)values(@Nombre,@Clave)
			set @Registrado = 1
			set @Mensaje = 'Usuario registrado'
		end	
		else
			begin
			set @Registrado = 0
			set @Mensaje = 'Usuario ya Existe'
			end
end
go


--PROCEDIMIENTO PARA VALIDAR USUARIO--
create proc sp_ValidarUsuario(
@Nombre nvarchar(50),
@Clave nvarchar(50)
)
as
begin
	--valida los campos y devuelve el IdUsuario--
	if(exists(select * from Usuario where Nombre = @Nombre and Clave = @Clave))
		select IdUsuario from Usuario where Nombre = @Nombre and Clave = @Clave
	else
		select '0'
end
go


--PROCEDIMIENTO PARA REGISTRAR JUEGOS--
Create proc sp_CrearJuego(
@Nombre varchar(150),
@Precio int,
@Plataforma varchar(70),
@Director varchar(70),
@Protagonistas varchar(70),
@ProductorMarca varchar(70),
@FechaLanzamiento varchar(70),
--Mensajes de salida--
@Registrado bit output,
@Mensaje varchar(100) output
)as 
begin
	--validando si el Juego existe--
	if(not exists(select * from Juegos where Nombre = @Nombre))
		begin
			insert into Juegos (Nombre,Precio,Plataforma,Director,Protagonistas,ProductorMarca,FechaLanzamiento)
			values (@Nombre,@Precio,@Plataforma,@Director,@Protagonistas,@ProductorMarca,@FechaLanzamiento)
			set @Registrado = 1
			set @Mensaje = 'Juego Registrado'
		end	
		else
			begin
			set @Registrado = 0
			set @Mensaje = 'El Juego ya Existe'
			end
end
go


create proc sp_ListarClientes
as
begin
	select * from Clientes
	end