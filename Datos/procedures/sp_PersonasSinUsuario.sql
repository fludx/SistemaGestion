CREATE PROCEDURE sp_PersonasSinUsuario
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.Id_Persona,
        P.Nombre + ' ' + P.Apellido AS NombreCompleto,
        P.Num_Documento,
        P.CUIL,
        P.Email
    FROM Personas P
    LEFT JOIN Usuarios U ON P.Id_Persona = U.Id_Persona
    WHERE U.Id_Persona IS NULL
    ORDER BY P.Apellido, P.Nombre;
END
GO


