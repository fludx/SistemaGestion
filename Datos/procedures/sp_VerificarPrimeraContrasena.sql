CREATE PROCEDURE VerificarPrimeraContrasena
    @Id_Usuario INT,
    @ContrasenaIngresada NVARCHAR(MAX),
    @EsPrimera BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PrimeraContrasena NVARCHAR(MAX);

    -- Obtener la primera contraseña usada por ese usuario
    SELECT TOP 1 @PrimeraContrasena = Contrasena
    FROM HistorialContrasenas
    WHERE Id_Usuario = @Id_Usuario
    ORDER BY FechaCambio ASC;

    -- Comparar con la contraseña actual ingresada
    IF @PrimeraContrasena IS NOT NULL AND @PrimeraContrasena = @ContrasenaIngresada
        SET @EsPrimera = 1;
    ELSE
        SET @EsPrimera = 0;
END;
