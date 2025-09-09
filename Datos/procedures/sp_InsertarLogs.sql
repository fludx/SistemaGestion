CREATE PROCEDURE sp_InsertarLog
    @Usuario NVARCHAR(50),
    @Accion NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdUsuario INT;

    SELECT @IdUsuario = Id_Usuario
    FROM Usuarios
    WHERE Usuario = @Usuario;

    IF @IdUsuario IS NULL
    BEGIN
        RAISERROR('El usuario no existe.', 16, 1);
        RETURN;
    END

    INSERT INTO Logs (Id_Usuario, Usuario, Accion, Fecha)
    VALUES (@IdUsuario, @Usuario, @Accion, GETDATE());
END