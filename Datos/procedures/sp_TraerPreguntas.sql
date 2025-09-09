CREATE PROCEDURE sp_TraerPreguntas
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Cantidad <= 0 OR @Cantidad > (SELECT COUNT(*) FROM Preguntas)
    BEGIN
        RETURN 0;  
    END

    SELECT TOP (@Cantidad) Id_Pregunta, Pregunta
    FROM Preguntas
    ORDER BY NEWID();

    RETURN 1;  
END;
