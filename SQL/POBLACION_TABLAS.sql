use RetoSophos
go


--POBLAR LA TABLA CLIENTES--
exec sp_CrearClientes '1020712021', 'Marco Antonio Rojas Cruz', 15


--POBLAR LA TABLA USUARIOS--
declare @registrado bit, @Mensaje varchar(100)

exec sp_RegistrarUsuario 'Antonio', '03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4',@Registrado output, @Mensaje output

select @registrado
select @Mensaje


--VERIFICAR TABLA USUARIOS--
exec sp_ValidarUsuario 'Antonio','03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4'