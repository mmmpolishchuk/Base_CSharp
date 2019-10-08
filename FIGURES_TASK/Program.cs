using System;

namespace FIGURES_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure triangle;
            Figure rectangle;
            Figure circle;
            while (true)
            {
                Console.WriteLine("Menu:\n\tSelect the figure, that you want to know about:    1) Triangle;   2) Rectangle;   3) Circle ");
                char selection = Convert.ToChar(Console.ReadLine());

                switch (selection)
                {
                    case '1':
                        triangle = new Triangle(3, 3, 3);
                        break;
                    case '2':
                        rectangle = new Rectangle(30.1, 37.1);
                        break;
                    case '3':
                        circle = new Circle(10.2);
                        break;
                }
            }
            Console.ReadKey();
        }
    }
    class Figure
    {
        private string name;
        private double perim;
        private double area;
        private string color;
        private string[] colors = new string[] { "blue", "red", "black", "yellow", "white", "orange", "pink", "brown", "violet", "grey" };

        private Random rnd = new Random();
        private int index;
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setPerim(double perim)
        {
            this.perim = perim;
        }
        public double getPerim()
        {
            return perim;
        }
        public void setArea(double area)
        {
            this.area = area;
        }
        public double getArea()
        {
            return area;
        }
        public void setColor()
        {
            index = rnd.Next(10);
            color = colors[index];
        }
        public string getColor()
        {
            return color;
        }
        public void getInfo()
        {
            Console.WriteLine("\tFigure: " + getName() + "\n\tArea: " + getArea() + "\n\tPerim: " + getPerim() +
                "\n\tColor: " + getColor()+ "\n=============================================================================================");
        }
    }
    class Triangle : Figure
    {
        double side1, side2, side3;                                                                                //сторони трикутника
        //======================конструктор трикутника=========================
        public Triangle(double side1, double side2, double side3)
        {
            this.side1 = side1; this.side2 = side2; this.side3 = side3;

            setName((side1 == side2 && side1 == side3 && side2 == side3 ? "equilateral triangle" :
            ((side1 == side2 && side1 != side3 && side2 != side3) || (side2 == side3 && side2 != side1 && side3 != side1)
            || (side1 == side3 && side1 != side2 && side3 != side2)) ? "isosceles triangle" :
            ((side1 != side2 && side1 != side3 && side2 != side3)) ? "versatile triangle" : "unknown triangle"));
            setPerim(side1 + side2 + side3);
            double p = (side1 + side2 + side3) / 2;
            setArea(Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3)));
            setColor();
            getInfo();
        }
    }
    class Rectangle : Figure
    {
        double side1, side2;
        public Rectangle(double side1, double side2)
        {
            this.side1 = side1; this.side2 = side2;

            setName(side1 == side2 ? "square" : "rectangle");
            setArea(side1 * side2);
            setPerim((side1 + side2) * 2);
            setColor();
            getInfo();
        }
    }
    class Circle : Figure
    {
        double radius;
        public Circle(double radius)
        {
            this.radius = radius;

            setName("circle");
            setArea(3.14 * radius * radius);
            setPerim(2 * 3.14 * radius);
            setColor();
            getInfo();
        }
    }
}

