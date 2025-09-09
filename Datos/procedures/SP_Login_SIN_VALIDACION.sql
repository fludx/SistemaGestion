CREATE PROCEDURE sp_LogearUsuario
    @Usuario NVARCHAR(50),
    @Contrasena NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 
        FROM dbo.Usuarios_Prueba
        WHERE USUARIOS = @Usuario AND contraseña = @Contrasena
    )
    BEGIN
        SELECT 1; 
    END
    ELSE
    BEGIN
        SELECT 0;  
    END
END