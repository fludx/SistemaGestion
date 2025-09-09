CREATE PROCEDURE sp_ActualizarRestriccion
   @Restriccion NVARCHAR(100),
   @Caracteres_Min NVARCHAR(10),
   @Activo BIT
AS
BEGIN
   UPDATE Restricciones
   SET Caracteres_Min = @Caracteres_Min,
       Activo = @Activo
   WHERE Restriccion = @Restriccion
END
