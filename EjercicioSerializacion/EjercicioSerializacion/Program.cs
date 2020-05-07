using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace EjercicioSerializacion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();

            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Bienvenido!");
                Console.WriteLine("Selecciona una opción: ");
                Console.WriteLine("[1]Crear Persona");
                Console.WriteLine("[2]Ver Personas");
                Console.WriteLine("[3]Almacenar Personas");
                Console.WriteLine("[4]Cargar Personas");
                Console.WriteLine("[5] Salir");
                int eleccion = Convert.ToInt32(Console.ReadLine());

                switch (eleccion)
                {
                    case 1:
                        Console.WriteLine("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Apellido: ");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("Edad: ");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        Persona persona = new Persona(nombre, apellido, edad);
                        personas.Add(persona);
                        Console.WriteLine("Persona añadida");
                        Thread.Sleep(1000);
                        break;
                    case 2:
                        foreach (Persona persona2 in personas)
                        {
                            Console.WriteLine("Nombre: " + persona2.nombre);
                            Console.WriteLine("Apellido: " + persona2.apellido);
                            Console.WriteLine("Edad: " + persona2.edad);
                            Console.WriteLine(Environment.NewLine);
                        }
                        Thread.Sleep(1000);
                        Console.WriteLine("Presiona cualquier tecla para volver atras");
                        Console.ReadKey();
                        break;
                    case 3:
                        Almacenar();
                        Console.WriteLine("Datos Almacenados");
                        Thread.Sleep(1000);
                        break;
                    case 4:
                        Cargar();
                        Console.WriteLine("Personas Cargadas");
                        Thread.Sleep(1000);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        Thread.Sleep(1000);
                        loop = false;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
            void Almacenar()
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, personas);
                stream.Close();
            }

            void Cargar() {

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                List<Persona> personas1 = (List<Persona>)formatter.Deserialize(stream);
                personas = personas1;
                stream.Close();
            }
        }
    }
}
