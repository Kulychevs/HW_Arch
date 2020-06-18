using System;
using System.Collections.Generic;


namespace Task2
{
    static class Constants
    {
        public static string Address = "Москва";
        public static string Format = "Начало работы метода {0}\n" +
                                      "Имя: {1}\nОписание: {2}\nАдрес: {3}\nВозраст: {4}\n" +
                                      "Окончание работы метода {0}";
    }

    public struct Man
    {
        public string name;
        public string description;
        public int age;
    }

    class Program
    {
        public static readonly string Address = Constants.Address;
        public static readonly string Format = Constants.Format;

        private static Man DummyFunc()
        {
            return new Man
            {
                name = "Петя",
                description = "школьный друг",
                age = 30
            };
        }

        private static Man DummyFuncAgain()
        {
            return new Man
            {
                name = "Вася",
                description = "сосед",
                age = 54
            };
        }

        private static Man DummyFuncMore()
        {
            return new Man
            {
                name = "Николай",
                description = "сын",
                age = 4
            };
        }

        private static void MakeAction(Func<Man> func)
        {
            string methodName = func.Method.Name;
            Man man = func.Invoke();
            Console.WriteLine(Format, methodName, man.name, man.description, Address, man.age);
        }

        private static List<Func<Man>> GetFuncSteps()
        {
            return new List<Func<Man>>()
            {
                DummyFunc,
                DummyFuncAgain,
                DummyFuncMore
            };
        }

        static void Main()
        {
            List<Func<Man>> funcs = GetFuncSteps();
            foreach (var func in funcs)
            {
                MakeAction(func);
            }

            Console.ReadLine();
        }
    }
}
