using Guia_EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        using (var contextdb = new Context())
        {
            bool C = true;
            while (C)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("MENU PARA CRUD");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("1 Insertar Datos");
                Console.WriteLine();
                Console.WriteLine("2 Actualizar Datos");
                Console.WriteLine();
                Console.WriteLine("3 Eliminar Datos");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Ingrese una opcion:");
                int Op1 = Convert.ToInt32(Console.ReadLine());

                switch (Op1)
                {
                    case 1:
                        contextdb.Database.EnsureCreated();

                        Student estudiante = new Student();

                        Console.WriteLine("Ingrese el Nombre: ");
                        estudiante.Nombre = Console.ReadLine();

                        Console.WriteLine();

                        Console.WriteLine("Ingrese el Apellido: ");
                        estudiante.Apellido = Console.ReadLine();

                        Console.WriteLine();

                        Console.WriteLine("Ingrese el Sexo: ");
                        estudiante.Sexo = Console.ReadLine();

                        Console.WriteLine();

                        Console.WriteLine("Ingrese el Edad: ");
                        estudiante.Edad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine();

                        contextdb.Add(estudiante);
                        contextdb.SaveChanges();

                        Console.WriteLine("Estudiante agregado correctamente.");
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el Id del registro que desea modificar");
                        var id = Console.ReadLine();
                        var persona = contextdb.Estudiantes.FirstOrDefault(p => p.Id == Int32.Parse(id));

                        if (persona != null)
                        {
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Que opción desea modificar");
                            Console.WriteLine();
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("1 Nombre");
                            Console.WriteLine();
                            Console.WriteLine("2 Apellido");
                            Console.WriteLine();
                            Console.WriteLine("3 Sexo");
                            Console.WriteLine();
                            Console.WriteLine("4 Edad");
                            Console.WriteLine();
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine();

                            Console.WriteLine("Ingrese una opcion:");
                            int op = Convert.ToInt32(Console.ReadLine());

                            switch (op)
                            {

                                case 1:
                                    Console.WriteLine();
                                    Console.WriteLine("Ingrese el nuevo nombre: ");
                                    persona.Nombre = Console.ReadLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Nuevo nombre modificado correctamente.");
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    Console.WriteLine("Ingrese el nuevo Apellido: ");
                                    persona.Apellido = Console.ReadLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Nuevo apellido modificado correctamente.");
                                    Console.WriteLine();
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    Console.WriteLine("Ingrese el nuevo Sexo: ");
                                    persona.Sexo = Console.ReadLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Nuevo sexo modificado correctamente.");
                                    Console.WriteLine();
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    Console.WriteLine("Ingrese la nueva Edad: ");
                                    if (int.TryParse(Console.ReadLine(), out int nuevaEdad))
                                    {
                                        persona.Edad = nuevaEdad;
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Nueva edad modificado correctamente.");
                                    Console.WriteLine();
                                    break;
                            }
                            contextdb.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Registro no encontrado");
                        }
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Ingrese el ID del registro que desea eliminar:");
                        var Id = Console.ReadLine();
                        var Persona = contextdb.Estudiantes.SingleOrDefault(x => x.Id == Int32.Parse(Id));
                        if (Persona != null)
                        {
                            contextdb.Estudiantes.Remove(Persona);
                            contextdb.SaveChanges();
                        }
                        Console.WriteLine("Usuario eliminado correctamente.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Desea continuar:  Precione S/N, en mayusculas");
                var cont = Console.ReadLine();
                if (cont.Equals("N"))
                {
                    C = false;
                }

            }
            Console.WriteLine();

            Console.WriteLine("Lista de estudiantes: ");
            Console.WriteLine();

            foreach (var s in contextdb.Estudiantes)
            {
                Console.WriteLine($"Nombre: {s.Nombre}, Apellido: {s.Apellido}, Sexo: {s.Sexo}, Edad: {s.Edad}");
            }

        }
    }
}

//Jose Roberto Orellana Rodriguez