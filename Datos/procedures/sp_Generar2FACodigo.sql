CREATE PROCEDURE sp_Generar2FACodigo
    @Id_Usuario INT,
    @CodigoGenerado NVARCHAR(6) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

 
    DELETE FROM Codigos2FA WHERE Id_Usuario = @Id_Usuario;

    SET @CodigoGenerado = RIGHT('000000' + CAST((ABS(CHECKSUM(NEWID())) % 1000000) AS VARCHAR), 6);

    INSERT INTO Codigos2FA (Id_Usuario, Codigo)
    VALUES (@Id_Usuario, @CodigoGenerado);
END;
