using System;

namespace Obsolete
{//Создайте класс и примените к его методам атрибут Obsolete сначала в форме, просто
 //  выводящей предупреждение, а затем в форме, препятствующей компиляции.
 //  Продемонстрируйте работу атрибута на примере вызова данных методов.

    class MyClass
    {
        [ObsoleteAttribute("Метод устарел")]
        public void Method1()
        {
            Console.WriteLine("Вызов Method1");
        }

        [ObsoleteAttribute("Метод не используеться", true)]  //     true, если использование устаревшего элемента приводит к ошибке компилятора;
        public void Method2()                                //     false, если выдается предупреждение компилятора.
        {
            Console.WriteLine("Вызов Method2");
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            MyClass inst = new MyClass();
            inst.Method1();
            inst.Method2();

        }
    }
}
