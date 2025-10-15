    classDiagram

    Empleado "1" o-- "1"Departamento : tiene 
    Empleado "1" o-- "1" Puesto : tiene 
    Empleado "1" o-- "0..*" Asistencia : tiene 
    Asistencia "1" *-- "1..*" DetalleAsistencia : esta compuesto de
    JefeService -- Empleado
    JefeService -- Asistencia
    Departamento "1" *-- "1" Usuario : contiene

    class Empleado {
        -idEmpleado: string
        -nombre: string
        -paterno: string
        -materno: string
        -RFC: string
        -telefono: string
        -correo : string
        -departamento: Departamento
        -Puesto: puesto
        -Jefe: Empleado
        -Subordinados : List~Empleado~
    }

    class Departamento {
        -idDepartamento: string
        -nombre : string
        -JefeDepartamento: Empleado
        -usuario : Usuario 
        -generarNuevoUsuario() void
        +asignarJefe(Empleado jefe) void
    }

    class Puesto {
        -idPuesto: string
        -nombre : string
        -salario: decimal
    }

    class Usuario {
        -idUsuario: string
        -usuario : string
        -contrasenia: string
    }
    
    class Asistencia {
        -idAsistencia: string
        -asistencias: List~DetalleAsistencia~
        -fecha : DateTime

    }

    class DetalleAsistencia {
        -idDetalleAsistencia: string
        -empleado: Empleado
        -asistencia : bool
    }

    class JefeService {
        -esJefe(empleado: Empleado) bool
        -finalizarJornada() void
        -verAsistencia(fecha: DateTime) ListAsistencia
    }
