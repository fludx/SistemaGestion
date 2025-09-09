CREATE PROCEDURE sp_UsuarioBloqueo
    @usuario NVARCHAR(12)
AS
BEGIN
    UPDATE Usuarios
    SET Bloqueado = 1
    WHERE Usuario = @usuario;
END