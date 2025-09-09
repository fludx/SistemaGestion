CREATE PROCEDURE sp_ListarRoles
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id_Rol, Rol
    FROM Roles
    ORDER BY Rol;
END;
GO


