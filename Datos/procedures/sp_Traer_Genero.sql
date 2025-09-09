CREATE PROCEDURE sp_Traer_Genero
    @Genero NVARCHAR(10) 
AS
BEGIN
    SELECT Id_Genero 
    FROM Generos
    WHERE Genero = @Genero;
END
