﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Util
{
    public enum States
    {
        New = 1,
        Deleted = 2,
        Modified = 3,
        Unmodified = 4
    }
    public enum dia
    {
        Lunes,
        Martes
    }

    public enum TipoPersona
    {
        Docente,
        Alumno,
        Admin
    }
    public enum TipoCargo
    {
        Auxiliar,
        Titular,
        Practica
    }

    public enum EstadoAlumno
    {
        Inscripto,
        Regular,
        Aprobado,
        Desaprobado
    }
}
