CREATE PROCEDURE sp_ActualizarUsuario
    @Id_Usuario INT,
    @Usuario NVARCHAR(50),
    @Bloqueado BIT,
    @Fecha_Bloqueo DATETIME = NULL,
    @CambioContra INT,
    @FechaCambioContra DATETIME = NULL,
    @Id_Rol INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FilasAfectadas INT = 0;

    UPDATE Usuarios
    SET 
        Usuario = @Usuario,
        Bloqueado = @Bloqueado,
        Fecha_Bloqueo = @Fecha_Bloqueo,
        CambioContra = @CambioContra,
        FechaCambioContra = @FechaCambioContra,
        Id_Rol = @Id_Rol
    WHERE 
        Id_Usuario = @Id_Usuario AND (
            Usuario != @Usuario OR
            Bloqueado != @Bloqueado OR
            ISNULL(Fecha_Bloqueo, '') != ISNULL(@Fecha_Bloqueo, '') OR
            CambioContra != @CambioContra OR
            ISNULL(FechaCambioContra, '') != ISNULL(@FechaCambioContra, '') OR
            Id_Rol != @Id_Rol
        );

    SET @FilasAfectadas = @@ROWCOUNT;

    SELECT @FilasAfectadas AS FilasActualizadas;
END;
