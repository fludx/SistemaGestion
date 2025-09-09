CREATE PROCEDURE sp_ObtenerUsuarioPorId
    @Id_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id_Usuario,
        Id_Persona,
        Usuario,
        Contrasena,
        Bloqueado,
        Fecha_Bloqueo,
        CambioContra,
        FechaCambioContra,
        Id_Rol
    FROM 
        Usuarios
    WHERE 
        Id_Usuario = @Id_Usuario;
END;
