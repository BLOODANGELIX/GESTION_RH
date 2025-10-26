-- =======================================
-- Indicar a SQL que use esa Base de Datos
-- =======================================

USE [RHDB];
GO
-- =======================================
-- 1. Insertar Departamentos (sin jefe a�n)
-- =======================================
INSERT INTO [dbo].[Departamento] (nombreDepartamento, idJefe)
VALUES 
('Administraci�n', NULL),
('Recursos Humanos', NULL),
('Tecnolog�as de la Informaci�n', NULL);

-- =======================================
-- 2. Insertar Puestos
-- =======================================
INSERT INTO [dbo].[Puesto] (nombre, salario)
VALUES
('Administrador General', 25000.00),
('Analista de Recursos Humanos', 15000.00),
('Desarrollador Backend', 20000.00),
('Soporte T�cnico', 12000.00);

-- =======================================
-- 3. Insertar Empleados
-- (El RFC es clave primaria y sirve tambi�n como idJefe)
-- =======================================
INSERT INTO [dbo].[Empleado] 
(RFC, nombre, paterno, materno, telefono, correo, idDepartamento, idPuesto, idJefe)
VALUES
-- Jefe de Administraci�n (no tiene jefe)
('ADM001122AAB', 'Laura', 'Hern�ndez', 'Ruiz', '5512345678', 'laura.hernandez@empresa.com', 1, 1, NULL),

-- Recursos Humanos, jefe: Laura
('RHU001122BBC', 'Carlos', 'Mendoza', 'Soto', '5523456789', 'carlos.mendoza@empresa.com', 2, 2, 'ADM001122AAB'),

-- TI, jefe: Laura
('TII001122CCD', 'Ana', 'G�mez', 'Torres', '5534567890', 'ana.gomez@empresa.com', 3, 3, 'ADM001122AAB'),

-- Otro empleado en TI con jefe Ana
('TII002233DDE', 'Luis', 'Fern�ndez', 'Ortiz', '5545678901', 'luis.fernandez@empresa.com', 3, 4, 'TII001122CCD');

-- =======================================
-- 4. Actualizar Departamentos para asignar jefes
-- =======================================
UPDATE [dbo].[Departamento]
SET idJefe = 'ADM001122AAB'
WHERE nombreDepartamento = 'Administraci�n';

UPDATE [dbo].[Departamento]
SET idJefe = 'RHU001122BBC'
WHERE nombreDepartamento = 'Recursos Humanos';

UPDATE [dbo].[Departamento]
SET idJefe = 'TII001122CCD'
WHERE nombreDepartamento = 'Tecnolog�as de la Informaci�n';

-- =======================================
-- 5. Insertar Usuarios (vinculados simb�licamente)
-- =======================================
INSERT INTO [dbo].[Usuario] (usuario, contrasenia)
VALUES
('admin', 'admin123'),
('carlos.m', 'rhu2025'),
('ana.g', 'tiDev2025'),
('luis.f', 'support2025');

-- =======================================
-- 6. Insertar Asistencias de ejemplo
-- =======================================
INSERT INTO [dbo].[Asistencia] (idAsistencia, fecha, RFC)
VALUES
(1, '2025-10-20', 'ADM001122AAB'),
(2, '2025-10-20', 'RHU001122BBC'),
(3, '2025-10-20', 'TII001122CCD'),
(4, '2025-10-20', 'TII002233DDE'),
(5, '2025-10-21', 'ADM001122AAB'),
(6, '2025-10-21', 'TII001122CCD');