CREATE PROCEDURE sp_BloquearUsuario
    @Id_Usuario INT,
    @Bloqueado BIT,
    @Fecha_Bloqueo DATETIME = NULL
AS
BEGIN
    IF @Bloqueado = 1
    BEGIN
        -- Si se está bloqueando, actualizar también la fecha
        UPDATE Usuarios
        SET Bloqueado = 1,
            Fecha_Bloqueo = @Fecha_Bloqueo
        WHERE Id_Usuario = @Id_Usuario
    END
    ELSE
    BEGIN
        -- Si se está desbloqueando, no tocar la fecha
        UPDATE Usuarios
        SET Bloqueado = 0
        WHERE Id_Usuario = @Id_Usuario
    END
END
