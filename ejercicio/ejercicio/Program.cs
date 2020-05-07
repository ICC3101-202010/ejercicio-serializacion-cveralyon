using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace ejercicio
{
    class MainClass
    {
        public static int Numero(int o) // verifica que el input  sea un numero dentro del rango requerido
        {
            int n;
            bool aux0;
            do
            {
                string p;
                p = Console.ReadLine();
                aux0 = int.TryParse(p, out n);
                if (aux0 == false) { Console.WriteLine("---ERROR: INGRESE SOLO NUMEROS del 1 al {0}---", o); }
            } while (!aux0 & n <= 0);
            return n;
        }
        public static object Crear_persona()
        {
            Console.WriteLine("Ingrese sus datos: \n");
            Console.WriteLine("\nNombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nApellido: ");
            string last = Console.ReadLine();
            Console.WriteLine("\nEdad: ");
            int age = Numero(999999999);
            Persona persona = new Persona(name, last, age);
            return persona;
        }
        public static void Almacenar(Stream stream, object persona)
        {
            IFormatter formatear = new BinaryFormatter();
            formatear.Serialize(stream, persona);
            stream.Close();

        }

        public static void Cargar(Stream stream)
        {
            stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            IFormatter formatear = new BinaryFormatter();
            Persona p2 = (Persona)formatear.Deserialize(stream);
            Console.WriteLine("Los datos guardados son:");
            Console.WriteLine(p2.Name);
            Console.WriteLine(p2.Last);
            Console.WriteLine(p2.Age);
        }

        public static void Main(string[] args)
        {
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            bool continuar= true;
            while (continuar == true)
            {
                object persona = Crear_persona();
                Almacenar(stream, persona);
                Console.WriteLine("Ingrese 1 para ingresar una nueva persona o 0 para terminar");
                int cont= int.Parse(Console.ReadLine());
                Cargar(stream);

                
            }

        }
    }
}
