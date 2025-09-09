CREATE PROCEDURE sp_ResponderPregunta
    @idusuario INT,
    @respuesta NVARCHAR(50),
    @idpregunta INT
AS
BEGIN
    SET NOCOUNT ON;

    IF LEN(@respuesta) = 0
    BEGIN
        RAISERROR('La respuesta no puede estar vacía.', 16, 1);
        RETURN;
    END

    -- Opcional: Evitar respuestas duplicadas del mismo usuario para la misma pregunta
    IF EXISTS (
        SELECT 1 FROM Respuestas
        WHERE Id_Usuario = @idusuario AND Id_Pregunta = @idpregunta
    )
    BEGIN
        RAISERROR('Ya existe una respuesta para esa pregunta de este usuario.', 16, 1);
        RETURN;
    END

    INSERT INTO Respuestas (Id_Usuario, Id_Pregunta, Respuesta)
    VALUES (@idusuario, @idpregunta, @respuesta);
END