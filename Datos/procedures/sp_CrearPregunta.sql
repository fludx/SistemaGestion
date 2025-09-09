CREATE PROCEDURE sp_CrearPregunta
    @Pregunta NVARCHAR(25)
AS
BEGIN
    SET NOCOUNT ON;


    IF LEN(@Pregunta) = 0
    BEGIN
        RAISERROR('La pregunta no puede estar vacía.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Preguntas WHERE Pregunta = @Pregunta)
    BEGIN
        RAISERROR('La pregunta ya existe.', 16, 1);
        RETURN;
    END

    INSERT INTO Preguntas (Pregunta)
    VALUES (@Pregunta);
END;
