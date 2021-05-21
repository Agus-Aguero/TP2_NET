using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        public Usuarios (Business.Logic.UsuarioLogic usuarioNegocio)
        {
            UsuarioNegocio = usuarioNegocio;
        }

        public Usuarios()
        { }

        public Business.Logic.UsuarioLogic UsuarioNegocio { get; set; }

        public void Menu()
        {
            Console.WriteLine("Menu de opciones:");
            Console.WriteLine("1- Listado genreal");
            Console.WriteLine("2- Consulta");
            Console.WriteLine("3- Agregar");
            Console.WriteLine("4- Modificar");
            Console.WriteLine("5- Eliminar");
            Console.WriteLine("6- Salir");

            int opt = Convert.ToInt32(Console.ReadLine());

            /*
            switch (opt)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:

                default: Console.WriteLine("Opcion incorrecta");
            }*/

        }

        public void ListadoGeneral()
        {

            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }

        }

        public void Consultar()
        { }

        public void Agregar()
        { }

        public void Modificar()
        { }

        public void Eliminar()
        { }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\t Nombre: {0}", usr.Nombre);
            Console.WriteLine("\t\t Apellido: {0}", usr.Apellido);
            Console.WriteLine("\t\t Nombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\t Clave: {0}", usr.Clave);
            Console.WriteLine("\t\t EMail: {0}", usr.EMail);
            Console.WriteLine("\t\t Habilitado: {0}", usr.Habilitado);
            Console.WriteLine();



        }


    }
}
