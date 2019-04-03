using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            //первый вариант использования:
            // создаем список экземпляров классов только по нужному нам свойству из интерфейса igrowing.
            IGrowing[] growList = new IGrowing[] { new Three(), new Man(), new Price()};
            Console.WriteLine("Please what speed of growing you want? 1, 15 or 5");
            //получаем значение скорости роста у пользователя.
            int growSpeed = int.Parse(Console.ReadLine());

            // а теперь используя наш список, который содержит параметры из интерфейса, проходим по нему и получаем 
            //нужный нам метод.
            foreach (var g in growList)
            {
                if (g.GrowSpeed == growSpeed)
                {
                    g.grow();
                }
            }
            Console.ReadLine();
            //второй вариант использования интерфейса:
            Console.WriteLine("Please what speed of growing you want? 1, 15 or 5");
            //для примера возьмеме тотже пользовательский ввод и тотже список экземпляров
             growSpeed = int.Parse(Console.ReadLine());
            IGrowing[] list = new IGrowing[] { new Three(), new Man(), new Price() };
            // выполним туже проверку по пользовательскому вводу и проверим, если наш объект является не человеком 
            //то выведем нужную строку.
            // суть в том что интерфейсы помимо удоства построения проекта предоставляют нам возможность нужный экземпляр 
            //и выполнить нужную нам функции, например.
            foreach (var a in list)
            {
                if (growSpeed == a.GrowSpeed)
                {
                    if (a is INoMan) // выполняем проверку: реализовывает ли этот объект интерфейс
                    {
                        ((INoMan)a).Signature(); // если да, то приводим этот объект у нужному типу этого интерфейса.
                    }
                }
            }
            Console.ReadLine();


        }
        
    }

   
    public class Three : IGrowing, INoMan
    {
        private int growSpeed = 1;
        public int GrowSpeed { get => growSpeed ; set => growSpeed=value; }

        public void grow()
        {
            Console.WriteLine("Growing slow");
        }
        public void Signature()
        {
            Console.WriteLine("Its Three");
        }

    }
    public class Man : IGrowing
    {
        private int growSpeed = 5;
        public int GrowSpeed { get => growSpeed; set => growSpeed = value; }

        public void grow()
        {
            Console.WriteLine("Growing like a man");
        }
    }

    public interface INoMan
    {
        void Signature();
    }

    public class Price : IGrowing, INoMan
    {
        private int growSpeed = 15;
        public int GrowSpeed { get => growSpeed; set => growSpeed = value; }

        public void grow()
        {
            Console.WriteLine("Growing every month, i hate this price");
        }

        public void Signature()
        {
            Console.WriteLine("Its Price");
        }
    }

    public interface IGrowing
    {
        void grow();
        int GrowSpeed { get; set; }
    }
}
