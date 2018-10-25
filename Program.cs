using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создать класс типа - Прямоугольник. Поля - высота и ширина.
//Методы вычисления площади, периметра,
//Свойства должны проверять корректность задаваемых параметров.
//Создать массив объектов. Вывести:
//a) количество четырехугольников разного типа(квадрат,прямоугольник)
//b) определить для каждой группы наибольший и наименьший
//по площади(периметру) объект.


namespace LAB3
{
    class Program
    {    
        static void Main(string[] args)
        {
            const double PI = 3.14;
            Console.WriteLine(PI);

            //ref
            void Method(ref int refA)
            {
                refA = refA + 7;
            }
            int number = 1;
            Method(ref number);
            Console.WriteLine(number);

            //out
            int p;
            Example(out p);
            Console.WriteLine(p);
            void Example(out int n)
            {
                n = 18;
            }

            //метод: является ли элемент членом массива
            bool isPartOfArray(int element, int[] array, int arraySize)
            {
                for (int i = 0; i < arraySize; i++)
                {
                    if (element == array[i])
                    {
                        return true;
                    }
                }
                return false;
            }
            
            //анонимный тип
            var circle = new { radius = 5 };
            Console.WriteLine($"анонимный тип circle с параметром radius = {circle.radius}");
            Console.WriteLine("нажмите любую клавишу для создания массива объектов.");
            Console.Read();

            //массив объектов
            int squares = 0;
            int[] indexesofsquares = new int[10];
            Rectangle[] rect = new Rectangle[10];
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                rect[i] = new Rectangle(rand.Next(minValue: 1, maxValue: 20), rand.Next(minValue: 1, maxValue: 20));
                if (rect[i].Width == rect[i].Height)
                {
                    indexesofsquares[squares] = i;
                    squares++;
                }
            }
            Console.WriteLine("Создан массив объектов:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"прямоугольник #{i} шириной {rect[i].Width} и высотой" +
                    $" {rect[i].Height}. хеш объекта: {rect[i].GetHashCode()}");
                Console.WriteLine($"    площадь = {rect[i].Square()}," +
                $" периметр = {rect[i].Perimeter()}");
            }
            Console.WriteLine(" сравнение первого и второго объекта: " + Equals(rect[0], rect[1]));
            Console.WriteLine(" тип объекта: " + rect[1].Width.GetType());

            Console.WriteLine($"количество квадратов = {squares}");
            Console.WriteLine("количество прямоугольников = " + (10 - squares));

            //Нахождение наибольшего и наименьшего
            //среди квадратов:
            if (squares != 0)
            {
                int minimal =(int)rect[indexesofsquares[0]].Square();
                int maximal =(int)rect[indexesofsquares[0]].Square();
                int minindex = indexesofsquares[0];
                int maxindex = minindex;

                for (int i = 1; i < squares; i++)
                {
                    if (minimal > rect[indexesofsquares[i]].Square())
                    {
                        minimal =(int) rect[indexesofsquares[i]].Square();
                        minindex = indexesofsquares[i];
                    }
                }
                for (int i = 1; i < squares; i++)
                {
                    if (maximal < rect[indexesofsquares[i]].Square())
                    {
                        maximal =(int) rect[indexesofsquares[i]].Square();
                        maxindex = indexesofsquares[i];
                    }
                }
                Console.WriteLine($"наименьшая площадь у квадрата #{minindex}");
                Console.WriteLine($"наибольшая площадь у квадрата #{maxindex}");
            }

            //Среди прямоугольников
            if (squares < 10)
            {
                int indexOfMinArea = 0;
                int minArea = (int)rect[0].Square();
                int indexOfMaxArea = 0;
                int maxArea =(int) rect[0].Square();

                for (int i = 1; i < 10; i++)
                {
                    if (isPartOfArray(i, indexesofsquares, 10))
                    {
                        continue;
                    }
                    if (minArea > rect[i].Square())
                    {
                        minArea = (int)rect[i].Square();
                        indexOfMinArea = i;
                    }
                }
                for (int i = 1; i < 10; i++)
                {
                    if (isPartOfArray(i, indexesofsquares, 10))
                    {
                        continue;
                    }
                    if (maxArea < rect[i].Square())
                    {
                        maxArea =(int) rect[i].Square();
                        indexOfMaxArea = i;
                    }
                }
                Console.WriteLine($"Наименьшая площадь у прямоугольника #{indexOfMinArea}");
                Console.WriteLine($"Наибольшая площадь у прямоугольника #{indexOfMaxArea}");
            }

            Person Tom = new Person();
            Tom.Move();

            Console.ReadKey();
        }
    }
}
