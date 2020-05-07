using System;
using System.IO;
using System.Runtime.Serialization;


namespace ejercicio
{
    [Serializable]
    public class Persona
    {
        private string name;
        private string last;
        private int age;

        public string Name { get => name; set => name = value; }
        public string Last { get => last; set => last = value; }
        public int Age { get => age; set => age = value; }

        public Persona(string name, string last, int age)
        {
            this.Name = name;
            this.Last = last;
            this.Age = age;
        }
        
    }
}
