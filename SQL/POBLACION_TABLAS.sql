--DB A USAR--
use RetoSophos
go


-------------------------PROCESOS DE POBLACION DE TABLAS-----------------------------

--POBLAR LA TABLA CLIENTES--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_CrearClientes '1020712021', 'Marco Antonio Rojas Cruz', 15 , @Registrado output, @Mensaje output
exec sp_CrearClientes '1020845124', 'Juan Anselmo Vera Cruz', 30 , @Registrado output, @Mensaje output
exec sp_CrearClientes '79456123', 'Catalina Alfonsa de la prieto', 26 , @Registrado output, @Mensaje output
exec sp_CrearClientes '45548548', 'Maritza Jeni Galindo Mateus', 11 , @Registrado output, @Mensaje output
--Mensajes de salida--
select @Registrado
select @Mensaje




--POBLAR LA TABLA USUARIOS--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_RegistrarUsuario 'Antonio', '03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4',@Registrado output, @Mensaje output

--Mensajes de salida--
select @Registrado
select @Mensaje




--VERIFICAR TABLA USUARIOS--
exec sp_ValidarUsuario 'Antonio','03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4'



--POBLAR LA TABLA JUEGOS--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_CrearJuego 'Assassins Creed 2', '347354', 'PS4/PC/Xbox 360/macOS','Patrick Plourde/Olivier Palmieri','Ezio Auditore','Ubisoft Montreal/Ubisoft Kyiv','19/11/2009', @Registrado output, @Mensaje output
exec sp_CrearJuego 'Grand Theft Auto V', '454320', 'PS4/PS5/Xbox One/Xbox 360/PS3/PC','Leslie Benzies/Imran Sarwar','Michael/Trevor/Franklin','Rockstar Games/Rockstar North','17/09/2013', @Registrado output, @Mensaje output
exec sp_CrearJuego 'Dead Space', '34454', 'PS4/PS5/Xbox One/Xbox 360/PS3/PC/Wii/iOS','Glen Schofield/Matthias Worch/Bret Robbins','Isaac Clarke',' Electronic Arts/ak tronic Software & Services GmbH','27/01/2023', @Registrado output, @Mensaje output
--Mensajes de salida--
select @Registrado
select @Mensaje




--------------------Procesos de Verificacion-----------------------



--ACTUALIZAR LA TABLA DE JUEGOS(Precio)--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_ActualizarPrecio 'Assassins Creed 2',  347500, @Registrado output, @Mensaje output
--Mensajes de salida--
select @Registrado
select @Mensaje


--REGISTRAR EL ALQUILER--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_RegistrarAlquiler '1020712021','Assassins Creed 2', @Registrado output, @Mensaje output
exec sp_RegistrarAlquiler '1020845124','Grand Theft Auto V', @Registrado output, @Mensaje output
exec sp_RegistrarAlquiler '79456123','Dead Space', @Registrado output, @Mensaje output
exec sp_RegistrarAlquiler '45548548','Assassins Creed 2', @Registrado output, @Mensaje output
--Mensajes de salida--
select @Registrado
select @Mensaje
