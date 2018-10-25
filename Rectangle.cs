using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    public partial class Person //частичный класс
    {
        public void Move()
        {
            Console.WriteLine("Все задания выполнены.");
        }
    }
   
    public enum RectangleType
    {
        Square,
        Rectangle
    }

    public class Rectangle
    {
        static Rectangle()//статический конструктор
        {
            _a = 200;
            Console.WriteLine(_a + "-статический конструктор");
        }
        static int _a;

        private static int InstanceCount = 0;
        public readonly int ID;
        private double _height;
        public double Height//высота
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                _height = value;
            }
        }

        private double _width;
        public double Width //ширина
        {
            get { return _width; }
            set
            {
                if(value <= 0)
                {
                    return;
                }
                _width = value;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() * 5;
        }

        private RectangleType _rectangleType;
        public RectangleType RectangleType {
            get
            {
                return _rectangleType;
            }
            private set
            {
                _rectangleType = value;
            }
        }

        public double Square()
        {
            return _height * _width;
        }

        public double Perimeter()
        {
            return _height + _width;
        }

        private  Rectangle()
        {
            InstanceCount++;//счетчик экз
            _height = 0;
            _width = 0;
        }

        public Rectangle(double height, double width, RectangleType type):this()
        {
            Height = height;
            Width = width;
            RectangleType = type;
        }

        

        public Rectangle(double height, RectangleType rectangleType = RectangleType.Square)
            :this(height, height, rectangleType)
        {
        }
        public Rectangle(int _height, int _width)
        {
            Height = _height;
            Width = _width;
            ID = GetHashCode();
            InstanceCount++;
        }
        public static int GetInstanceCount()
        {
            return InstanceCount;
        }
    }
}
