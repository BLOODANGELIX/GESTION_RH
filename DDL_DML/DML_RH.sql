-- =======================================
-- Indicar a SQL que use esa Base de Datos
-- =======================================

USE [RHDB];
GO
-- =======================================
-- 1. Insertar Departamentos (sin jefe aún)
-- =======================================
INSERT INTO [dbo].[Departamento] (nombreDepartamento, idJefe)
VALUES 
('Administración', NULL),
('Recursos Humanos', NULL),
('Tecnologías de la Información', NULL);

-- =======================================
-- 2. Insertar Puestos
-- =======================================
INSERT INTO [dbo].[Puesto] (nombre, salario, vacantesDisponibles)
VALUES
('Administrador General', 25000,1),
('Analista de Recursos Humanos', 15000,1),
('Desarrollador Backend', 20000,3),
('Soporte Técnico', 12000,2);

-- =======================================
-- 3. Insertar Empleados
-- (El RFC es clave primaria y sirve también como idJefe)
-- =======================================
INSERT INTO [dbo].[Empleado] 
(RFC, nombre, paterno, materno, telefono, correo, idDepartamento, idPuesto)
VALUES
-- Jefe de Administración (no tiene jefe)
('ADM001122AAB', 'Laura', 'Hernández', 'Ruiz', '5512345678', 'laura.hernandez@empresa.com', 1, 1),

-- Recursos Humanos, jefe: Laura
('RHU001122BBC', 'Carlos', 'Mendoza', 'Soto', '5523456789', 'carlos.mendoza@empresa.com', 2, 2),

-- TI, jefe: Laura
('TII001122CCD', 'Ana', 'Gómez', 'Torres', '5534567890', 'ana.gomez@empresa.com', 3, 3),

-- Otro empleado en TI con jefe Ana
('TII002233DDE', 'Luis', 'Fernández', 'Ortiz', '5545678901', 'luis.fernandez@empresa.com', 3, 4);

-- =======================================
-- 4. Actualizar Departamentos para asignar jefes
-- =======================================
UPDATE [dbo].[Departamento]
SET idJefe = 'ADM001122AAB'
WHERE nombreDepartamento = 'Administración';

UPDATE [dbo].[Departamento]
SET idJefe = 'RHU001122BBC'
WHERE nombreDepartamento = 'Recursos Humanos';

UPDATE [dbo].[Departamento]
SET idJefe = 'TII001122CCD'
WHERE nombreDepartamento = 'Tecnologías de la Información';

-- =======================================
-- 5. Insertar Usuarios (vinculados simbólicamente)
-- =======================================
INSERT INTO [dbo].[Usuario] (usuario, contrasenia)
VALUES
('admin', 'admin123');
