    /* =======================================
    Crear la Base de Datos
    =======================================
    */

    CREATE DATABASE [RHDB];
    GO

    -- =======================================
    -- Indicar a SQL que use esa Base de Datos
    -- =======================================

    USE [RHDB];
    GO

    -- =======================================
    -- Tabla: Usuario
    -- =======================================
    CREATE TABLE [dbo].[Usuario](
    	[idUsuario] INT IDENTITY(1,1) NOT NULL,
    	[usuario] NVARCHAR(30) NOT NULL,
    	[contrasenia] NVARCHAR(50) NOT NULL,
    	CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([idUsuario] ASC)
    );

    -- =======================================
    -- Tabla: Departamento
    -- =======================================
    CREATE TABLE [dbo].[Departamento](
        [idDepartamento] INT IDENTITY(1,1) NOT NULL,
        [nombreDepartamento] NVARCHAR(50) NOT NULL,
    	[idJefe] NVARCHAR(13),
        CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED ([idDepartamento] ASC)
    );

    -- =======================================
    -- Tabla: Puesto
    -- =======================================
    CREATE TABLE [dbo].[Puesto](
        [idPuesto] INT IDENTITY(1,1) NOT NULL,
        [nombre] NVARCHAR(50) NOT NULL,
        [salario] INT NOT NULL,
        [vacantesDisponibles] INT NOT NULL, 
        CONSTRAINT [PK_Puesto] PRIMARY KEY CLUSTERED ([idPuesto] ASC)
    );

    -- =======================================
    -- Tabla: Empleado
    -- =======================================
    CREATE TABLE [dbo].[Empleado](
        [RFC] NVARCHAR(13) NOT NULL,    
        [nombre] NVARCHAR(50) NOT NULL,
        [paterno] NVARCHAR(50) NOT NULL,
        [materno] NVARCHAR(50) NOT NULL,
        [telefono] NVARCHAR(20) NOT NULL,
        [correo] NVARCHAR(100) NOT NULL,
        [idDepartamento] INT,
        [idPuesto] INT,
        CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED ([RFC] ASC),
        CONSTRAINT [FK_Empleado_Departamento] FOREIGN KEY ([idDepartamento])
            REFERENCES [dbo].[Departamento]([idDepartamento])
            ON DELETE SET NULL,
        CONSTRAINT [FK_Empleado_Puesto] FOREIGN KEY ([idPuesto])
            REFERENCES [dbo].[Puesto]([idPuesto])
            ON DELETE SET NULL
    );

    ALTER TABLE [dbo].[Departamento]
    ADD CONSTRAINT [FK_Departamento_Empleado]
    FOREIGN KEY ([idJefe]) REFERENCES [dbo].[Empleado]([RFC])
    ON DELETE SET NULL;
