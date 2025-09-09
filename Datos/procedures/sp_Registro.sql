CREATE PROCEDURE sp_Registro
@Nombre NVARCHAR(50),
@Apellido NVARCHAR(50),
@Tipo_Documento NVARCHAR(8),
@Num_Documento NVARCHAR(20),
@CUIL NVARCHAR(20),
@Calle NVARCHAR(50),
@Altura NVARCHAR(6),
@Piso NVARCHAR(10) = NULL,
@Departamento NVARCHAR(10) = NULL,
@Codigo_Postal NVARCHAR(6),
@Id_Provincia INT,
@Id_Partido INT,
@Id_Localidad INT,
@Id_Genero INT,
@Sexo BIT,
@Email NVARCHAR(50),
@FechaAlta DATETIME

AS

BEGIN
SET NOCOUNT ON;

DECLARE @Nro_legajo2 INT;

SELECT @Nro_legajo2= ISNULL(MAX(Nro_legajo), 0) + 1 FROM Personas;


INSERT INTO Personas (
        Nro_legajo,
        Nombre,
        Apellido,
        Tipo_Documento,
        Num_Documento,
        CUIL,
        Calle,
        Altura,
        Piso,
        Departamento,
        Codigo_Postal,
        Id_Provincia,
        Id_Partido,
        Id_Localidad,
        Id_Genero,
        Sexo,
        Email,
        FechaAlta
    )
VALUES (
        @Nro_legajo2,
        @Nombre,
        @Apellido,
        @Tipo_Documento,
        @Num_Documento,
        @CUIL,
        @Calle,
        @Altura,
        @Piso,
        @Departamento,
        @Codigo_Postal,
        @Id_Provincia,
        @Id_Partido,
        @Id_Localidad,
        @Id_Genero,
        @Sexo,
        @Email,
        @FechaAlta
    );
END;