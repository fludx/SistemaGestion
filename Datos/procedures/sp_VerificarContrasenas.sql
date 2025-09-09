CREATE PROCEDURE sp_VerificarContrasenas
    @Id_Usuario INT,
    @NuevaContrasena NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Nombre NVARCHAR(50)
    DECLARE @Apellido NVARCHAR(50)
    DECLARE @NumDocumento NVARCHAR(20)
    DECLARE @CUIL NVARCHAR(20)
    DECLARE @Respuesta NVARCHAR(50)
    DECLARE @ErrorMsg NVARCHAR(100)

    SELECT 
        @Nombre = p.Nombre,
        @Apellido = p.Apellido,
        @NumDocumento = p.Num_Documento,
        @CUIL = p.CUIL
    FROM Personas p
    INNER JOIN Usuarios u ON u.Id_Persona = p.Id_Persona
    WHERE u.Id_Usuario = @Id_Usuario

    IF CHARINDEX(LOWER(@Nombre), LOWER(@NuevaContrasena)) > 0
    BEGIN
        SET @ErrorMsg = 'La contraseña no puede contener el nombre.'
        RAISERROR(@ErrorMsg, 16, 1)
        RETURN
    END

    IF CHARINDEX(LOWER(@Apellido), LOWER(@NuevaContrasena)) > 0
    BEGIN
        SET @ErrorMsg = 'La contraseña no puede contener el apellido.'
        RAISERROR(@ErrorMsg, 16, 1)
        RETURN
    END

    IF CHARINDEX(LOWER(@NumDocumento), LOWER(@NuevaContrasena)) > 0
    BEGIN
        SET @ErrorMsg = 'La contraseña no puede contener el número de documento.'
        RAISERROR(@ErrorMsg, 16, 1)
        RETURN
    END

    IF CHARINDEX(LOWER(@CUIL), LOWER(@NuevaContrasena)) > 0
    BEGIN
        SET @ErrorMsg = 'La contraseña no puede contener el CUIL.'
        RAISERROR(@ErrorMsg, 16, 1)
        RETURN
    END


    DECLARE respuestas CURSOR FOR
    SELECT LOWER(Respuesta)
    FROM Respuestas
    WHERE Id_Usuario = @Id_Usuario

    OPEN respuestas
    FETCH NEXT FROM respuestas INTO @Respuesta

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF CHARINDEX(@Respuesta, LOWER(@NuevaContrasena)) > 0
        BEGIN
            SET @ErrorMsg = 'La contraseña no puede contener partes de sus respuestas de seguridad.'
            RAISERROR(@ErrorMsg, 16, 1)
            CLOSE respuestas
            DEALLOCATE respuestas
            RETURN
        END

        FETCH NEXT FROM respuestas INTO @Respuesta
    END

    CLOSE respuestas
    DEALLOCATE respuestas


    UPDATE Usuarios
    SET 
        Contrasena = @NuevaContrasena,
        FechaCambioContra = GETDATE(),
        CambioContra = ISNULL(CambioContra, 0) + 1
    WHERE Id_Usuario = @Id_Usuario

    INSERT INTO HistorialContrasenas (Id_Usuario, FechaCambio, Contrasena)
    VALUES (@Id_Usuario, GETDATE(), @NuevaContrasena)

    PRINT 'Contraseña agregada.'
END