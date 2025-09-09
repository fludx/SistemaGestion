CREATE PROCEDURE sp_Validar2FACodigo
    @Id_Usuario INT,
    @CodigoIngresado NVARCHAR(6),
    @EsValido BIT OUTPUT
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM Codigos2FA
        WHERE Id_Usuario = @Id_Usuario
          AND Codigo = @CodigoIngresado
          AND DATEDIFF(MINUTE, Fecha_Generacion, GETDATE()) <= 5
    )
        SET @EsValido = 1;
    ELSE
        SET @EsValido = 0;
END;
