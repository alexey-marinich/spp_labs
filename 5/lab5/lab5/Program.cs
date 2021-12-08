using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace laba_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Путь к dll");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("Неверный путь");
                Console.ReadLine();
                return;
            }

            string extension = Path.GetExtension(path);

            if (extension.Equals(".dll") || extension.Equals(".exe"))
            {
                Assembly asm = Assembly.LoadFrom(path);
                var types = asm.GetTypes().Where(type => type.IsPublic);
                foreach (Type t in types)
                {
                    Console.WriteLine(t.FullName);
                }
            }
            else
            {
                Console.WriteLine("type error");
            }
            Console.ReadLine();
        }
    }
}