using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MySnake_Project
{
    class Point
    {
        public int x;
        public int y;
        public char symbol;
        public Point(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            symbol = p.symbol;
        }
        public void Move(int shift, Direction direct)
        {
            if (direct == Direction.Right)
            {
                x = x + shift;
            }
            else if (direct == Direction.Left)
            {
                x = x - shift;
            }
            else if (direct == Direction.Up)
            {
                y = y - shift;
                Thread.Sleep(30);
            }
            else if (direct == Direction.Down)
            {
                y = y + shift;
                Thread.Sleep(30);
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        public void Clear()
        {
            symbol = ' ';
            Draw();
        }
    }
    class Figure
    {
        protected List<Point> pointList;
        public void Draw()
        {
            foreach (Point p in pointList)
            {
                p.Draw();
            }
        }
        public bool Strike(Figure figure)
        {
            foreach (var p in pointList)
            {
                if (figure.Strike(p))
                {
                    return true;
                }
            }
            return false;
        }
        public bool Strike(Point point)
        {
            foreach (var p in pointList)
            {
                if (p.x == point.x && p.y == point.y)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class HorizontLine : Figure
    {
        public HorizontLine(int leftX, int rightX, int y, char symb)
        {
            pointList = new List<Point>();
            for (int x = leftX; x <= rightX; x++)
            {
                Point p = new Point(x, y, symb);
                pointList.Add(p);
            }
        }
    }
    class VerticalLine : Figure
    {
        public VerticalLine(int upY, int downY, int x, char symb)
        {
            pointList = new List<Point>();
            for (int y = upY; y <= downY; y++)
            {
                Point p = new Point(x, y, symb);
                pointList.Add(p);
            }
        }
    }
    class Snake : Figure
    {
        Direction direct;

        public Snake(Point tail, int length, Direction direct)
        {
            this.direct = direct;
            pointList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direct);
                pointList.Add(p);
            }
        }
        public void Move()
        {
            Point tail = pointList.First();
            pointList.Remove(tail);
            Point head = GetNewHead();
            pointList.Add(head);

            tail.Clear();
            head.Draw();
        }
        public Point GetNewHead()
        {
            Point head = pointList.Last();
            Point nextHead = new Point(head);
            nextHead.Move(1, direct);
            return nextHead;
        }

        public void KeyMethod(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                direct = Direction.Up;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direct = Direction.Down;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                direct = Direction.Left;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direct = Direction.Right;
            }
        }
        public bool Eat(Point food)
        {
            Point head = GetNewHead();
            if (head.x == food.x && head.y == food.y)
            {
                food.symbol = head.symbol;
                pointList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool StrikeTail()
        {
            var head = pointList.Last();
            for (int i = 0; i < pointList.Count - 2; i++)
            {
                if (head.x == pointList[i].x && head.y == pointList[i].y)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class FoodCreate
    {
        int height;
        int width;
        char symbol;
        Random rnd = new Random();
        public FoodCreate(int height, int width, char symbol)
        {
            this.height = height;
            this.width = width;
            this.symbol = symbol;
        }
        public Point MakingFood()
        {
            int x = rnd.Next(1, width - 2);
            int y = rnd.Next(1, height - 2);
            return new Point(x, y, symbol);
        }
    }
    class Borders
    {
        List<Figure> borders;

        public Borders(int height, int width)
        {
            borders = new List<Figure>();

            HorizontLine horizontUp = new HorizontLine(0, 88, 0, '#');
            VerticalLine verticalLeft = new VerticalLine(0, 29, 0, '#');
            HorizontLine horizontDown = new HorizontLine(0, 88, 29, '#');
            VerticalLine verticalRight = new VerticalLine(0, 29, 88, '#');

            borders.Add(horizontUp);
            borders.Add(horizontDown);
            borders.Add(verticalLeft);
            borders.Add(verticalRight);

        }
        public bool Strike(Figure figure)
        {
            foreach (var border in borders)
            {
                if (border.Strike(figure))
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            foreach (var border in borders)
            {
                border.Draw();
            }
        }
    }
    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetBufferSize(75, 25);
            Console.SetWindowSize(90, 30);

            Console.SetCursorPosition(37, 14);
            Console.WriteLine("S  N  A  K  E");

            Borders borders = new Borders(90, 30);
            borders.Draw();

            Point p = new Point(3, 4, '*');

            Snake snake = new Snake(p, 5, Direction.Right);
            snake.Draw();

            FoodCreate foodCreate = new FoodCreate(30, 90, '@');
            Point food = foodCreate.MakingFood();
            food.Draw();

            while (true)
            {
                if (borders.Strike(snake) || snake.StrikeTail())
                {
                    Console.SetCursorPosition(37, 14);
                    Console.WriteLine("Y O U  L O O S E");
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreate.MakingFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(60);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.KeyMethod(key.Key);
                }
            }
            Console.ReadLine();
        }
    }
}

