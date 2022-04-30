using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace add
{//Создайте пользовательский атрибут AccessLevelAttribute, позволяющий определить
 // уровень доступа пользователя к системе.Сформируйте состав сотрудников некоторой фирмы
//  в виде набора классов, например, Manager, Programmer, Director.При помощи атрибута
 // AccessLevelAttribute распределите уровни доступа персонала и отобразите на экране
 //реакцию системы на попытку каждого сотрудника получить доступ в защищенную секцию.

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class AccessLevelAttribute : Attribute// 1наследование
    {
        public int level;
        public AccessLevelAttribute(int level)
        {
            this.level = level;
        }
    }
    class Employee
    {

    }

    [AccessLevel(1)]
    class Manager : Employee
    {

    }

    [AccessLevel(2)]
    class Programmer : Employee
    {

    }

    [AccessLevel(3)]
    class Director : Employee
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>() { new Manager(), new Programmer(), new Director() };

            Type type;
            foreach (Employee item in employees)
            {
                type = item.GetType(); // typeof(item) не заработало почему-то
                dynamic[] attributes = type.GetCustomAttributes( false); // получение массива из всех атрибутов класса 
                                                                         //object- не прокатило, с ним нельзя обращаться по индексу
                                                                         // вместо него можно было бы заменить attributes[0].level на foreach по его поиску

                Console.WriteLine($"Имя класса/ должность {type.Name, -15},   атрибут/ уровень доступа { attributes[0].level }");
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
