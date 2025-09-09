CREATE PROCEDURE sp_ResponderRespuestas
    @Usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdUsuario INT;

    SELECT @IdUsuario = Id_Usuario
    FROM Usuarios
    WHERE Usuario = @Usuario;

    IF @IdUsuario IS NOT NULL
    BEGIN
        SELECT 
            P.Id_Pregunta,
            P.Pregunta,
            R.Respuesta
        FROM 
            Respuestas R
            INNER JOIN Preguntas P ON R.Id_Pregunta = P.Id_Pregunta
        WHERE 
            R.Id_Usuario = @IdUsuario;
    END
    ELSE
    BEGIN
        RAISERROR('Usuario no encontrado', 16, 1);
    END
END
