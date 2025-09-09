CREATE PROCEDURE sp_EliminarUsuario
    @Id_Usuario INT
AS
BEGIN
    DELETE FROM Usuarios WHERE Id_Usuario = @Id_Usuario;
END
