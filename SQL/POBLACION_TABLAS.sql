--DB A USAR--
use RetoSophos
go


--POBLAR LA TABLA CLIENTES--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_CrearClientes '1020712021', 'Marco Antonio Rojas Cruz', 15 , @Registrado output, @Mensaje output
exec sp_CrearClientes '1020845124', 'Juan Anselmo Vera Cruz', 30 , @Registrado output, @Mensaje output
exec sp_CrearClientes '79456123', 'Catalina Alfonsa de la prieto', 26 , @Registrado output, @Mensaje output
exec sp_CrearClientes '45548548', 'Maritza Jeni Galindo Mateus', 11 , @Registrado output, @Mensaje output

select @Registrado
select @Mensaje




--POBLAR LA TABLA USUARIOS--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_RegistrarUsuario 'Antonio', '03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4',@Registrado output, @Mensaje output

select @Registrado
select @Mensaje




--VERIFICAR TABLA USUARIOS--
exec sp_ValidarUsuario 'Antonio','03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4'



--POBLAR LA TABLA JUEGOS--
declare @Registrado bit, @Mensaje varchar(100)

exec sp_CrearJuego 'Assassins Creed 2', '347354', 'PlayStation 4/Microsoft Windows/Xbox 360/macOS','Patrick Plourde/Olivier Palmieri','Ezio Auditore','Ubisoft Montreal/Ubisoft Kyiv','19/11/2009', @Registrado output, @Mensaje output

select @Registrado
select @Mensaje

