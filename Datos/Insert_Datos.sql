-- Insertar Provincias
INSERT INTO Provincias (Provincia) VALUES 
('Buenos Aires'),
('Córdoba'),
('Santa Fe');

-- Insertar Partidos
INSERT INTO Partidos (Partido, Id_Provincia) VALUES 
('La Plata', 1),
('Córdoba Capital', 2),
('Rosario', 3);

-- Insertar Localidades
INSERT INTO Localidades (Localidad, Codigo_Telefonico, Id_Partido, Codigo_postal) VALUES 
('Tolosa', '221', 1, 1104),
('Nueva Córdoba', '351', 2, 5016),
('Zona Centro', '341', 3, 1901);

-- Insertar Ubicaciones
INSERT INTO Ubicacion (Id_Provincia, Id_Partido, Id_Localidad) VALUES 
(1, 1, 1),
(2, 2, 2),
(3, 3, 3);

-- Insertar Géneros
INSERT INTO Generos (Genero) VALUES 
('Masculino'),
('Femenino'),
('Otro');

-- Insertar Personas
INSERT INTO Personas (
  Nombre, Apellido, Tipo_Documento, Num_Documento, CUIL, Calle, Altura, Piso, Departamento,
  Codigo_Postal, Id_Provincia, Id_Partido, Id_Localidad, Id_Genero, Sexo, Email, FechaAlta
) VALUES 
('Juan', 'Pérez', 'DNI', '30123456', '20-30123456-3', 'Calle Falsa', '123', NULL, NULL, '1900', 1, 1, 1, 1, 0, 'juan.perez@mail.com', GETDATE()),
('María', 'González', 'DNI', '27222333', '27-27222333-7', 'Av. Siempre Viva', '742', '2', 'B', '5000', 2, 2, 2, 2, 1, 'maria.gonzalez@mail.com', GETDATE());

-- Insertar Roles
INSERT INTO Roles (Rol) VALUES 
('Administrador'),
('Usuario Normal');

-- Insertar Permisos
INSERT INTO Permisos (Permiso, Descripcion) VALUES 
('GestionUsuarios', 'Puede gestionar usuarios'),
('VerReportes', 'Puede ver reportes'),
('AccesoTotal', 'Acceso total al sistema');

-- Insertar Usuarios
INSERT INTO Usuarios (Id_Persona, Usuario, Contrasena, Bloqueado, Fecha_Bloqueo, CambioContra, FechaCambioContra, Id_Rol)
VALUES 
(1, 'admin', 'admin123', 0, NULL, 0, GETDATE(), 1),
(2, 'usuario1', 'usuario123', 0, NULL, 0, GETDATE(), 2);

-- Insertar HistorialContrasenas
INSERT INTO HistorialContrasenas (Id_Usuario, FechaCambio, Contrasena)
VALUES 
(1, GETDATE(), 'admin123'),
(2, GETDATE(), 'usuario123');

-- Insertar Roles_Permisos
INSERT INTO Roles_Permisos (Id_Rol, Id_Permiso) VALUES 
(1, 1),
(1, 2),
(1, 3),
(2, 2);

-- Insertar Permisos_Usuarios
INSERT INTO Permisos_Usuarios (Id_Usuario, Id_Permiso, Fecha_Limite) 
VALUES 
(2, 1, DATEADD(month, 1, GETDATE()));

INSERT INTO Tipo_Restriccion(Tipo)
VALUES ('Contraseña');

INSERT INTO Tipo_Restriccion(Tipo)
VALUES ('Sistema');


-- Restricción de mínimo de caracteres
INSERT INTO Restricciones (Restriccion, Caracteres_Min, Activo, Id_Tipo)
VALUES ('Mínimo de caracteres', 6, 0, 1);

-- Combinar mayúsculas y minúsculas
INSERT INTO Restricciones (Restriccion, Caracteres_Min, Activo, Id_Tipo)
VALUES ('Combinar mayúsculas y minúsculas', NULL, 0, 1);

-- Contener números y letras
INSERT INTO Restricciones (Restriccion, Caracteres_Min, Activo, Id_Tipo)
VALUES ('Contener números y letras', NULL, 0, 1);

-- Contener un carácter especial
INSERT INTO Restricciones (Restriccion, Caracteres_Min, Activo, Id_Tipo)
VALUES ('Contener un carácter especial', NULL, 0, 1);

-- No repetir contraseñas anteriores
INSERT INTO Restricciones (Restriccion, Caracteres_Min, Activo, Id_Tipo)
VALUES ('No repetir contraseñas anteriores', NULL, 0, 1);

-- No permitir datos personales
INSERT INTO Restricciones (Restriccion, Caracteres_Min, Activo, Id_Tipo)
VALUES ('No permitir datos personales', NULL, 0, 1);

-- Requerir autenticación en dos pasos (2FA) por correo electrónico
INSERT INTO Restricciones(Restriccion, Caracteres_Min, Activo, Id_Tipo)
VALUES ('Requerir autenticación en dos pasos (2FA) por correo electrónico', NULL, 0, 2);
