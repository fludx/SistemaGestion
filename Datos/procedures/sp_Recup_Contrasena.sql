CREATE PROCEDURE sp_Recup_Contrasena
    @NombreUsuario NVARCHAR(100)
AS
BEGIN
    SELECT 
        U.Usuario,
        P.Email AS CorreoElectronico
    FROM 
        dbo.Usuarios U
    INNER JOIN 
        dbo.Personas P ON U.Id_Persona = P.Id_Persona
    WHERE 
        U.Usuario = @NombreUsuario
END
