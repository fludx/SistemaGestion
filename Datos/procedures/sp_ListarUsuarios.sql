CREATE PROCEDURE sp_ListarUsuarios
AS
BEGIN
SET NOCOUNT ON;

    SELECT *
    FROM Usuarios
    ORDER BY Id_Usuario;
END;
GO