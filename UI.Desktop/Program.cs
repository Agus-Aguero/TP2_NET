﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Usuarios());
            Application.Run(new Menu());
            //Application.Run(new Materias());
            //Application.Run(new Comisiones());
            // Application.Run(new Planes());
            // Application.Run(new Especialidades());
            //Application.Run(new Cursos());
        }
    }
}
