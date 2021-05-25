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

        public bool StopMenu = true;

        public Usuarios()
        {
            UsuarioLogic usuarioNegocio = new UsuarioLogic();
            UsuarioNegocio = usuarioNegocio;
        }

        public UsuarioLogic UsuarioNegocio { get; set; }

        #region Metodos
        public void Menu()
        {
            do {
                Console.Clear();
                Console.WriteLine("Menu de opciones:");
                Console.WriteLine("");
                Console.WriteLine("***********************");
                Console.WriteLine("");
                Console.WriteLine("1-\tListado general");
                Console.WriteLine("2-\tConsulta");
                Console.WriteLine("3-\tAgregar");
                Console.WriteLine("4-\tModificar");
                Console.WriteLine("5-\tEliminar");
                Console.WriteLine("6-\tSalir");
                Console.WriteLine("");
                Console.WriteLine("***********************");
                Console.WriteLine("");
                Console.Write("Ingrese su opcion: ");

                int opt = Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                    case 6:
                        StopMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }

            } while (StopMenu != false);
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            Console.WriteLine("***********************");
            Console.WriteLine("");
            Console.WriteLine("Listado general");
            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");
           
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.ReadKey();

        }

        public void Consultar()
        {
            Console.Clear();
            Console.WriteLine("***********************");
            Console.WriteLine("");
            Console.WriteLine("Consultar usuario");
            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");

            try
            {
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
        {
            Console.Clear();

            Console.WriteLine("Agregar usuario:");
            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");

            Usuario usuario = new Usuario();

            Console.Write("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.EMail = Console.ReadLine();
            Console.Write("Ingrese habilitación de usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Modificar()
        {
            Console.Clear();

            Console.WriteLine("Modificar usuario:");
            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");

            try
            {
                Console.Write("Ingrese el ID del usuario a modificar: ");
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
        {
            Console.Clear();

            Console.WriteLine("Eliminar usuario:");
            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");
            try
            {
                Console.Write("Ingrese el ID del usuario a elminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);

            }
            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero.");

            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }   
            finally
            {
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }

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
