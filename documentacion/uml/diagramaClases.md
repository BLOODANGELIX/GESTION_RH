    classDiagram

    Empleado "1" o-- "1"Departamento : tiene 
    Empleado "1" o-- "1" Puesto : tiene 
    Empleado "1" o-- "0..*" Asistencia : tiene 
    JefeService -- Empleado
    JefeService -- Asistencia
    Departamento "1" *-- "1" Usuario : contiene

    class Empleado {
        -RFC: string
        -nombre: string
        -paterno: string
        -materno: string
        -telefono: string
        -correo : string
        -departamento: Departamento
        -Puesto: puesto
        -Jefe: Empleado
    }

    class Departamento {
        -idDepartamento: int
        -nombre : string
        -JefeDepartamento: Empleado
        +asignarJefe(Empleado jefe) void
    }

    class Puesto {
        -idPuesto: int
        -nombre : string
        -salario: decimal
    }

    class Usuario {
        -idUsuario: int
        -usuario : string
        -contrasenia: string
    }
    
    class Asistencia {
        -idAsistencia: int
        -fecha : DateTime
        -empleado: Empleado
    }

    class JefeService {
        -esJefe(empleado: Empleado) bool
        -finalizarJornada() void
        -verAsistencia(fecha: DateTime) ListAsistencia
    }
