CREATE TABLE Provincias(
    Id_Provincia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Provincia NVARCHAR(50) NOT NULL
);

CREATE TABLE Partidos(
    Id_Partido INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Partido NVARCHAR(50) NOT NULL,
    Id_Provincia INT NOT NULL,
    FOREIGN KEY (Id_Provincia) REFERENCES Provincias(Id_Provincia)
);

CREATE TABLE Localidades(
    Id_Localidad INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Localidad NVARCHAR(50) NOT NULL,
    Codigo_Telefonico NVARCHAR(10) NOT NULL,
    Id_Partido INT NOT NULL,
    FOREIGN KEY (Id_Partido) REFERENCES Partidos(Id_Partido),
	Codigo_postal varchar(50)
);

CREATE TABLE Ubicacion(
    Id_Ubicacion INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Id_Provincia INT NOT NULL,
    Id_Partido INT NOT NULL,
    Id_Localidad INT NOT NULL,
    FOREIGN KEY (Id_Provincia) REFERENCES Provincias(Id_Provincia),
    FOREIGN KEY (Id_Partido) REFERENCES Partidos(Id_Partido),
    FOREIGN KEY (Id_Localidad) REFERENCES Localidades(Id_Localidad)
);



--DATOS PERSONALES

CREATE TABLE Generos(
    Id_Genero INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Genero NVARCHAR(10) NOT NULL
);

CREATE TABLE Personas(
    Id_Persona INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nro_legajo INT,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Tipo_Documento NVARCHAR(8) NOT NULL,
    Num_Documento NVARCHAR(20) NOT NULL,
	CUIL NVARCHAR(20) NOT NULL,
    Calle NVARCHAR(50) NOT NULL,
    Altura NVARCHAR(6) NOT NULL,
	Piso NVARCHAR(10),
	Departamento NVARCHAR(10),
    Codigo_Postal NVARCHAR(6) NOT NULL,
    Id_Provincia INT NOT NULL,
	Id_Partido INT NOT NULL,
	Id_Localidad INT NOT NULL,
    Id_Genero INT NOT NULL,
    Sexo BIT,
    Email NVARCHAR(50) UNIQUE,
	FechaAlta DATETIME,

	FOREIGN KEY (Id_Provincia) REFERENCES Provincias(Id_Provincia),
	FOREIGN KEY (Id_Partido) REFERENCES Partidos(Id_Partido),
	FOREIGN KEY (Id_Localidad) REFERENCES Localidades(Id_Localidad),
	FOREIGN KEY (Id_Genero) REFERENCES Generos(Id_Genero)
);
 



--USUARIOS

CREATE TABLE Roles(
    Id_Rol INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Rol NVARCHAR(15)
);

CREATE TABLE Permisos(
    Id_Permiso INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Permiso NVARCHAR(30),
    Descripcion NVARCHAR(100)
);

CREATE TABLE Usuarios(
    Id_Usuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Id_Persona INT,
    Usuario NVARCHAR(12) NOT NULL UNIQUE,
    Contrasena NVARCHAR(20) NOT NULL,
    Bloqueado BIT,
    Fecha_Bloqueo DATETIME,
    CambioContra INT,
    FechaCambioContra DATETIME,
    Id_Rol INT NOT NULL,
    FOREIGN KEY(Id_Rol) REFERENCES Roles(Id_Rol),
	FOREIGN KEY(Id_Persona) REFERENCES Personas(Id_Persona)
);

CREATE TABLE HistorialContrasenas(
    Id_Historial INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    FechaCambio DATETIME,
    Contrasena NVARCHAR(MAX),
    FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);

CREATE TABLE Roles_Permisos(
    Id_Rol INT NOT NULL,
    Id_Permiso INT NOT NULL,
    PRIMARY KEY (Id_Rol, Id_Permiso),
    FOREIGN KEY(Id_Rol) REFERENCES Roles(Id_Rol),
    FOREIGN KEY(Id_Permiso) REFERENCES Permisos(Id_Permiso)
);

CREATE TABLE Permisos_Usuarios(
    Id_Usuario INT NOT NULL,
    Id_Permiso INT NOT NULL,
    Fecha_Limite DATETIME,
    PRIMARY KEY (Id_Usuario, Id_Permiso),
    FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario),
    FOREIGN KEY(Id_Permiso) REFERENCES Permisos(Id_Permiso)
);



--Seguridad


CREATE TABLE Tipo_Restriccion(
Id_Tipo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Tipo NVARCHAR(20)
);


CREATE TABLE Restricciones(
Id_Restriccion INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Restriccion VARCHAR(100),
Caracteres_Min INT,
Activo BIT,
Id_Tipo INT,

FOREIGN KEY(Id_Tipo) REFERENCES Tipo_Restriccion(Id_Tipo)
);

CREATE TABLE Preguntas(
Id_Pregunta INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Pregunta NVARCHAR(25) NOT NULL 
);

CREATE TABLE Respuestas(
Id_Respuestas INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
Id_Pregunta INT,
Id_Usuario INT,
Respuesta NVARCHAR(50) NOT NULL,

FOREIGN KEY(Id_Pregunta) REFERENCES Preguntas(Id_Pregunta),
FOREIGN KEY(Id_Usuario) REFERENCES Usuarios(Id_Usuario),
);

CREATE TABLE Logs(
    Id_Log INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Usuario NVARCHAR(50) NOT NULL,
    Accion NVARCHAR(200) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE() NULL,
    CONSTRAINT FK_Logs_Usuarios FOREIGN KEY (Id_Usuario) REFERENCES dbo.Usuarios(Id_Usuario)
);
