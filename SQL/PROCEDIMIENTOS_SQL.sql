--DB A USAR--
use RetoSophos
go


--PROCEDIMIENTO PARA CREAR CLIENTES--
Create proc sp_CrearClientes(
@Identificacion varchar(50),
@Nombres varchar(200),
@Edad int
)as 
begin
	insert into Clientes (Identificacion, Nombres, edad)
	values (@Identificacion,@Nombres,@Edad)
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

