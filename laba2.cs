using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

//Описати клас, який реалізує десятковий лічильник, який може збільшувати або зменшувати своє значення на одиницю в заданому діапазоні.
//Передбачити ініціалізацію лічильника значеннями за замовчуванням і довільними значеннями. Лічильник має два методи: збільшення і зменшення,
//- і властивість, що дозволяє отримати його поточний стан. Написати програму, яка демонструвала б всі можливості класу.

namespace schetchik
{
    class lichilnik
    {
        public int min;
        public int max;
        public int potochne;

        public lichilnik()//конструктор для варіанту вибора за замовчуванням 
        {
            min = 0;
            max = 10;
            potochne = 10;
        }

        public lichilnik(int min0, int max0, int tek0)//конструктор для ввода счетчика с клавиатуры
        {
            min = min0;
            max = max0;
            potochne = tek0;
        }
        public void low()//метод зменьшення на 1 
        {
            potochne = potochne - 1;
            if (potochne < min)
                potochne = max;
        }

        public void increase()//метод збільшення на 1
        {
            potochne = potochne + 1;
            if (potochne > max)
                potochne = min;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            lichilnik lich;
            int diapazon, start;
            Random r = new Random();
            string action = "";

            Console.WriteLine("вкажіть діапазон \n (або 0 якщо хочете по замовчуванню)");
            Console.Write("диапазон: ");
            while (!int.TryParse(Console.ReadLine(), out diapazon)) Console.WriteLine("неправильний формат");
            if (diapazon == 0)
                lich = new lichilnik();//якщо 0 то працює конструктор за замовчуванням
            else
            {
                Console.Write("початок відліку: ");
                while (!int.TryParse(Console.ReadLine(), out start)) Console.WriteLine("неправильний формат");//якщо ввели не тип інт напише неправильний формат
                lich = new lichilnik(start, (start + diapazon), r.Next(start, (start + diapazon)));
            }

          
            
                Console.Write("Выберите действие: \"+\"  увеличить \"-\"  уменьшить \"c\"  текущее состояние-    ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "+": lich.increase(); break;//варіант "+" - метод increase
                    case "-": lich.low(); break;//варіант "-" - метод low
                    case "c": Console.WriteLine(lich.potochne); break;//варіант "с"(англійською) - просто показує поточне число
                    default: Console.WriteLine("Сделайте правильный выбор"); break;//якщо не обрали ні однин з 3 варіантів
                }
                Console.WriteLine("\tMin {0}\n\tMax {1}\n\tTek {2}", lich.min, lich.max, lich.potochne);

            void serialize() // серіалізація мінімумів максимумім і поточного у файли "result1.json" та "result2.json" "result3.json"
            { 
                string result1 = JsonConvert.SerializeObject(lich.max);
                string result2 = JsonConvert.SerializeObject(lich.max);
                string result3 = JsonConvert.SerializeObject(lich.potochne);
                File.WriteAllText("result1.json", result1);
                File.WriteAllText("result2.json", result2);
                File.WriteAllText("result3.json", result3);
            }

            
            void Serealizer()
            {
                string result = JsonConvert.SerializeObject(lich);
                File.WriteAllText(@"/Users/polinamashinina/Documents/laba1/result1/json.txt", result);
            }
            void Deserializer()
            {
                var i = JsonConvert.DeserializeObject<lichilnik>(File.ReadAllText(@"/Users/polinamashinina/Documents/laba1/result1/json.txt"));
                Console.WriteLine($"мінімум - {i.min}");
                Console.WriteLine($"максимум - {i.max}");
                Console.WriteLine($"поточне - {i.potochne }");
            }
        }
    }

    

}