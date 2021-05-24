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
       /* public Usuarios (Business.Logic.UsuarioLogic usuarioNegocio)
        {
            UsuarioNegocio = usuarioNegocio;
        }*/ // REVISAR 

        public Usuarios()
        {
            UsuarioLogic usuarioNegocio = new UsuarioLogic();
            UsuarioNegocio = usuarioNegocio;
        }

        public UsuarioLogic UsuarioNegocio { get; set; }

        #region Metodos
        public void Menu()
        {
            Console.WriteLine("Menu de opciones:");
            Console.WriteLine("1- Listado general");
            Console.WriteLine("2- Consulta");
            Console.WriteLine("3- Agregar");
            Console.WriteLine("4- Modificar");
            Console.WriteLine("5- Eliminar");
            Console.WriteLine("6- Salir");
            Console.Write("Ingrese su opcion: ");

            int opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    {
                        ListadoGeneral();
                        break;
                    }
                    
                case 2:
                    {
                        Consultar();
                        break;
                    }
                case 3:break;
                case 4:
                    {
                        Modificar();
                        break;
                    }
                    
                case 5:break;
                case 6:break;

                default: Console.WriteLine("Opcion incorrecta");
                    break;
            }

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
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        { }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese el nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese el apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.EMail = Console.ReadLine();
                Console.Write("Ingrese Habilitacion de Usuario (1- Si /otro- No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }

            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

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
        #endregion

    }
}
