CREATE PROCEDURE sp_ListarLogs
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        L.Id_Log,
        U.Usuario,
        L.Accion,
        L.Fecha
    FROM Logs L
    INNER JOIN Usuarios U ON L.Id_Usuario = U.Id_Usuario
    ORDER BY L.Fecha DESC;
END
