using System;
using System.IO;
using System.Reflection;

namespace Refl1
{//Расширьте возможности программы-рефлектора из предыдущего урока следующим образом:
 //1. Добавьте возможность выбирать, какие именно члены типа должны быть показаны
 //пользователю.При этом должна быть возможность выбирать сразу несколько членов
 //типа, например, методы и свойства.
 //2. Добавьте возможность вывода информации об атрибутах для типов и всех членов типа,
 //которые могут быть декорированы атрибутами.
    class Program
    {
        // Метод вывода информации о заданном типе членов класса.
        private static void ListMembersOfType(Assembly assembly, string path, char contain)
        {
            Console.WriteLine(new string('_', 80));

            Type type = assembly.GetType(path);
            if (contain == '1')
            {
                Console.WriteLine("\nВсе методы типа: {0} \n", type);
                MemberInfo[] methods = type.GetMethods();

                for (int i = 0; i < methods.Length; i++)
                {
                    Console.WriteLine("{0,-15}:  {1,-35}, Номер {2}", methods[i].MemberType, methods[i], i);
                }
            }

            if (contain == '2')
            {
                Console.WriteLine("\nВсе свойства типа: {0} \n", type);
                MemberInfo[] methods = type.GetProperties();

                for (int i = 0; i < methods.Length; i++)
                {
                    Console.WriteLine("{0,-15}:  {1,-35}, Номер {2}", methods[i].MemberType, methods[i], i);
                }
            }
            if (contain == '3')
            {
                Console.WriteLine("\nВсе конструкторы типа: {0} \n", type);
                MemberInfo[] methods = type.GetConstructors();

                for (int i = 0; i < methods.Length; i++)
                {
                    Console.WriteLine("{0,-15}:  {1,-35}, Номер {2}", methods[i].MemberType, methods[i], i);
                }
            }
                Console.WriteLine(new string('_', 80));
        }
        


        static void Main(string[] args)
        {
            Assembly assembly = null;

            try
            {
                assembly = Assembly.Load("2_Lib_framework"); // загрузка библиотеки
                Console.WriteLine("Сборка CarLibrary - успешно загружена.");
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(1);
            }

            Console.WriteLine("Все типы в сборке {0} \n", assembly.FullName);
            Type[] types = assembly.GetTypes();  //выводим все типы в сборке
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"Тип: {types[i], -35},  Номер ({i}) ");
            }

            Console.Write("\nВведите номер типа, с которым будем работать: ");
            Type path = types[int.Parse(Console.ReadLine())];
            Console.WriteLine(path);

            Console.WriteLine("\nЧто будем смотреть?  1- методы, 2-свойства, 3-конструкторы. Ведите любое кол-во цифр подряд");


            //int containS = int.Parse(Console.ReadLine());
            char[] containS = Console.ReadLine().ToCharArray();        //парсим строку на символы и запускаем метод с ними по очереди
            
            foreach (char contain in containS)
            {
                ListMembersOfType(assembly, path.ToString(), contain); //вывод членов одного типа 
            }

            // Занимаемся атрибутами

            Console.WriteLine("\nАтрибуты типов:");
            foreach (Type typ in types)
            {
                object[] typeAttributes = typ.GetCustomAttributes(false);// все атрибуты члена класса
                
                    foreach (var attribute in typeAttributes)           // все атрибуты члена класса
                    {
                        Console.WriteLine("Тип  {0, -20},  Attribute: {1}", typ, attribute.GetType().Name);
                    }
            }
            Console.WriteLine();

            Console.WriteLine("Атрибуты выбранного типа:");
            Type type = assembly.GetType(path.ToString());// получение типа (класса)
            MemberInfo[] members = type.GetMembers(); // получение всех членов класса
            foreach (var member in members) //проход по членам класса
            {
                object[] attributes = member.GetCustomAttributes(false); //получение всех атрибутов члена
                foreach (Attribute attribute in attributes) //проход по атрибутам члена
                {
                    Console.WriteLine("Attribute: {0}", attribute.GetType().Name);
                }
            }
            Console.ReadLine();
        }
        
    }
}
